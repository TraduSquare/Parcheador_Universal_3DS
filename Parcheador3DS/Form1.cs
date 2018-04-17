using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Net;
using System.Threading;
using System.Diagnostics;
/*
 * Parcheador universal para juegos de 3DS. A lo largo del código se mostrarán comentarios para adaptar el contenido a cualquier juego
 * y parche de forma sencilla (IMPORTANTE LEER TODO EL CÓDIGO), pero aquí se dará una versión resumida de las bases.
 * 
 * 1. El parcheador se basa en aplicar parches xdelta al romfs.bin del juego, que contiene todos los archivos modificados.
 *    Por ello, crea archivos xdelta a partir del romfs (y exefs de ser necesario) del juego ya traducido/modificado, uno para cada región,
 *    de ser necesario, e inclúyelo en este proyecto bajo el nombre de parcheEURD.xdelta y parcheUSAD.xdelta.
 *    
 * 2. Para crear el parche luma/NTR es necesario un listado con los archivos modificados del juego.
 *    Usa la herramienta complementaria "Cuantificador 3DS.exe" e incluye el archivo "lista.txt" generado en las Resources de este proyecto.
 *    
 *    2.1 Para el parche NTR también es necesario incluir en las Resources el archivo layered.plg de ambas regiones bajo el nombre ntreur y ntrusa.
 *    
 * 3. Para personalizar el aspecto del parcheador, accede a la pestaña Form1.cs [Diseño] y modifica la interfaz a tu gusto usando el apartado
 *    "Propiedades" en la zona inferior derecha del programa.
 */
namespace Parcheador3DS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /* Se detecta automáticamente el SO donde se ejecuta el parcheador. En caso de hacerse en unix, debe ejecutarse
         * a través de la plataforma "Mono".
         */

        private void Form1_Load(object sender, EventArgs e)
        {
            /* string plataforma;
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.MacOSX:
                    plataforma = "unix";
                    break;
                case PlatformID.Unix:
                    plataforma = "unix";
                    break;

                default:
                    plataforma = "windows";
                    break;
            } */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog archivoOriginal = new OpenFileDialog();

            //Filtro para la elección de archivos, si se quiere añadir más, escribir "; *.extension" detrás de *.3ds

            archivoOriginal.Filter = "Dump de juego 3DS|*.cxi;*.3ds";
            archivoOriginal.FilterIndex = 1;

            archivoOriginal.Multiselect = false;
            if (archivoOriginal.ShowDialog() == DialogResult.OK)
            {
                string fullPath = Path.GetFullPath(archivoOriginal.FileName);
                textBox1.Text = fullPath;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún archivo. No podrás realizar el parcheo.", "Selecciona un archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Al cerrar el parcheador, la carpeta temporal se elimina

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp", true);
            }
        }
        private void Parchear_Click(object sender, EventArgs e)
        {
            string region = "";
            string ntrPatch = "";
            string xdt = "";
            string rutaEXEFS = "temp/original/exefs.bin";
            if (textBox1.Text != "")
            {
                if (usa.Checked||eur.Checked)
                {
                    MessageBox.Show("Se va a realizar el proceso de parcheo. Espera hasta que termine y no cierres la aplicación.", "Comienza el proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Eligiendo la región se coge un parche u otro y se usará el titleID adecuado para el juego. Si el titleID
                    //de tu juego es distinto, cámbialo aquí. Los xdelta deben cambiarse en los Resources para cada juego y versión

                    if (usa.Checked)
                    {
                        region = "00040000001a6600";
                        ntrPatch = "ntrusa";
                        xdt = "parcheUSAD";
                    }
                    else if (eur.Checked)
                    {
                        region = "00040000001a6f00";
                        ntrPatch = "ntreur";
                        xdt = "parcheEURD";
                    }
                    if (Directory.Exists("temp"))
                    {
                        Directory.Delete("temp", true);
                    }

                    //Se crean los directorios y binarios que usará el parcheador

                    DirectoryInfo temporal = Directory.CreateDirectory("temp");
                    Directory.CreateDirectory("temp/original");
                    Directory.CreateDirectory("temp/modificado");
                    Directory.CreateDirectory("temp/extraido");
                    Directory.CreateDirectory("temp/parches");
                    temporal.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
                    File.WriteAllBytes("temp/xdelta3.exe", Properties.Resources.xdelta3);
                    File.WriteAllBytes("temp/3dstools.exe", Properties.Resources._3dstools);
                    File.WriteAllBytes("temp/makerom.exe", Properties.Resources.makerom);

                    // En muchas ocasiones el romfs es igual para todas las regiones, por lo que solo hemos incluido un único xdelta para
                    // aplicar a ambas versiones. En caso de tener dos xdelta, subir el adicional y modificar el valor de la llamada
                    // "Properties.Resources" sustituyendo romfs por el xdelta necesario y agregado a los resources del proyecto.
                    // El nombre de los Resources para el exeFS serán exeFSEUR y exeFSUSA. Si tu parche no contiene modificaciones en el
                    // exeFS, no hace falta que borres estas líneas, únicamente creará arcihvos vacíos si no modificas el Resources.

                    if (xdt == "parcheEURD")
                    {
                        File.WriteAllBytes("temp/parches/parcheEURD.xdelta", Properties.Resources.parcheEURD);
                        File.WriteAllBytes("temp/parches/exeFSEUR.xdelta", Properties.Resources.exeFSEUR);
                    }
                    else if (xdt == "parcheUSAD")
                    {
                        File.WriteAllBytes("temp/parches/parcheUSAD.xdelta", Properties.Resources.parcheEURD);
                        File.WriteAllBytes("temp/parches/exeFSUSA.xdelta", Properties.Resources.exeFSUSA);
                    }
                    string rutaJuego = textBox1.Text;

                    //Si el juego introducido está en formato 3DS, se extraerá el CXI.

                    if (Path.GetExtension(rutaJuego) == ".3ds")
                    {
                        label2.Text = "Extrayendo archivo .3ds";
                        groupBox3.Refresh();
                        ProcessStartInfo extract3DS = new ProcessStartInfo();
                        {
                            string program = "temp/3dstools.exe";
                            string arguments = "-xvtf cci \"" + rutaJuego + "\" -0 \"temp/original/game.cxi\"";
                            extract3DS.FileName = program;
                            extract3DS.Arguments = arguments;
                            extract3DS.UseShellExecute = false;
                            extract3DS.CreateNoWindow = true;
                            extract3DS.ErrorDialog = false;
                            extract3DS.RedirectStandardOutput = true;
                            Process x = Process.Start(extract3DS);
                            x.WaitForExit();
                        }
                        rutaJuego = "temp/original/game.cxi";
                    }

                    //Se extrae el contenido del CXI.
                    label2.Text = "Extrayendo archivo romfs.bin";
                    groupBox3.Refresh();
                    ProcessStartInfo process = new ProcessStartInfo();
                    {
                        string program = "temp/3dstools.exe";
                        string arguments = "-xvtf cxi \"" + rutaJuego + "\" --header \"temp/original/ncchheader.bin\" --exh \"temp/original/exheader.bin\" --exefs \"temp/original/exefs.bin\" --romfs \"temp/original/romfs.bin\" --logo \"temp/original/logo.bcma.lz\" --plain \"temp/original/plain.bin\"";
                        process.FileName = program;
                        process.Arguments = arguments;
                        process.UseShellExecute = false;
                        process.CreateNoWindow = true;
                        process.ErrorDialog = false;
                        process.RedirectStandardOutput = true;
                        Process x = Process.Start(process);
                        x.WaitForExit();
                    }
                    label2.Text = "Aplicando parche al archivo romfs.bin";
                    groupBox3.Refresh();

                    // Dependiendo de la elección de región se aplica el parche EUR o USA. Dichos xdelta deben sustituirse en los Resources
                    // por los específicos de cada juego.

                    ProcessStartInfo xdelta = new ProcessStartInfo();
                    {
                        string program = "temp/xdelta3.exe";
                        string arguments = "";

                        if (xdt == "parcheEURD")
                        {
                            arguments = "-d -s \"" + Directory.GetCurrentDirectory() + "\\temp\\original\\romfs.bin\" \"" + Directory.GetCurrentDirectory() + "\\temp\\parches\\parcheEURD.xdelta\" \"" + Directory.GetCurrentDirectory() + "\\temp\\modificado\\romfs.bin\"";
                        }
                        else if (xdt == "parcheUSAD")
                        {
                            arguments = "-d -s \"" + Directory.GetCurrentDirectory() + "\\temp\\original\\romfs.bin\" \"" + Directory.GetCurrentDirectory() + "\\temp\\parches\\parcheUSAD.xdelta\" \"" + Directory.GetCurrentDirectory() + "\\temp\\modificado\\romfs.bin\"";
                        }
                        xdelta.FileName = program;
                        xdelta.Arguments = arguments;
                        xdelta.UseShellExecute = false;
                        xdelta.CreateNoWindow = true;
                        xdelta.ErrorDialog = true;
                        xdelta.RedirectStandardError = true;
                        xdelta.RedirectStandardOutput = true;
                        Process x2 = Process.Start(xdelta);
                        string error = x2.StandardError.ReadToEnd();
                        x2.WaitForExit();
                        if (error != "")
                        {
                            MessageBox.Show("No se ha podido parchear el juego. ¿Estás usando la versión adecuada?", "Error al parchear", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Directory.Delete("temp", true);
                            label2.Text="Rellena los campos para comenzar.";
                            groupBox3.Refresh();
                            return;
                        }
                    }

                    // Proceso para aplicar un xdelta al archivo exeFS.bin. Si tu parche no incluye modificaciones sobre el exeFS.bin,
                    // deja el proceso comentado. 

                     ProcessStartInfo xdeltaEXEFS = new ProcessStartInfo();
                     {
                         string program = "temp/xdelta3.exe";
                         string arguments = "";
                         if (xdt == "parcheEURD")
                         {
                             arguments = "-d -s \"" + Directory.GetCurrentDirectory() + "\\temp\\original\\exefs.bin\" \"" + Directory.GetCurrentDirectory() + "\\temp\\parches\\exeFSEUR.xdelta\" \"" + Directory.GetCurrentDirectory() + "\\temp\\modificado\\exefs.bin\"";
                         }
                         else if (xdt == "parcheUSAD")
                         {
                             arguments = "-d -s \"" + Directory.GetCurrentDirectory() + "\\temp\\original\\exefs.bin\" \"" + Directory.GetCurrentDirectory() + "\\temp\\parches\\exeFSUSA.xdelta\" \"" + Directory.GetCurrentDirectory() + "\\temp\\modificado\\exefs.bin\"";
                         }
                         xdeltaEXEFS.FileName = program;
                         xdeltaEXEFS.Arguments = arguments;
                         xdeltaEXEFS.UseShellExecute = false;
                         xdeltaEXEFS.CreateNoWindow = true;
                         xdeltaEXEFS.ErrorDialog = true;
                         xdeltaEXEFS.RedirectStandardError = true;
                         xdeltaEXEFS.RedirectStandardOutput = true;
                         Process proceso = Process.Start(xdeltaEXEFS);
                         string error = proceso.StandardError.ReadToEnd();
                        MessageBox.Show(error);
                        proceso.WaitForExit();
                     } 
                     rutaEXEFS= "temp/modificado/exefs.bin";
                    if (luma.Checked || ntr.Checked)
                    {
                        File.WriteAllText("temp/lista.txt", Properties.Resources.lista);
                        string[] lista = File.ReadAllLines("temp/lista.txt");
                        if (!Directory.Exists("temp/extraido/romfs"))
                        {
                            Directory.CreateDirectory("temp/extraido/romfs");
                        }
                        label2.Text = "Extrayendo romfs.bin modificado";
                        groupBox3.Refresh();
                        ProcessStartInfo extractROMFS = new ProcessStartInfo();
                        {
                            string program = "temp/3dstools.exe";
                            string arguments = "-xvtf romfs \"temp\\modificado\\romfs.bin\" --romfs-dir \"temp\\extraido\\romfs\"";
                            extractROMFS.FileName = program;
                            extractROMFS.Arguments = arguments;
                            extractROMFS.UseShellExecute = false;
                            extractROMFS.CreateNoWindow = true;
                            extractROMFS.ErrorDialog = false;
                            extractROMFS.RedirectStandardOutput = false;
                            Process xROMFS = Process.Start(extractROMFS);
                            xROMFS.WaitForExit();
                        }
                        if (ntr.Checked)
                        {
                            label2.Text = "Creando parche NTR.";
                            groupBox3.Refresh();
                            //El contenido de la variable "carpetaNTR" debe ser la carpeta que use el parche NTR.
                            string carpetaNTR = "LJT/CCCIDM/";
                            for (int i = 0; i < lista.Length; i++)
                            {
                                string ruta = Path.GetDirectoryName(lista[i]);
                                if (!Directory.Exists("temp/final/plugin/" + region))
                                {
                                    Directory.CreateDirectory("temp/final/plugin/" + region);
                                }
                                if (!Directory.Exists("temp/final/" + carpetaNTR + ruta))
                                {
                                    Directory.CreateDirectory("temp/final/" + carpetaNTR + ruta);
                                }
                                File.Copy("temp/extraido/romfs/" + lista[i], "temp\\final\\" + carpetaNTR + lista[i]);
                                if (ntrPatch == "ntreur")
                                {
                                    File.WriteAllText("temp/final/plugin/" + region + "/layeredfs.plg", Properties.Resources.ntreur);
                                }
                                else if (ntrPatch == "ntrusa")
                                {
                                        File.WriteAllText("temp/final/plugin/" + region + "/layeredfs.plg", Properties.Resources.ntrusa);
                                }
                            }
                        }
                        else if (luma.Checked)
                        {
                            label2.Text = "Creando parche Luma.";
                            groupBox3.Refresh();
                            for (int i = 0; i < lista.Length; i++)
                            {
                                string ruta = Path.GetDirectoryName(lista[i]);
                                if (!Directory.Exists("temp/final/luma/titles/"+region+"/romfs/" + ruta))
                                {
                                    Directory.CreateDirectory("temp/final/luma/titles/" + region + "/romfs/" + ruta);
                                }
                                File.Copy("temp/extraido/romfs/" + lista[i], "temp\\final\\luma\\titles\\" + region + "\\romfs\\" + lista[i]);
                            }
                        }
                    }
                    else if (DS.Checked || cia.Checked)
                    {
                        label2.Text = "Creando archivo .cxi modificado";
                        groupBox3.Refresh();

                        // Modifica esta variable para cambiar el nombre del archivo .3DS o .cia del juego modificado

                        string nombreJuego = "CCCI";
                        if (!Directory.Exists("temp/final"))
                        {
                            Directory.CreateDirectory("temp/final");
                        }
                        ProcessStartInfo compCXI = new ProcessStartInfo();
                        {
                            string program = "temp/3dstools.exe";
                            string arguments = "-cvtf cxi \"temp\\modificado\\" + region + ".cxi\" --header \"temp/original/ncchheader.bin\" --exh \"temp/original/exheader.bin\" --exefs \""+ rutaEXEFS + "\" --romfs \"temp/modificado/romfs.bin\" --logo \"temp/original/logo.bcma.lz\" --plain \"temp/original/plain.bin\"";
                            compCXI.FileName = program;
                            compCXI.Arguments = arguments;
                            compCXI.UseShellExecute = false;
                            compCXI.CreateNoWindow = true;
                            compCXI.ErrorDialog = false;
                            compCXI.RedirectStandardOutput = true;
                            Process x3 = Process.Start(compCXI);
                            x3.WaitForExit();
                        }
                        if (DS.Checked)
                        {
                            label2.Text = "Creando archivo 3DS final.";
                            groupBox3.Refresh();
                            ProcessStartInfo comp3DS = new ProcessStartInfo();
                            {
                                string program = "\"temp/makerom.exe\"";
                                string arguments = "-f cci -o \"temp/final/" + nombreJuego + ".3ds\" -target t -i \"temp/modificado/" + region + ".cxi\":0";
                                comp3DS.FileName = program;
                                comp3DS.Arguments = arguments;
                                comp3DS.UseShellExecute = false;
                                comp3DS.CreateNoWindow = true;
                                comp3DS.ErrorDialog = false;
                                comp3DS.RedirectStandardOutput = true;
                                Process x5 = Process.Start(comp3DS);
                                x5.WaitForExit();
                            }
                        }
                        else if (cia.Checked)
                        {
                            label2.Text = "Creando archivo CIA final.";
                            groupBox3.Refresh();
                            ProcessStartInfo compCIA = new ProcessStartInfo();
                            {
                                string program = "\"temp/makerom.exe\"";
                                string arguments = "-f cia -o temp/final/" + nombreJuego + ".cia -content temp/modificado/" + region + ".cxi:0:0";
                                compCIA.FileName = program;
                                compCIA.Arguments = arguments;
                                compCIA.UseShellExecute = false;
                                compCIA.CreateNoWindow = true;
                                compCIA.ErrorDialog = false;
                                compCIA.RedirectStandardOutput = true;
                                Process x4 = Process.Start(compCIA);
                                x4.WaitForExit();
                            }
                        }
                    }
                    label2.Text = "Proceso terminado.";
                    groupBox3.Refresh();

                    // Cambia el nombre de esta variable para la carpeta donde se guardarán los archivos 3DS, CIA y los
                    // parches luma y NTR en caso de que el usuario decida no aplicar directamente el parche a la SD.

                    string carpetaFinal = "CCCI_LJT";
                    if (luma.Checked||ntr.Checked)
                    {
                        var seleccion = MessageBox.Show("El parche se ha creado correctamente. ¿Quieres que lo apliquemos a tu juego?", "Proceso finalizado.", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        switch (seleccion)
                        {
                            case DialogResult.Yes:
                                Form2 frm = new Form2();
                                frm.Show();
                                break;
                            case DialogResult.No:    // No button pressed
                                string directorio = Directory.GetCurrentDirectory().ToString() + "/" + carpetaFinal;
                                if (Directory.Exists(directorio))
                                {
                                    Directory.Delete(directorio, true);
                                }
                                Directory.Move("temp/final", directorio);
                                Process.Start(Directory.GetCurrentDirectory().ToString() + "/" + carpetaFinal);
                                this.Close();
                                break;
                            default:                 // Neither Yes nor No pressed (just in case)
                                MessageBox.Show("¿Qué has pulsado?");
                                break;
                        }

                    }
                    else
                    {
                        string directorio = Directory.GetCurrentDirectory().ToString() + "/" + carpetaFinal;
                        if (Directory.Exists(directorio))
                        {
                            Directory.Delete(directorio, true);
                        }
                        Directory.Move("temp/final", directorio);
                        Process.Start(directorio);
                        Directory.Delete("temp", true);
                    }
                }
                else
                {
                    MessageBox.Show("Tienes que seleccionar la región de tu juego.", "Selecciona una región", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún archivo, no podrás realizar el parcheo.", "Ningún archivo seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
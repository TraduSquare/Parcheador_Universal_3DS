using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Parcheador3DS
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in allDrives)
            {
                comboBox1.Items.Add
                (new Language
                    {
                       Name = d.Name + " " + d.VolumeLabel, Value = d.Name
                    }
                );
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string directorio = Directory.GetCurrentDirectory().ToString() + "/CCCI_LJT";
            copiaFinal();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string unidad = (comboBox1.SelectedItem as Language).Value.ToString();
            DriveInfo dir = new DriveInfo(unidad);
            long tamanoDrive = dir.TotalFreeSpace;
            DirectoryInfo target = new DirectoryInfo("temp/final");
            long tamanoCarpeta = DirSize(target);
            if (tamanoDrive > tamanoCarpeta)
            {
                try
                {
                    DeepCopy(new DirectoryInfo("temp/final"), new DirectoryInfo(dir.ToString()));
                    MessageBox.Show("El parcheo se ha completado de forma satisfactoria. Disfruta del juego.", "Proceso terminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Directory.Delete("temp", true);
                    this.Close();
                    Form1 frm = new Form1();
                    frm.Close();
                }
                catch
                {
                    MessageBox.Show("Algo ha salido mal. Tendrás que aplicar el parche manualmente.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            else
            {
                MessageBox.Show("No hay espacio suficiente en la tarjeta SD. Copia el parche a la raíz de la SD manualmente después de liberar espacio.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                copiaFinal();
            }
        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            return size;
        }

        //Función que copia de forma recursiva todos los archivos dentro de la carpeta "final"

        public static void DeepCopy(DirectoryInfo source, DirectoryInfo target)
        {

            // Recursively call the DeepCopy Method for each Directory
            foreach (DirectoryInfo dir in source.GetDirectories())
                DeepCopy(dir, target.CreateSubdirectory(dir.Name));

            // Go ahead and copy each file in "source" to the "target" directory
            foreach (FileInfo file in source.GetFiles())
            {
                    file.CopyTo(Path.Combine(target.FullName, file.Name), true);
            }

        }
        private static void copiaFinal()
        {
            // Edita esta variable para cambiar el nombre de la carpeta donde se guarde el parche Luma o NTR en caso de que se cancele la copia a la SD.
            string carpetaFinal = "CCCI_LJT";
            string directorio = Directory.GetCurrentDirectory().ToString() + "/" + carpetaFinal;
            if (Directory.Exists(directorio))
            {
                Directory.Delete(directorio, true);
            }
            Directory.Move("temp/final", directorio);
            Process.Start(directorio);
            Form2 frm2 = new Form2();
            frm2.Close();
            Form1 frm = new Form1();
            frm.Close();
        }
    }
    public class Language
    {
        public string   Name { get; set; }
        public string Value { get; set; }
        public override string ToString() { return this.Name; }
    }
}

namespace Parcheador3DS
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ntr = new System.Windows.Forms.RadioButton();
            this.luma = new System.Windows.Forms.RadioButton();
            this.cia = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new System.Windows.Forms.RadioButton();
            this.Parchear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usa = new System.Windows.Forms.RadioButton();
            this.eur = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ntr
            // 
            this.ntr.AutoSize = true;
            this.ntr.Location = new System.Drawing.Point(18, 21);
            this.ntr.Margin = new System.Windows.Forms.Padding(4);
            this.ntr.Name = "ntr";
            this.ntr.Size = new System.Drawing.Size(55, 20);
            this.ntr.TabIndex = 0;
            this.ntr.Text = "NTR";
            this.ntr.UseVisualStyleBackColor = true;
            // 
            // luma
            // 
            this.luma.AutoSize = true;
            this.luma.Location = new System.Drawing.Point(260, 21);
            this.luma.Margin = new System.Windows.Forms.Padding(4);
            this.luma.Name = "luma";
            this.luma.Size = new System.Drawing.Size(59, 20);
            this.luma.TabIndex = 1;
            this.luma.Text = "Luma";
            this.luma.UseVisualStyleBackColor = true;
            // 
            // cia
            // 
            this.cia.AutoSize = true;
            this.cia.Location = new System.Drawing.Point(382, 21);
            this.cia.Margin = new System.Windows.Forms.Padding(4);
            this.cia.Name = "cia";
            this.cia.Size = new System.Drawing.Size(47, 20);
            this.cia.TabIndex = 3;
            this.cia.Text = "CIA";
            this.cia.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(499, 71);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 71);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(323, 22);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(232, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Elige el dump del juego original";
            // 
            // DS
            // 
            this.DS.AutoSize = true;
            this.DS.Location = new System.Drawing.Point(136, 21);
            this.DS.Margin = new System.Windows.Forms.Padding(4);
            this.DS.Name = "DS";
            this.DS.Size = new System.Drawing.Size(52, 20);
            this.DS.TabIndex = 8;
            this.DS.Text = "3DS";
            this.DS.UseVisualStyleBackColor = true;
            // 
            // Parchear
            // 
            this.Parchear.BackColor = System.Drawing.Color.DarkSlateGray;
            this.Parchear.ForeColor = System.Drawing.Color.White;
            this.Parchear.Location = new System.Drawing.Point(253, 350);
            this.Parchear.Margin = new System.Windows.Forms.Padding(4);
            this.Parchear.Name = "Parchear";
            this.Parchear.Size = new System.Drawing.Size(183, 34);
            this.Parchear.TabIndex = 9;
            this.Parchear.Text = "Comenzar el parcheo";
            this.Parchear.UseVisualStyleBackColor = false;
            this.Parchear.Click += new System.EventHandler(this.Parchear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.DS);
            this.groupBox1.Controls.Add(this.ntr);
            this.groupBox1.Controls.Add(this.luma);
            this.groupBox1.Controls.Add(this.cia);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(117, 122);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(448, 49);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formato de salida del parche";
            // 
            // usa
            // 
            this.usa.AutoSize = true;
            this.usa.Location = new System.Drawing.Point(330, 20);
            this.usa.Margin = new System.Windows.Forms.Padding(4);
            this.usa.Name = "usa";
            this.usa.Size = new System.Drawing.Size(54, 20);
            this.usa.TabIndex = 3;
            this.usa.Text = "USA";
            this.usa.UseVisualStyleBackColor = true;
            // 
            // eur
            // 
            this.eur.AutoSize = true;
            this.eur.Location = new System.Drawing.Point(190, 20);
            this.eur.Margin = new System.Windows.Forms.Padding(4);
            this.eur.Name = "eur";
            this.eur.Size = new System.Drawing.Size(55, 20);
            this.eur.TabIndex = 0;
            this.eur.Text = "EUR";
            this.eur.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.eur);
            this.groupBox2.Controls.Add(this.usa);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(117, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(448, 49);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edición del juego";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Black;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(117, 234);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(448, 100);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progreso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Rellena los campos para comenzar.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(590, 320);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 98);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(27, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Región única";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(702, 429);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Parchear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Parcheador Universal 3DS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ntr;
        private System.Windows.Forms.RadioButton luma;
        private System.Windows.Forms.RadioButton cia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton DS;
        private System.Windows.Forms.Button Parchear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton usa;
        private System.Windows.Forms.RadioButton eur;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}


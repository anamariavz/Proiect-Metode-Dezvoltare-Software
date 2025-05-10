namespace MonitorizareSol
{
    partial class Pagina_Principala
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagina_Principala));
            this.button1 = new System.Windows.Forms.Button();
            this.B_Refesh = new System.Windows.Forms.Button();
            this.B_Salvare = new System.Windows.Forms.Button();
            this.B_Verificare = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Umiditate = new System.Windows.Forms.TextBox();
            this.Nivel_de_Hidratare = new System.Windows.Forms.TextBox();
            this.Temperatura = new System.Windows.Forms.TextBox();
            this.afisajTemperatura = new System.Windows.Forms.Label();
            this.afisajUmiditate = new System.Windows.Forms.Label();
            this.nivelHidratare = new System.Windows.Forms.Label();
            this.Plante_Recomadate_Titlu = new System.Windows.Forms.Label();
            this.ExportPDF = new System.Windows.Forms.Button();
            this.Titlu = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.afisPlante = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkKhaki;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(540, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Conectare";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // B_Refesh
            // 
            this.B_Refesh.BackColor = System.Drawing.Color.LightYellow;
            this.B_Refesh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Refesh.Location = new System.Drawing.Point(115, 304);
            this.B_Refesh.Name = "B_Refesh";
            this.B_Refesh.Size = new System.Drawing.Size(105, 35);
            this.B_Refesh.TabIndex = 1;
            this.B_Refesh.Text = "Refresh";
            this.B_Refesh.UseVisualStyleBackColor = false;
            this.B_Refesh.Click += new System.EventHandler(this.B_Refesh_Click);
            // 
            // B_Salvare
            // 
            this.B_Salvare.BackColor = System.Drawing.Color.LightYellow;
            this.B_Salvare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Salvare.Location = new System.Drawing.Point(346, 306);
            this.B_Salvare.Name = "B_Salvare";
            this.B_Salvare.Size = new System.Drawing.Size(106, 33);
            this.B_Salvare.TabIndex = 2;
            this.B_Salvare.Text = "Salvare";
            this.B_Salvare.UseVisualStyleBackColor = false;
            this.B_Salvare.Click += new System.EventHandler(this.B_Salvare_Click);
            // 
            // B_Verificare
            // 
            this.B_Verificare.BackColor = System.Drawing.Color.LightYellow;
            this.B_Verificare.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B_Verificare.Location = new System.Drawing.Point(594, 308);
            this.B_Verificare.Name = "B_Verificare";
            this.B_Verificare.Size = new System.Drawing.Size(115, 31);
            this.B_Verificare.TabIndex = 3;
            this.B_Verificare.Text = "Verificare";
            this.B_Verificare.UseVisualStyleBackColor = false;
            this.B_Verificare.Click += new System.EventHandler(this.B_Verificare_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COM3",
            "COM4",
            "COM5"});
            this.comboBox1.Location = new System.Drawing.Point(285, 94);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Text = "COM3";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Umiditate
            // 
            this.Umiditate.Location = new System.Drawing.Point(157, 200);
            this.Umiditate.Name = "Umiditate";
            this.Umiditate.ReadOnly = true;
            this.Umiditate.Size = new System.Drawing.Size(151, 26);
            this.Umiditate.TabIndex = 5;
            this.Umiditate.Text = "Umiditatea";
            this.Umiditate.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Nivel_de_Hidratare
            // 
            this.Nivel_de_Hidratare.Location = new System.Drawing.Point(157, 232);
            this.Nivel_de_Hidratare.Name = "Nivel_de_Hidratare";
            this.Nivel_de_Hidratare.ReadOnly = true;
            this.Nivel_de_Hidratare.Size = new System.Drawing.Size(151, 26);
            this.Nivel_de_Hidratare.TabIndex = 6;
            this.Nivel_de_Hidratare.Text = "Nivelul de Hidratare";
            // 
            // Temperatura
            // 
            this.Temperatura.Location = new System.Drawing.Point(157, 168);
            this.Temperatura.Name = "Temperatura";
            this.Temperatura.ReadOnly = true;
            this.Temperatura.Size = new System.Drawing.Size(151, 26);
            this.Temperatura.TabIndex = 7;
            this.Temperatura.Text = "Temperatura";
            this.Temperatura.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // afisajTemperatura
            // 
            this.afisajTemperatura.AutoSize = true;
            this.afisajTemperatura.Location = new System.Drawing.Point(369, 174);
            this.afisajTemperatura.Name = "afisajTemperatura";
            this.afisajTemperatura.Size = new System.Drawing.Size(51, 20);
            this.afisajTemperatura.TabIndex = 8;
            this.afisajTemperatura.Text = "label1";
            // 
            // afisajUmiditate
            // 
            this.afisajUmiditate.AutoSize = true;
            this.afisajUmiditate.Location = new System.Drawing.Point(369, 206);
            this.afisajUmiditate.Name = "afisajUmiditate";
            this.afisajUmiditate.Size = new System.Drawing.Size(51, 20);
            this.afisajUmiditate.TabIndex = 9;
            this.afisajUmiditate.Text = "label2";
            // 
            // nivelHidratare
            // 
            this.nivelHidratare.AutoSize = true;
            this.nivelHidratare.Location = new System.Drawing.Point(369, 238);
            this.nivelHidratare.Name = "nivelHidratare";
            this.nivelHidratare.Size = new System.Drawing.Size(51, 20);
            this.nivelHidratare.TabIndex = 10;
            this.nivelHidratare.Text = "label3";
            // 
            // Plante_Recomadate_Titlu
            // 
            this.Plante_Recomadate_Titlu.AutoSize = true;
            this.Plante_Recomadate_Titlu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Plante_Recomadate_Titlu.Location = new System.Drawing.Point(107, 362);
            this.Plante_Recomadate_Titlu.Name = "Plante_Recomadate_Titlu";
            this.Plante_Recomadate_Titlu.Size = new System.Drawing.Size(313, 22);
            this.Plante_Recomadate_Titlu.TabIndex = 11;
            this.Plante_Recomadate_Titlu.Text = "Plante recomandate pentru acest sol";
            this.Plante_Recomadate_Titlu.Click += new System.EventHandler(this.label4_Click);
            // 
            // ExportPDF
            // 
            this.ExportPDF.Location = new System.Drawing.Point(511, 541);
            this.ExportPDF.Name = "ExportPDF";
            this.ExportPDF.Size = new System.Drawing.Size(266, 39);
            this.ExportPDF.TabIndex = 12;
            this.ExportPDF.Text = "Exporta Raportul ca PDF";
            this.ExportPDF.UseVisualStyleBackColor = true;
            this.ExportPDF.Click += new System.EventHandler(this.ExportPDF_Click);
            // 
            // Titlu
            // 
            this.Titlu.AutoSize = true;
            this.Titlu.Font = new System.Drawing.Font("Segoe MDL2 Assets", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlu.ForeColor = System.Drawing.Color.DarkGreen;
            this.Titlu.Location = new System.Drawing.Point(210, 9);
            this.Titlu.Name = "Titlu";
            this.Titlu.Size = new System.Drawing.Size(380, 48);
            this.Titlu.TabIndex = 13;
            this.Titlu.Text = "Monitorizarea Solului";
            this.Titlu.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(111, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Port:";
            // 
            // afisPlante
            // 
            this.afisPlante.AutoSize = true;
            this.afisPlante.Location = new System.Drawing.Point(122, 403);
            this.afisPlante.Name = "afisPlante";
            this.afisPlante.Size = new System.Drawing.Size(51, 20);
            this.afisPlante.TabIndex = 15;
            this.afisPlante.Text = "label7";
            // 
            // Pagina_Principala
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(800, 592);
            this.Controls.Add(this.afisPlante);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Titlu);
            this.Controls.Add(this.ExportPDF);
            this.Controls.Add(this.Plante_Recomadate_Titlu);
            this.Controls.Add(this.nivelHidratare);
            this.Controls.Add(this.afisajUmiditate);
            this.Controls.Add(this.afisajTemperatura);
            this.Controls.Add(this.Temperatura);
            this.Controls.Add(this.Nivel_de_Hidratare);
            this.Controls.Add(this.Umiditate);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.B_Verificare);
            this.Controls.Add(this.B_Salvare);
            this.Controls.Add(this.B_Refesh);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pagina_Principala";
            this.Text = "Monitorizarea Solului";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button B_Refesh;
        private System.Windows.Forms.Button B_Salvare;
        private System.Windows.Forms.Button B_Verificare;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox Umiditate;
        private System.Windows.Forms.TextBox Nivel_de_Hidratare;
        private System.Windows.Forms.TextBox Temperatura;
        private System.Windows.Forms.Label afisajTemperatura;
        private System.Windows.Forms.Label afisajUmiditate;
        private System.Windows.Forms.Label nivelHidratare;
        private System.Windows.Forms.Label Plante_Recomadate_Titlu;
        private System.Windows.Forms.Button ExportPDF;
        private System.Windows.Forms.Label Titlu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label afisPlante;
    }
}


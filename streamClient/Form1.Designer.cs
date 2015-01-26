namespace streamClient
{
    partial class Form1
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
            this.inicio = new System.Windows.Forms.Button();
            this.lento = new System.Windows.Forms.Button();
            this.normal = new System.Windows.Forms.Button();
            this.rapido = new System.Windows.Forms.Button();
            this.velocidad = new System.Windows.Forms.Label();
            this.puerto = new System.Windows.Forms.Label();
            this.numeroPuerto = new System.Windows.Forms.TextBox();
            this.pantalla = new System.Windows.Forms.PictureBox();
            this.buffer = new System.Windows.Forms.ListBox();
            this.TB_red = new System.Windows.Forms.TextBox();
            this.red = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pantalla)).BeginInit();
            this.SuspendLayout();
            // 
            // inicio
            // 
            this.inicio.Location = new System.Drawing.Point(24, 9);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(75, 23);
            this.inicio.TabIndex = 0;
            this.inicio.Text = "Inicio";
            this.inicio.UseVisualStyleBackColor = true;
            this.inicio.Click += new System.EventHandler(this.inicio_Click);
            // 
            // lento
            // 
            this.lento.Location = new System.Drawing.Point(24, 51);
            this.lento.Name = "lento";
            this.lento.Size = new System.Drawing.Size(75, 23);
            this.lento.TabIndex = 1;
            this.lento.Text = "Lento";
            this.lento.UseVisualStyleBackColor = true;
            this.lento.Click += new System.EventHandler(this.lento_Click);
            // 
            // normal
            // 
            this.normal.Location = new System.Drawing.Point(24, 81);
            this.normal.Name = "normal";
            this.normal.Size = new System.Drawing.Size(75, 23);
            this.normal.TabIndex = 2;
            this.normal.Text = "Normal";
            this.normal.UseVisualStyleBackColor = true;
            this.normal.Click += new System.EventHandler(this.normal_Click);
            // 
            // rapido
            // 
            this.rapido.Location = new System.Drawing.Point(24, 111);
            this.rapido.Name = "rapido";
            this.rapido.Size = new System.Drawing.Size(75, 23);
            this.rapido.TabIndex = 3;
            this.rapido.Text = "Rapido";
            this.rapido.UseVisualStyleBackColor = true;
            this.rapido.Click += new System.EventHandler(this.rapido_Click);
            // 
            // velocidad
            // 
            this.velocidad.AutoSize = true;
            this.velocidad.Location = new System.Drawing.Point(35, 35);
            this.velocidad.Name = "velocidad";
            this.velocidad.Size = new System.Drawing.Size(54, 13);
            this.velocidad.TabIndex = 4;
            this.velocidad.Text = "Velocidad";
            // 
            // puerto
            // 
            this.puerto.AutoSize = true;
            this.puerto.Location = new System.Drawing.Point(16, 181);
            this.puerto.Name = "puerto";
            this.puerto.Size = new System.Drawing.Size(38, 13);
            this.puerto.TabIndex = 5;
            this.puerto.Text = "Puerto";
            // 
            // numeroPuerto
            // 
            this.numeroPuerto.Location = new System.Drawing.Point(13, 197);
            this.numeroPuerto.Name = "numeroPuerto";
            this.numeroPuerto.Size = new System.Drawing.Size(100, 20);
            this.numeroPuerto.TabIndex = 6;
            this.numeroPuerto.Text = "50000";
            // 
            // pantalla
            // 
            this.pantalla.Image = global::streamServer.Properties.Resources.cargando2;
            this.pantalla.Location = new System.Drawing.Point(116, 11);
            this.pantalla.Name = "pantalla";
            this.pantalla.Size = new System.Drawing.Size(350, 200);
            this.pantalla.TabIndex = 7;
            this.pantalla.TabStop = false;
            // 
            // buffer
            // 
            this.buffer.FormattingEnabled = true;
            this.buffer.Location = new System.Drawing.Point(472, 4);
            this.buffer.Name = "buffer";
            this.buffer.Size = new System.Drawing.Size(205, 212);
            this.buffer.TabIndex = 8;
            this.buffer.SelectedIndexChanged += new System.EventHandler(this.buffer_SelectedIndexChanged);
            // 
            // TB_red
            // 
            this.TB_red.Location = new System.Drawing.Point(13, 158);
            this.TB_red.Name = "TB_red";
            this.TB_red.Size = new System.Drawing.Size(100, 20);
            this.TB_red.TabIndex = 9;
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Location = new System.Drawing.Point(16, 142);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(65, 13);
            this.red.TabIndex = 10;
            this.red.Text = "Direccion IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 224);
            this.Controls.Add(this.red);
            this.Controls.Add(this.TB_red);
            this.Controls.Add(this.buffer);
            this.Controls.Add(this.pantalla);
            this.Controls.Add(this.numeroPuerto);
            this.Controls.Add(this.puerto);
            this.Controls.Add(this.velocidad);
            this.Controls.Add(this.rapido);
            this.Controls.Add(this.normal);
            this.Controls.Add(this.lento);
            this.Controls.Add(this.inicio);
            this.Name = "Form1";
            this.Text = "Cliente";
            ((System.ComponentModel.ISupportInitialize)(this.pantalla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.Button lento;
        private System.Windows.Forms.Button normal;
        private System.Windows.Forms.Button rapido;
        private System.Windows.Forms.Label velocidad;
        private System.Windows.Forms.Label puerto;
        private System.Windows.Forms.TextBox numeroPuerto;
        private System.Windows.Forms.PictureBox pantalla;
        private System.Windows.Forms.ListBox buffer;
        private System.Windows.Forms.TextBox TB_red;
        private System.Windows.Forms.Label red;
    }
}


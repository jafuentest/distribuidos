namespace streamServer
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
            this.procesos = new System.Windows.Forms.ListBox();
            this.puerto = new System.Windows.Forms.Label();
            this.numeroPuerto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inicio
            // 
            this.inicio.Location = new System.Drawing.Point(66, 13);
            this.inicio.Name = "inicio";
            this.inicio.Size = new System.Drawing.Size(75, 23);
            this.inicio.TabIndex = 0;
            this.inicio.Text = "Iniciar";
            this.inicio.UseVisualStyleBackColor = true;
            this.inicio.Click += new System.EventHandler(this.inicio_Click);
            // 
            // procesos
            // 
            this.procesos.FormattingEnabled = true;
            this.procesos.Location = new System.Drawing.Point(18, 45);
            this.procesos.Name = "procesos";
            this.procesos.Size = new System.Drawing.Size(331, 225);
            this.procesos.TabIndex = 1;
            // 
            // puerto
            // 
            this.puerto.AutoSize = true;
            this.puerto.Location = new System.Drawing.Point(161, 18);
            this.puerto.Name = "puerto";
            this.puerto.Size = new System.Drawing.Size(38, 13);
            this.puerto.TabIndex = 2;
            this.puerto.Text = "Puerto";
            // 
            // numeroPuerto
            // 
            this.numeroPuerto.Location = new System.Drawing.Point(205, 13);
            this.numeroPuerto.Name = "numeroPuerto";
            this.numeroPuerto.Size = new System.Drawing.Size(100, 20);
            this.numeroPuerto.TabIndex = 3;
            this.numeroPuerto.Text = "50000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 280);
            this.Controls.Add(this.numeroPuerto);
            this.Controls.Add(this.puerto);
            this.Controls.Add(this.procesos);
            this.Controls.Add(this.inicio);
            this.Name = "Form1";
            this.Text = "Servidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.ListBox procesos;
        private System.Windows.Forms.Label puerto;
        private System.Windows.Forms.TextBox numeroPuerto;
    }
}


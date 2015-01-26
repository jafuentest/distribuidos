namespace streamServer
{
    partial class Ventana
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
            this.lab_puertoTCP = new System.Windows.Forms.Label();
            this.puertoTCP = new System.Windows.Forms.TextBox();
            this.puertoUDP = new System.Windows.Forms.TextBox();
            this.lab_puertoUDP = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inicio
            // 
            this.inicio.Location = new System.Drawing.Point(12, 12);
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
            this.procesos.Location = new System.Drawing.Point(12, 43);
            this.procesos.Name = "procesos";
            this.procesos.Size = new System.Drawing.Size(345, 225);
            this.procesos.TabIndex = 1;
            // 
            // lab_puertoTCP
            // 
            this.lab_puertoTCP.AutoSize = true;
            this.lab_puertoTCP.Location = new System.Drawing.Point(122, 17);
            this.lab_puertoTCP.Name = "lab_puertoTCP";
            this.lab_puertoTCP.Size = new System.Drawing.Size(59, 13);
            this.lab_puertoTCP.TabIndex = 2;
            this.lab_puertoTCP.Text = "PuertoTCP";
            // 
            // puertoTCP
            // 
            this.puertoTCP.Location = new System.Drawing.Point(187, 14);
            this.puertoTCP.Name = "puertoTCP";
            this.puertoTCP.Size = new System.Drawing.Size(38, 20);
            this.puertoTCP.TabIndex = 3;
            this.puertoTCP.Text = "5000";
            // 
            // puertoUDP
            // 
            this.puertoUDP.Location = new System.Drawing.Point(320, 14);
            this.puertoUDP.Name = "puertoUDP";
            this.puertoUDP.Size = new System.Drawing.Size(38, 20);
            this.puertoUDP.TabIndex = 5;
            this.puertoUDP.Text = "5001";
            // 
            // lab_puertoUDP
            // 
            this.lab_puertoUDP.AutoSize = true;
            this.lab_puertoUDP.Location = new System.Drawing.Point(255, 17);
            this.lab_puertoUDP.Name = "lab_puertoUDP";
            this.lab_puertoUDP.Size = new System.Drawing.Size(59, 13);
            this.lab_puertoUDP.TabIndex = 4;
            this.lab_puertoUDP.Text = "PuertoTCP";
            // 
            // Ventana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 280);
            this.Controls.Add(this.puertoUDP);
            this.Controls.Add(this.lab_puertoUDP);
            this.Controls.Add(this.puertoTCP);
            this.Controls.Add(this.lab_puertoTCP);
            this.Controls.Add(this.procesos);
            this.Controls.Add(this.inicio);
            this.Name = "Ventana";
            this.Text = "Servidor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button inicio;
        private System.Windows.Forms.ListBox procesos;
        private System.Windows.Forms.Label lab_puertoTCP;
        private System.Windows.Forms.TextBox puertoTCP;
        private System.Windows.Forms.TextBox puertoUDP;
        private System.Windows.Forms.Label lab_puertoUDP;
    }
}


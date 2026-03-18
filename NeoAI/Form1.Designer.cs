namespace NeoAI
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
			this.label3 = new System.Windows.Forms.Label();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnEntrenar = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblProyecto = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnResolver = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.lblMatrixDescription = new System.Windows.Forms.Label();
			this.panelProblema = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbTop = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.idsolicitud = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBuscar = new System.Windows.Forms.Button();
			this.pMora = new System.Windows.Forms.TextBox();
			this.pJuridico = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(428, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 15);
			this.label3.TabIndex = 7;
			this.label3.Text = "Problema a resolver";
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(9, 224);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(128, 23);
			this.btnAgregar.TabIndex = 12;
			this.btnAgregar.Text = "2 - Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnEntrenar
			// 
			this.btnEntrenar.Location = new System.Drawing.Point(9, 253);
			this.btnEntrenar.Name = "btnEntrenar";
			this.btnEntrenar.Size = new System.Drawing.Size(128, 23);
			this.btnEntrenar.TabIndex = 13;
			this.btnEntrenar.Text = "3 - Entrenar";
			this.btnEntrenar.UseVisualStyleBackColor = true;
			this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(9, 197);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(128, 23);
			this.btnReset.TabIndex = 30;
			this.btnReset.Text = "1 - Reinicializar";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(412, -1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(10, 784);
			this.pictureBox1.TabIndex = 34;
			this.pictureBox1.TabStop = false;
			// 
			// lblProyecto
			// 
			this.lblProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblProyecto.Location = new System.Drawing.Point(9, 25);
			this.lblProyecto.Name = "lblProyecto";
			this.lblProyecto.Size = new System.Drawing.Size(394, 30);
			this.lblProyecto.TabIndex = 35;
			this.lblProyecto.Text = "...";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(6, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(191, 15);
			this.label2.TabIndex = 36;
			this.label2.Text = "Especificaciones del modelo";
			// 
			// btnResolver
			// 
			this.btnResolver.Location = new System.Drawing.Point(9, 282);
			this.btnResolver.Name = "btnResolver";
			this.btnResolver.Size = new System.Drawing.Size(128, 23);
			this.btnResolver.TabIndex = 40;
			this.btnResolver.Text = "Resolver";
			this.btnResolver.UseVisualStyleBackColor = true;
			this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(6, 137);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(168, 15);
			this.label12.TabIndex = 43;
			this.label12.Text = "Preparaciones generales";
			// 
			// lblMatrixDescription
			// 
			this.lblMatrixDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblMatrixDescription.Location = new System.Drawing.Point(9, 59);
			this.lblMatrixDescription.Name = "lblMatrixDescription";
			this.lblMatrixDescription.Size = new System.Drawing.Size(394, 78);
			this.lblMatrixDescription.TabIndex = 45;
			this.lblMatrixDescription.Text = "...";
			// 
			// panelProblema
			// 
			this.panelProblema.Location = new System.Drawing.Point(431, 72);
			this.panelProblema.Name = "panelProblema";
			this.panelProblema.Size = new System.Drawing.Size(231, 605);
			this.panelProblema.TabIndex = 46;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 154);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 48;
			this.label4.Text = "Tamaño";
			// 
			// cmbTop
			// 
			this.cmbTop.FormattingEnabled = true;
			this.cmbTop.Location = new System.Drawing.Point(9, 170);
			this.cmbTop.Name = "cmbTop";
			this.cmbTop.Size = new System.Drawing.Size(128, 21);
			this.cmbTop.TabIndex = 47;
			this.cmbTop.SelectedIndexChanged += new System.EventHandler(this.cmbTop_SelectedIndexChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(0, 0);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 0;
			// 
			// idsolicitud
			// 
			this.idsolicitud.Location = new System.Drawing.Point(431, 46);
			this.idsolicitud.Name = "idsolicitud";
			this.idsolicitud.Size = new System.Drawing.Size(67, 20);
			this.idsolicitud.TabIndex = 51;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(428, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 52;
			this.label1.Text = "Id solicitud";
			// 
			// btnBuscar
			// 
			this.btnBuscar.Location = new System.Drawing.Point(504, 45);
			this.btnBuscar.Name = "btnBuscar";
			this.btnBuscar.Size = new System.Drawing.Size(74, 21);
			this.btnBuscar.TabIndex = 53;
			this.btnBuscar.Text = "Buscar";
			this.btnBuscar.UseVisualStyleBackColor = true;
			this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
			// 
			// pMora
			// 
			this.pMora.Location = new System.Drawing.Point(584, 45);
			this.pMora.Name = "pMora";
			this.pMora.Size = new System.Drawing.Size(21, 20);
			this.pMora.TabIndex = 54;
			// 
			// pJuridico
			// 
			this.pJuridico.Location = new System.Drawing.Point(611, 45);
			this.pJuridico.Name = "pJuridico";
			this.pJuridico.Size = new System.Drawing.Size(21, 20);
			this.pJuridico.TabIndex = 55;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(581, 30);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(16, 13);
			this.label6.TabIndex = 56;
			this.label6.Text = "M";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(608, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(12, 13);
			this.label7.TabIndex = 57;
			this.label7.Text = "J";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 682);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pJuridico);
			this.Controls.Add(this.pMora);
			this.Controls.Add(this.btnBuscar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.idsolicitud);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbTop);
			this.Controls.Add(this.panelProblema);
			this.Controls.Add(this.lblMatrixDescription);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.btnResolver);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblProyecto);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.btnEntrenar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "NeodataIA-Prospección";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMatrixDescription;
        private System.Windows.Forms.Panel panelProblema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTop;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox idsolicitud;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBuscar;
		private System.Windows.Forms.TextBox pMora;
		private System.Windows.Forms.TextBox pJuridico;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}


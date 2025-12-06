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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEntrenar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbProyecto = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbPreguntas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProyecto = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblResponse = new System.Windows.Forms.Label();
            this.btnResolver = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMatrixDescription = new System.Windows.Forms.Label();
            this.panelProblema = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTop = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRestriccion = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(9, 394);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(394, 199);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(428, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Problema a resolver";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(9, 320);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(394, 23);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar vinculados a la pregunta activa";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEntrenar
            // 
            this.btnEntrenar.Location = new System.Drawing.Point(9, 349);
            this.btnEntrenar.Name = "btnEntrenar";
            this.btnEntrenar.Size = new System.Drawing.Size(394, 23);
            this.btnEntrenar.TabIndex = 13;
            this.btnEntrenar.Text = "Entrenar para la pregunta activa";
            this.btnEntrenar.UseVisualStyleBackColor = true;
            this.btnEntrenar.Click += new System.EventHandler(this.btnEntrenar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Proyecto";
            // 
            // cmbProyecto
            // 
            this.cmbProyecto.FormattingEnabled = true;
            this.cmbProyecto.Location = new System.Drawing.Point(9, 50);
            this.cmbProyecto.Name = "cmbProyecto";
            this.cmbProyecto.Size = new System.Drawing.Size(231, 21);
            this.cmbProyecto.TabIndex = 28;
            this.cmbProyecto.SelectedIndexChanged += new System.EventHandler(this.cmbProyecto_SelectedIndexChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(246, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(157, 23);
            this.btnReset.TabIndex = 30;
            this.btnReset.Text = "Reinicializar proyecto";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Pregunta activa";
            // 
            // cmbPreguntas
            // 
            this.cmbPreguntas.FormattingEnabled = true;
            this.cmbPreguntas.Location = new System.Drawing.Point(9, 240);
            this.cmbPreguntas.Name = "cmbPreguntas";
            this.cmbPreguntas.Size = new System.Drawing.Size(394, 21);
            this.cmbPreguntas.TabIndex = 31;
            this.cmbPreguntas.SelectedIndexChanged += new System.EventHandler(this.cmbPreguntas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Valores entrenados";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(412, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 673);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // lblProyecto
            // 
            this.lblProyecto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProyecto.Location = new System.Drawing.Point(9, 74);
            this.lblProyecto.Name = "lblProyecto";
            this.lblProyecto.Size = new System.Drawing.Size(394, 30);
            this.lblProyecto.TabIndex = 35;
            this.lblProyecto.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Especificaciones del modelo";
            // 
            // lblResponse
            // 
            this.lblResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblResponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResponse.Location = new System.Drawing.Point(431, 562);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(231, 30);
            this.lblResponse.TabIndex = 38;
            this.lblResponse.Text = "...";
            this.lblResponse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnResolver
            // 
            this.btnResolver.Location = new System.Drawing.Point(430, 536);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(232, 23);
            this.btnResolver.TabIndex = 40;
            this.btnResolver.Text = "Resolver";
            this.btnResolver.UseVisualStyleBackColor = true;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 201);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 43;
            this.label12.Text = "Sesgo de control";
            // 
            // lblMatrixDescription
            // 
            this.lblMatrixDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMatrixDescription.Location = new System.Drawing.Point(9, 113);
            this.lblMatrixDescription.Name = "lblMatrixDescription";
            this.lblMatrixDescription.Size = new System.Drawing.Size(394, 78);
            this.lblMatrixDescription.TabIndex = 45;
            this.lblMatrixDescription.Text = "...";
            // 
            // panelProblema
            // 
            this.panelProblema.Location = new System.Drawing.Point(431, 48);
            this.panelProblema.Name = "panelProblema";
            this.panelProblema.Size = new System.Drawing.Size(231, 482);
            this.panelProblema.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Tamaño de la muestra";
            // 
            // cmbTop
            // 
            this.cmbTop.FormattingEnabled = true;
            this.cmbTop.Location = new System.Drawing.Point(9, 281);
            this.cmbTop.Name = "cmbTop";
            this.cmbTop.Size = new System.Drawing.Size(128, 21);
            this.cmbTop.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Restricción de la muestra";
            // 
            // cmbRestriccion
            // 
            this.cmbRestriccion.FormattingEnabled = true;
            this.cmbRestriccion.Location = new System.Drawing.Point(162, 281);
            this.cmbRestriccion.Name = "cmbRestriccion";
            this.cmbRestriccion.Size = new System.Drawing.Size(241, 21);
            this.cmbRestriccion.TabIndex = 49;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 602);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRestriccion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTop);
            this.Controls.Add(this.panelProblema);
            this.Controls.Add(this.lblMatrixDescription);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnResolver);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblProyecto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbPreguntas);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbProyecto);
            this.Controls.Add(this.btnEntrenar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NeoAI";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEntrenar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbProyecto;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPreguntas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblProyecto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblMatrixDescription;
        private System.Windows.Forms.Panel panelProblema;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRestriccion;
    }
}


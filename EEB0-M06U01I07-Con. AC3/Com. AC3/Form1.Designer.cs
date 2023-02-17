namespace Com.AC3
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btOff = new System.Windows.Forms.Button();
            this.btOn = new System.Windows.Forms.Button();
            this.btDisonect = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.btConect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // btOff
            // 
            this.btOff.Location = new System.Drawing.Point(510, 125);
            this.btOff.Name = "btOff";
            this.btOff.Size = new System.Drawing.Size(75, 75);
            this.btOff.TabIndex = 0;
            this.btOff.Text = "button1";
            this.btOff.UseVisualStyleBackColor = true;
            // 
            // btOn
            // 
            this.btOn.Location = new System.Drawing.Point(429, 125);
            this.btOn.Name = "btOn";
            this.btOn.Size = new System.Drawing.Size(75, 75);
            this.btOn.TabIndex = 1;
            this.btOn.Text = "button2";
            this.btOn.UseVisualStyleBackColor = true;
            // 
            // btDisonect
            // 
            this.btDisonect.Location = new System.Drawing.Point(429, 44);
            this.btDisonect.Name = "btDisonect";
            this.btDisonect.Size = new System.Drawing.Size(156, 75);
            this.btDisonect.TabIndex = 2;
            this.btDisonect.Text = "button3";
            this.btDisonect.UseVisualStyleBackColor = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(429, 206);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(156, 56);
            this.trackBar1.TabIndex = 3;
            // 
            // btConect
            // 
            this.btConect.Location = new System.Drawing.Point(429, 44);
            this.btConect.Name = "btConect";
            this.btConect.Size = new System.Drawing.Size(156, 75);
            this.btConect.TabIndex = 4;
            this.btConect.Text = "button4";
            this.btConect.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 498);
            this.Controls.Add(this.btConect);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.btDisonect);
            this.Controls.Add(this.btOn);
            this.Controls.Add(this.btOff);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOff;
        private System.Windows.Forms.Button btOn;
        private System.Windows.Forms.Button btDisonect;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btConect;
    }
}


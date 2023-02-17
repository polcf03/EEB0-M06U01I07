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
            this.btRight = new System.Windows.Forms.Button();
            this.btOLeft = new System.Windows.Forms.Button();
            this.btStrStp = new System.Windows.Forms.Button();
            this.trbVelocity = new System.Windows.Forms.TrackBar();
            this.btConDis = new System.Windows.Forms.Button();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbVelocity)).BeginInit();
            this.SuspendLayout();
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(107, 93);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(69, 75);
            this.btRight.TabIndex = 0;
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btOLeft
            // 
            this.btOLeft.Location = new System.Drawing.Point(12, 93);
            this.btOLeft.Name = "btOLeft";
            this.btOLeft.Size = new System.Drawing.Size(75, 75);
            this.btOLeft.TabIndex = 1;
            this.btOLeft.UseVisualStyleBackColor = true;
            this.btOLeft.Click += new System.EventHandler(this.btOLeft_Click);
            // 
            // btStrStp
            // 
            this.btStrStp.Location = new System.Drawing.Point(12, 12);
            this.btStrStp.Name = "btStrStp";
            this.btStrStp.Size = new System.Drawing.Size(164, 75);
            this.btStrStp.TabIndex = 2;
            this.btStrStp.UseVisualStyleBackColor = true;
            this.btStrStp.Click += new System.EventHandler(this.btStrStp_Click);
            // 
            // trbVelocity
            // 
            this.trbVelocity.Location = new System.Drawing.Point(12, 219);
            this.trbVelocity.Maximum = 100;
            this.trbVelocity.Name = "trbVelocity";
            this.trbVelocity.Size = new System.Drawing.Size(164, 56);
            this.trbVelocity.TabIndex = 3;
            this.trbVelocity.TickFrequency = 10;
            this.trbVelocity.ValueChanged += new System.EventHandler(this.trbVelocity_ValueChanged);
            // 
            // btConDis
            // 
            this.btConDis.Location = new System.Drawing.Point(12, 411);
            this.btConDis.Name = "btConDis";
            this.btConDis.Size = new System.Drawing.Size(156, 75);
            this.btConDis.TabIndex = 5;
            this.btConDis.UseVisualStyleBackColor = true;
            this.btConDis.Click += new System.EventHandler(this.btConDis_Click);
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(12, 191);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(164, 22);
            this.txtVelocity.TabIndex = 6;
            this.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVelocity.TextChanged += new System.EventHandler(this.txtVelocity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Velocity";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(104, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "%";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 498);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVelocity);
            this.Controls.Add(this.btConDis);
            this.Controls.Add(this.trbVelocity);
            this.Controls.Add(this.btStrStp);
            this.Controls.Add(this.btOLeft);
            this.Controls.Add(this.btRight);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trbVelocity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btOLeft;
        private System.Windows.Forms.Button btStrStp;
        private System.Windows.Forms.TrackBar trbVelocity;
        private System.Windows.Forms.Button btConDis;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


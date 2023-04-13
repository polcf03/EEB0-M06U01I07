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
            this.components = new System.ComponentModel.Container();
            this.btRight = new System.Windows.Forms.Button();
            this.btLeft = new System.Windows.Forms.Button();
            this.btStrStp = new System.Windows.Forms.Button();
            this.trbVelocity = new System.Windows.Forms.TrackBar();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prbFeedback = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FeedbackTimer = new System.Windows.Forms.Timer(this.components);
            this.btVel = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conexionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notepadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trbVelocity)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(95, 113);
            this.btRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(84, 75);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "Right";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(15, 113);
            this.btLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(75, 75);
            this.btLeft.TabIndex = 1;
            this.btLeft.Text = "Left";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btStrStp
            // 
            this.btStrStp.Location = new System.Drawing.Point(15, 33);
            this.btStrStp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btStrStp.Name = "btStrStp";
            this.btStrStp.Size = new System.Drawing.Size(164, 75);
            this.btStrStp.TabIndex = 2;
            this.btStrStp.Text = "ON";
            this.btStrStp.UseVisualStyleBackColor = true;
            this.btStrStp.Click += new System.EventHandler(this.btStrStp_Click);
            // 
            // trbVelocity
            // 
            this.trbVelocity.Location = new System.Drawing.Point(12, 239);
            this.trbVelocity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trbVelocity.Maximum = 100;
            this.trbVelocity.Name = "trbVelocity";
            this.trbVelocity.Size = new System.Drawing.Size(164, 56);
            this.trbVelocity.TabIndex = 3;
            this.trbVelocity.TickFrequency = 10;
            this.trbVelocity.ValueChanged += new System.EventHandler(this.trbVelocity_ValueChanged);
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(12, 210);
            this.txtVelocity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(164, 22);
            this.txtVelocity.TabIndex = 6;
            this.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(63, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Velocity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(104, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "%";
            // 
            // prbFeedback
            // 
            this.prbFeedback.Location = new System.Drawing.Point(12, 308);
            this.prbFeedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prbFeedback.MarqueeAnimationSpeed = 0;
            this.prbFeedback.Name = "prbFeedback";
            this.prbFeedback.Size = new System.Drawing.Size(164, 23);
            this.prbFeedback.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Feedback:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedback.Location = new System.Drawing.Point(133, 288);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(40, 17);
            this.lblFeedback.TabIndex = 8;
            this.lblFeedback.Text = "10 %";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(259, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(424, 286);
            this.textBox1.TabIndex = 10;
            // 
            // FeedbackTimer
            // 
            this.FeedbackTimer.Interval = 600;
            this.FeedbackTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btVel
            // 
            this.btVel.Location = new System.Drawing.Point(56, 336);
            this.btVel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btVel.Name = "btVel";
            this.btVel.Size = new System.Drawing.Size(77, 31);
            this.btVel.TabIndex = 11;
            this.btVel.Text = "Send Vel";
            this.btVel.UseVisualStyleBackColor = true;
            this.btVel.Click += new System.EventHandler(this.btVel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conexionToolStripMenuItem,
            this.dataToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(695, 28);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.conexionToolStripMenuItem.Text = "Conexion";
            // 
            // conectToolStripMenuItem
            // 
            this.conectToolStripMenuItem.Name = "conectToolStripMenuItem";
            this.conectToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.conectToolStripMenuItem.Text = "Connect";
            this.conectToolStripMenuItem.Click += new System.EventHandler(this.conectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.dataToolStripMenuItem.Text = "Export";
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.notepadToolStripMenuItem.Text = "Txt file";
            this.notepadToolStripMenuItem.Click += new System.EventHandler(this.notepadToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 407);
            this.Controls.Add(this.btVel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.prbFeedback);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVelocity);
            this.Controls.Add(this.trbVelocity);
            this.Controls.Add(this.btStrStp);
            this.Controls.Add(this.btLeft);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trbVelocity)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btStrStp;
        private System.Windows.Forms.TrackBar trbVelocity;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer FeedbackTimer;
        private System.Windows.Forms.Button btVel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conexionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notepadToolStripMenuItem;
        public System.Windows.Forms.ProgressBar prbFeedback;
    }
}


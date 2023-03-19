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
            this.btRight.Location = new System.Drawing.Point(71, 92);
            this.btRight.Margin = new System.Windows.Forms.Padding(2);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(63, 61);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "Right";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(11, 92);
            this.btLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(56, 61);
            this.btLeft.TabIndex = 1;
            this.btLeft.Text = "Left";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // btStrStp
            // 
            this.btStrStp.Location = new System.Drawing.Point(11, 27);
            this.btStrStp.Margin = new System.Windows.Forms.Padding(2);
            this.btStrStp.Name = "btStrStp";
            this.btStrStp.Size = new System.Drawing.Size(123, 61);
            this.btStrStp.TabIndex = 2;
            this.btStrStp.Text = "ON";
            this.btStrStp.UseVisualStyleBackColor = true;
            this.btStrStp.Click += new System.EventHandler(this.btStrStp_Click);
            // 
            // trbVelocity
            // 
            this.trbVelocity.Location = new System.Drawing.Point(9, 194);
            this.trbVelocity.Margin = new System.Windows.Forms.Padding(2);
            this.trbVelocity.Maximum = 100;
            this.trbVelocity.Name = "trbVelocity";
            this.trbVelocity.Size = new System.Drawing.Size(123, 45);
            this.trbVelocity.TabIndex = 3;
            this.trbVelocity.TickFrequency = 10;
            this.trbVelocity.ValueChanged += new System.EventHandler(this.trbVelocity_ValueChanged);
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(9, 171);
            this.txtVelocity.Margin = new System.Windows.Forms.Padding(2);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(124, 20);
            this.txtVelocity.TabIndex = 6;
            this.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVelocity.TextChanged += new System.EventHandler(this.txtVelocity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(47, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Velocity:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(78, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "%";
            // 
            // prbFeedback
            // 
            this.prbFeedback.Location = new System.Drawing.Point(9, 250);
            this.prbFeedback.Margin = new System.Windows.Forms.Padding(2);
            this.prbFeedback.Name = "prbFeedback";
            this.prbFeedback.Size = new System.Drawing.Size(123, 19);
            this.prbFeedback.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 234);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Feedback:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedback.Location = new System.Drawing.Point(100, 234);
            this.lblFeedback.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(30, 13);
            this.lblFeedback.TabIndex = 8;
            this.lblFeedback.Text = "10 %";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 26);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 233);
            this.textBox1.TabIndex = 10;
            // 
            // FeedbackTimer
            // 
            this.FeedbackTimer.Interval = 2000;
            this.FeedbackTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btVel
            // 
            this.btVel.Location = new System.Drawing.Point(42, 273);
            this.btVel.Margin = new System.Windows.Forms.Padding(2);
            this.btVel.Name = "btVel";
            this.btVel.Size = new System.Drawing.Size(58, 25);
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
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conexionToolStripMenuItem
            // 
            this.conexionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.conexionToolStripMenuItem.Name = "conexionToolStripMenuItem";
            this.conexionToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.conexionToolStripMenuItem.Text = "Conexion";
            // 
            // conectToolStripMenuItem
            // 
            this.conectToolStripMenuItem.Name = "conectToolStripMenuItem";
            this.conectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.conectToolStripMenuItem.Text = "Connect";
            this.conectToolStripMenuItem.Click += new System.EventHandler(this.conectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.notepadToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.dataToolStripMenuItem.Text = "Export";
            // 
            // notepadToolStripMenuItem
            // 
            this.notepadToolStripMenuItem.Name = "notepadToolStripMenuItem";
            this.notepadToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.notepadToolStripMenuItem.Text = "Notepad.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 331);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ProgressBar prbFeedback;
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
    }
}


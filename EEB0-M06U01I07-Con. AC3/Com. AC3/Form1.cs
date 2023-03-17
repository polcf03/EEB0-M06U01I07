using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;  
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.CodeDom.Compiler;

namespace Com.AC3
{
    public partial class Form1 : Form
    {
        // Objects
        static ComManager myComManager = new ComManager();

        // Constructor
        public Form1()
        {
            InitializeComponent();
            btRight.Enabled = false;
            btLeft.Enabled = false;
            btStrStp.Enabled = false;
            btVel.Enabled = false;
        }



        // Velcity bar mesure
        private void txtVelocity_TextChanged(object sender, EventArgs e)
        {
            trbVelocity.Value = Int32.Parse(txtVelocity.Text);
            prbFeedback.Value = trbVelocity.Value;
            lblFeedback.Text = trbVelocity.Value.ToString() + " %";

        }
        private void trbVelocity_ValueChanged(object sender, EventArgs e)
        {
            txtVelocity.Text = trbVelocity.Value.ToString();
        }

        // Reset graphics by Feedback
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
        private void GraphicsFeedback()
        {
            if (!myComManager.getComError())
            {
                if()
            }
        }

        private void conectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
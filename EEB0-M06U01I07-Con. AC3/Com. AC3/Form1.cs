using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Com.AC3
{
    public partial class Form1 : Form
    {
        static SerialPort sPort;
        string[] Ports;
        public Form1()
        {
            InitializeComponent();
            sPort = new SerialPort();
            
        }



        private void btConDis_Click(object sender, EventArgs e)
        {
            
        }

        private void btOLeft_Click(object sender, EventArgs e)
        {

        }

        private void btRight_Click(object sender, EventArgs e)
        {

        }

        private void btStrStp_Click(object sender, EventArgs e)
        {

        }
       
        private void txtVelocity_TextChanged(object sender, EventArgs e)
        {
            trbVelocity.Value = Int32.Parse(txtVelocity.Text);
            prbFeedback.Value=trbVelocity.Value;
            lblFeedback.Text = trbVelocity.Value.ToString()+" %" ;
        }
        private void trbVelocity_ValueChanged(object sender, EventArgs e)
        {
           txtVelocity.Text= trbVelocity.Value.ToString();
        }

        
    }
}

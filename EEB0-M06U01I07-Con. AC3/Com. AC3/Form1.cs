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

namespace Com.AC3
{
    public partial class Form1 : Form
    {
        
        static ComManager myComManager = new ComManager();

        public Form1()
        {
            InitializeComponent();
            btConDis.Text = "Connect";
        }

        private void btConDis_Click(object sender, EventArgs e)
        {
            myComManager.Conexion();
            if (!myComManager.getComError() && myComManager.getConexionState())
            {
                btConDis.Text = "Disconnect";
                btConDis.BackColor = Color.Red;
            }
            else if (myComManager.getComError() && !myComManager.getConexionState())
            {
                btConDis.Text = "Disconnect";
                btConDis.BackColor = Color.Red;
            }
            else if (!myComManager.getComError() && !myComManager.getConexionState())
            {
                btConDis.Text = "Connect";
                btConDis.BackColor = Color.Green;
            }
            else
            {
                btConDis.Text = "Connect";
                btConDis.BackColor = Color.Green;
            }
        }

        //Controls
        private void btLeft_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(3, false, trbVelocity.Value);
            if (!myComManager.getComError())
            {
                if (!myComManager.getDirectionMotor())
                {
                    btLeft.BackColor = Color.Gray;
                    btRight.BackColor = Color.Coral;
                    btLeft.Enabled = false;
                    btRight.Enabled = true;
                }
            }     
        }
        private void btRight_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(3, true, trbVelocity.Value);
            if (!myComManager.getComError())
            {
                if (myComManager.getDirectionMotor())
                {
                    btRight.BackColor = Color.Gray;
                    btLeft.BackColor = Color.Coral;
                    btLeft.Enabled = true;
                    btRight.Enabled = false;
                }
            }
        }
        private void btStrStp_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(0, true, trbVelocity.Value);
            if (!myComManager.getComError())
            {
                if (myComManager.geOnMotor())
                {

                }
            }
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
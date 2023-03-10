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
        // Objects
        static ComManager myComManager = new ComManager();

        //Constructor
        public Form1()
        {
            InitializeComponent();
            btConDis.Text = "Connect";
        }

        // Conexion
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

        // Controls
        private void btLeft_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(3, false, trbVelocity.Value);
            myComManager.SendOrder();
            myComManager.ReadFeedback();
            
            if (!myComManager.getComError())
            {
                if (!myComManager.getDirectionMotor())
                {
                    btLeft.Enabled = false;
                    btRight.Enabled = true;
                }
            }     
        }
        private void btRight_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(3, true, trbVelocity.Value);
            myComManager.SendOrder();
            myComManager.ReadFeedback();
           
            if (!myComManager.getComError())
            {
                if (myComManager.getDirectionMotor())
                {
                    btLeft.Enabled = true;
                    btRight.Enabled = false;
                }
            }
        }
        private void btStrStp_Click(object sender, EventArgs e)
        {
            if(!myComManager.getOnMotor())
            {
                myComManager.OrderCON(0, true, trbVelocity.Value);
                myComManager.SendOrder();
                myComManager.ReadFeedback();
                
                if (!myComManager.getComError())
                {
                    if (myComManager.getOnMotor())
                    {
                        btStrStp.Text = "ON";
                    }
                    else
                    {
                        btStrStp.Text = "OFF";
                    }
                }
            }            
        }
        private void btVel_Click(object sender, EventArgs e)
        {
            myComManager.OrderCON(2, myComManager.getDirectionMotor(),trbVelocity.Value)
            myComManager.SendOrder();
            myComManager.ReadFeedback();
            if(!myComManager.getComError())
            {
                txtVelocity.Text = myComManager.getVelocityMotor().ToString();
            }
        }

        //Velcity bar mesure
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

        //Reset graphics by Feedback
        private void timer1_Tick(object sender, EventArgs e)
        {
            myComManager.OrderINF();
            myComManager.SendOrder();
            myComManager.ReadFeedback();
            GraphicsFeedback();
        }
        private void GraphicsFeedback()
        {
            if (myComManager.getOnMotor())
            {
                btStrStp.Text = "On";
            }
            else
            {
                btStrStp.Text = "OFF";
            }
            if (myComManager.getDirectionMotor())
            {
                btRight.Enabled = false;
                btLeft.Enabled = true;
            }
            else
            {
                btLeft.Enabled = false;
                btRight.Enabled = true;
            }
            txtVelocity.Text = myComManager.getVelocityMotor().ToString();
        }
    }
}
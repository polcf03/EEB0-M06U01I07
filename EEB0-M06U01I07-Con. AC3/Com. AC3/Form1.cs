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
        // Objects-		Miembros estáticos		

        static ComManager myComManager = new ComManager();

        // Constructor
        public Form1()
        {
            InitializeComponent();
            btRight.Enabled = false;
            btLeft.Enabled = false;
            btStrStp.Enabled = false;
            btVel.Enabled = false;
            trbVelocity.Enabled= false;
            txtVelocity.Enabled = false;    
        }

        // Controls
        private void conectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!myComManager.getConexionState())
            {
                myComManager.Conexion();
                myComManager.setComError(false);
                GraphicsFeedback();
                
                
                if (myComManager.getConexionState()) { FeedbackTimer.Start(); }  
            }
        }
        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.Conexion();
                GraphicsFeedback();
                FeedbackTimer.Stop();
                myComManager.setComError(false);
            }
        }
        private void btStrStp_Click(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                if(!myComManager.getMotorOn())
                {
                    myComManager.setNewDirection("RIG");
                    myComManager.setNewOn(true);
                    myComManager.setNewVelocity(trbVelocity.Value);

                    myComManager.FullCom("CON", "ON", "RIG", txtVelocity.Text);
                    GraphicsFeedback();
                    myComManager.setComError(false);
                }
                else
                {
                    myComManager.setNewDirection("RIG");
                    myComManager.setNewOn(false);
                    myComManager.setNewVelocity(0);

                    myComManager.FullCom("CON", "OFF", "RIG", "0");
                    GraphicsFeedback();
                    myComManager.setComError(false);
                }
                    
            }
        }
        private void btRight_Click(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.setNewDirection("RIG");

                myComManager.FullCom("CON", "DIR", "RIG", "");
                GraphicsFeedback();
                myComManager.setComError(false);
            }
        }
        private void btLeft_Click(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.setNewDirection("LFT");

                myComManager.FullCom("CON", "DIR", "LFT", "");
                GraphicsFeedback();
                myComManager.setComError(false);
            }
        }
        private void btVel_Click(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.setNewVelocity(trbVelocity.Value);

                myComManager.FullCom("CON", "VEL", txtVelocity.Text, "");
                GraphicsFeedback();
                myComManager.setComError(false);
            }
        }

        private void trbVelocity_ValueChanged(object sender, EventArgs e)
        {
            txtVelocity.Text = trbVelocity.Value.ToString();
        }

        // Graphic reset by Feedback
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.FullCom("INF", "EST", "", "");
                GraphicsFeedback();
                if (myComManager.getComError())
                {
                    FeedbackTimer.Stop();
                    MessageBox.Show("Feedback response is not working");
                }
                myComManager.setComError(false);
            }
        }
        private void GraphicsFeedback()
        {
            if (!myComManager.getComError())
            {
                if(myComManager.getConexionState())
                {
                    btStrStp.Enabled = true;    
                }
                else
                {
                    btStrStp.Enabled = false;
                }

                if(!myComManager.getMotorOn())
                {
                    btStrStp.Text = "ON";
                    btRight.Enabled = false;
                    btLeft.Enabled = false;
                    btVel.Enabled = false;
                    trbVelocity.Enabled = false;
                    txtVelocity.Enabled = false;
                }
                else 
                { 
                    btStrStp.Text = "OFF";
                    btRight.Enabled = true;
                    btLeft.Enabled = true;
                    btVel.Enabled = true;
                    trbVelocity.Enabled = true;
                    txtVelocity.Enabled = true;

                }
                if (myComManager.getMotorOn())
                {
                    if (myComManager.getMotorDirection() == "RIG") { btRight.Enabled = false; btLeft.Enabled = true; }
                    else if (myComManager.getMotorDirection() == "LFT") { btRight.Enabled = true; btLeft.Enabled = false; }
                    else { btRight.Enabled = false; btLeft.Enabled = false; }

                }
                try
                {
                    prbFeedback.Value = myComManager.getMotorVelocity();
                    lblFeedback.Text = myComManager.getMotorVelocity().ToString();
                }
                catch(Exception ex) { };
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myComManager.getConexionState())
            {
                myComManager.Conexion();
            }
        }
    }
}
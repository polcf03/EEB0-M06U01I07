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
        static Exporter myExporter = new Exporter();

        // Constructor
        public Form1()
        {
            InitializeComponent();
            btRight.Enabled = false;
            btLeft.Enabled = false;
            btStrStp.Enabled = false;
            btVel.Enabled = false;
            trbVelocity.Enabled= true;
            txtVelocity.Enabled = true;

            myComManager.TransferData += SerialDisplay;
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
                FeedbackTimer.Stop();
                GraphicsFeedback();
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
                try
                {
                    if (0 <= float.Parse(txtVelocity.Text) && float.Parse(txtVelocity.Text) <= float.Parse(txtVelocity.Text))
                    {
                        trbVelocity.Value = Int32.Parse(txtVelocity.Text);
                    }
                    else
                    {
                        MessageBox.Show("Insertar numero de 0 a 50");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insertar numero de 0 a 50");
                }
                    
                
                myComManager.setComError(false);
            }
        }

        private void trbVelocity_ValueChanged(object sender, EventArgs e)
        {
            float a;
            a = trbVelocity.Value;
            txtVelocity.Text = a.ToString() + ".0";
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
                    btRight.Enabled = false;
                    btLeft.Enabled = false;
                    btVel.Enabled = false;
                    trbVelocity.Enabled = false;
                    txtVelocity.Enabled = false;
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

       
        private void SerialDisplay(object sender, DataEventArgs e)
        {
            string txt;
            txt = e.Data;
            myExporter.addData(e.Data, e.Sended, e.Received);
            if (txt != "#INF$EST&%#")
            {
                if (e.Sended && !e.Received)
                {
                    textBox1.Text = DateTime.Now.ToString() + "  -  Pc to Ard:  " + txt + "\r\n" + textBox1.Text;
                }
                else if (e.Received && !e.Sended)
                {
                    textBox1.Text = DateTime.Now.ToString() + "  -  Ard to Pc:  " + txt + "\r\n" + textBox1.Text;
                }
                else { } 
            }         
        }

        private void notepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            myExporter.ShowDialog();
        }
    }
}
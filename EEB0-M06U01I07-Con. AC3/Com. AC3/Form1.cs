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
        static SerialPort mySerial = new SerialPort();
        static ComManager myComManager = new ComManager();

        bool firstCom;
        bool ConexionState;
        string Port;

        public Form1()
        {
            InitializeComponent();
            firstCom = true;
            ConexionState = false;
            Port = "";
        }

        private void btConDis_Click(object sender, EventArgs e)
        {
            string str;
            if (!ConexionState)
            {
                if (firstCom)
                {
                    foreach (string sp in SerialPort.GetPortNames())
                    {
                        textBox1.Text = "trying to:" + mySerial + "\r\n" + textBox1.Text;
                        try
                        {
                            Port = sp;
                            mySerial.PortName = Port;
                            mySerial.BaudRate = 19200;
                            mySerial.Encoding = System.Text.Encoding.Default;
                            mySerial.ReadTimeout = 2000;
                            mySerial.WriteTimeout = 2000;


                            str = "#STM$CON&%#";
                            textBox1.Text = str;

                            mySerial.Open();
                            mySerial.Write(str);

                            str = mySerial.ReadLine();
                            myComManager.ReadFeedback(str);

                            if (!myComManager.getComError() && myComManager.getConexionState())
                            {
                                ConexionState = myComManager.getConexionState();
                                btConDis.Text = "Disconnect";
                                btConDis.BackColor = Color.Red;
                            }
                            else
                            {
                                mySerial.Close();
                                ConexionState = myComManager.getConexionState();
                                btConDis.Text = "Connect";
                                btConDis.BackColor = Color.Green;
                            }
                        }
                        catch (Exception)
                        {
                            mySerial.Close();
                            ConexionState = myComManager.getConexionState();
                            btConDis.Text = "Connect";
                            btConDis.BackColor = Color.Green;
                        }
                    }
                }
                else
                {
                    try
                    {
                        mySerial.PortName = Port;
                        mySerial.BaudRate = 19200;
                        mySerial.Encoding = System.Text.Encoding.Default;
                        mySerial.ReadTimeout = 2000;
                        mySerial.WriteTimeout = 2000;


                        str = "#STM$CON&%#";
                        textBox1.Text = str;

                        mySerial.Open();
                        mySerial.Write(str);

                        str = mySerial.ReadLine();
                        myComManager.ReadFeedback(str);

                        if (!myComManager.getComError() && myComManager.getConexionState())
                        {
                            ConexionState = true;
                            btConDis.Text = "Disconnect";
                            btConDis.BackColor = Color.Red;
                        }
                        else
                        {
                            mySerial.Close();
                            btConDis.Text = "Connect";
                            btConDis.BackColor = Color.Green;
                        }
                    }
                    catch (Exception)
                    {
                        mySerial.Close();
                        btConDis.Text = "Connect";
                        btConDis.BackColor = Color.Green;
                    }
                }
            }
            else
            {
                mySerial.Close();
                btConDis.Text = "Connect";
                btConDis.BackColor = Color.Green;
            }
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

        private void mySerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string txtRecived;
            if (mySerial.IsOpen)
            {
                txtRecived = mySerial.ReadLine();
                myComManager.ReadFeedback(txtRecived);

            }   
        }
    }
}
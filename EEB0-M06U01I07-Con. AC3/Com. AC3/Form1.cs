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
        

        bool firstCom, connect;
        public Form1()
        {
            InitializeComponent();
            
            firstCom = true;
            
        }
        private void btConDis_Click(object sender, EventArgs e)
        {
            string str;
            if(firstCom)
            {
                foreach (string sp in SerialPort.GetPortNames())
                {
                    textBox1.Text = "trying to:" + mySerial + "\r\n" + textBox1.Text;
                    try
                    {
                        mySerial.PortName = sp;
                        mySerial.BaudRate = 19200;
                        mySerial.Encoding = System.Text.Encoding.Default;
                        mySerial.ReadTimeout = 2000;
                        mySerial.WriteTimeout = 2000;


                        str = "#STM$CON&%#";
                        textBox1.Text = str;

                        mySerial.Open();
                        mySerial.Write(str);

                        str = mySerial.ReadLine();
                        if(myComManager.ReadData(str)[0] == "STM" && myComManager.ReadData(str)[1] == "CONO")
                        {
                            connect = true;
                        }
                    }
                    catch(Exception)
                    {
                        mySerial.Close();
                    }
                }
            }
            else
            {
                try
                {
                    str = "#STM$DIS&%#";
                }
                catch(Exception)
                {
                    mySerial.Close();
                }
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

        public void mySerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string txtRecived;
            
           
            if (mySerial.IsOpen)
            {
                   txtRecived = mySerial.ReadLine();
            }   
        }
    }
}

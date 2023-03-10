using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace Com.AC3
{
    class ComManager
    {
        static SerialPort mySerial = new SerialPort();
        static Motor myMotor = new Motor();
        static OrdersToSend myOrders = new OrdersToSend();

        private string [] Data;
        private bool ConexionState, ComError, firstCom;
        private string Port;

        public ComManager()
        {
            Data = new string[] {"", "", "", ""};
            ConexionState = false;
            ComError = false;
            firstCom = true;
            Port = "";
        }

        // Save Serial data
        private void SaveData(string str)
        {
            char [] c = str.ToCharArray();
            string a = "";
            int i = 0;
            do
            {
                a += c[i];
                i++;
            }
            while (c[i] != '#');
            a = "";
            i++;
            while (c[i] != '$')
            {
                a += c[i];
                i++;
            }
            Data[0] = a;
            a = "";
            i++;
            while (c[i] != '&')
            {
                a += c[i];
                i++;
            }
            Data[1] = a;
            a = "";
            i++;
            while (c[i] != '%')
            {
                a += c[i];
                i++;
            }
            Data[2] = a;
            a = "";
            i++;
            while (c[i] != '#')
            {
                a += c[i];
                i++;
            }
            Data[3] = a;
            a = "";
            i++;
        }

        // Read and Save Feedback
        private  void UploadFeedback(string[] Fdb)
        {
            switch (Fdb[0])
            {
                default:
                    ComError = true;
                    break;
                case "STM":
                    if (Fdb[1] == "CONO")
                    {
                        ConexionState = true;
                        ComError = false;
                    }
                    else if (Fdb[1] == "DISO")
                    {
                        ConexionState = false;
                        setDataMotor();
                    }
                    else
                    {
                        ComError = true;
                        ConexionState = false;
                        setDataMotor();
                    }
                    break;

                case "CON":
                    if (Fdb[1] == "MOV")
                    {
                        if (Fdb[2] == "ON")
                        {
                            if (Fdb[3] == "OK")
                            {
                                setDataMotor("Right", true, 20);
                            }
                            else if (Fdb[3] == "WR")
                            {
                                setDataMotor();
                                ComError = true;
                            }
                            else
                            {
                                ComError = true;
                            }
                        }
                        else if (Fdb[2] == "OFF")
                        {
                            if (Fdb[3] == "OK")
                            {
                                setDataMotor();
                            }
                            else if (Fdb[3] == "WR")
                            {
                                ComError = true;
                            }
                            else
                            {
                                ComError = true;
                            }
                        }
                        else
                        {
                            ComError = true;
                        }
                    }
                    else if (Fdb[1] == "DIR")
                    {
                        if (Fdb[2] == "OK")
                        {

                        }
                        else if (Fdb[2] == "WR")
                        {
                            ComError = true;
                        }
                        else
                        {
                            ComError = true;
                        }
                    }
                    else
                    {
                        ComError = true;
                    }
                    break;

                case "INF":
                    bool i = false;
                    if (Fdb[1] == "ON")
                    {
                        i = true;
                        setDataMotor(Fdb[2], i, Int32.Parse(Fdb[3]));
                    }
                    else if (Fdb[1]=="OFF")
                    {
                        i = false;
                        setDataMotor(Fdb[2], i, Int32.Parse(Fdb[3]));
                    }
                    else
                    {
                        ComError = false;
                    }
                    break;
            }
        }

        // Read and Upload Feedback
        private void ReadFeedback(string str)
        {
            SaveData(str);
            UploadFeedback(Data);
        }

        // Conexion Satate acces
        public bool getConexionState() { return ConexionState; }
        public bool getComError() { return ComError; }

        // Create New Order
        public void OrderSTM(bool connect)
        {
            myOrders.OrderSTM(connect);
        }
        public void OrderCON(int Mode, bool dir, int vel)
        {
            myOrders.OrderCON(Mode, dir, vel);
        }
        public void OrderINF()
        {
            myOrders.OrderINF();
        }
        
        // Read Order to send
        private string Order()
        {
            return myOrders.Order();
        }


        // Motor data acces and modifier
        private void setDataMotor()
        {
            myMotor.Direction = "";
            myMotor.On = false;
            myMotor.Velocity = 0;
        }
        private void setDataMotor (string Direction, bool On, int Velocity)
        {
            myMotor.Direction = Direction;
            myMotor.On = On;
            myMotor.Velocity = Velocity;
        }

        public bool getDirectionMotor() { return myMotor.Direction; }
        public bool geOnMotor() { return myMotor.On; }
        public int geVelocityMotor() { return myMotor.Velocity; }


        //Conexion
        public void Conexion()
        {
            string str;
            if (!ConexionState)
            {
                if (firstCom)
                {
                    foreach (string sp in SerialPort.GetPortNames())
                    {
                        try
                        {
                            //Serial Pârameters
                            Port = sp;
                            mySerial.PortName = Port;
                            mySerial.BaudRate = 19200;
                            mySerial.Encoding = System.Text.Encoding.Default;
                            mySerial.ReadTimeout = 2000;
                            mySerial.WriteTimeout = 2000;

                            //Serial Conexion
                            OrderSTM(true);
                            mySerial.Open();
                            mySerial.Write(Order());

                            //Orders and feedback conexion
                            str = mySerial.ReadLine();
                            ReadFeedback(str);

                            if (getComError() && !getConexionState())
                            {
                                mySerial.Close();
                            }
                            else if (getComError() && getConexionState())
                            {
                                mySerial.Close();
                            }
                            firstCom = false;
                        }
                        catch (Exception)
                        {
                            mySerial.Close();
                        }
                    }
                }
                else
                {
                    try
                    {
                        //Serial Pârameters
                        mySerial.PortName = Port;
                        mySerial.BaudRate = 19200;
                        mySerial.Encoding = System.Text.Encoding.Default;
                        mySerial.ReadTimeout = 2000;
                        mySerial.WriteTimeout = 2000;


                        //Serial Conexion
                        OrderSTM(true);
                        mySerial.Open();
                        mySerial.Write(Order());

                        //Orders and feedback conexion
                        str = mySerial.ReadLine();
                        ReadFeedback(str);

                        if (getComError() && !getConexionState())
                        {
                            mySerial.Close();
                        }
                        else if (getComError() && getConexionState())
                        {
                            mySerial.Close();
                        }
                        firstCom = false;
                    }
                    catch (Exception)
                    {
                        mySerial.Close();
                    }
                }
            }
            else
            {
                OrderSTM(false);
                mySerial.Write(Order());
                mySerial.Close();
            }
        }

        //Data Recieved
        private void mySerial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string txtRecived;
            if (mySerial.IsOpen)
            {
                txtRecived = mySerial.ReadLine();
                ReadFeedback(txtRecived);
            }
        }
    }

}
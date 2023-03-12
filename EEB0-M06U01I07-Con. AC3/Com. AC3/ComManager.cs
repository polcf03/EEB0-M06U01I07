using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing;

namespace Com.AC3
{
    class ComManager
    {
        // Objects
        static SerialPort mySerial = new SerialPort();
        static Motor myMotor = new Motor();
        static OrdersToSend myOrders = new OrdersToSend(true);

        // Conexion Data Propieties 
        private string [] Data;
        private bool ConexionState, ComError, firstCom;
        private string Port;

        // Constructors
        public ComManager()
        {
            Data = new string[] {"", "", "", ""};
            ConexionState = false;
            ComError = false;
            firstCom = true;
            Port = "";
        }

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
                            mySerial.Open();

                            //Orders and feedback conexion
                            SendOrder();
                            ReadFeedback();

                            if (getComError())
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
                        ReadFeedback();

                        if (getComError())
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
                SendOrder();
                mySerial.Close();
            }
        }

        // Save Serial data
        // Read and Save Feedback
        private void SaveData(string str)
        {
            if(str == null)
            {
                ComError = true; return;
            }
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
                    }
                    else if (Fdb[1] == "DISO")
                    {
                        mySerial.Close();
                        ConexionState = false;
                        setDataMotorOFF();
                    }
                    else
                    {
                        ComError = true;
                        ConexionState = false;
                        setDataMotorOFF();
                    }
                    break;

                case "CON":
                    if (Fdb[1] == "MOV")
                    {
                        if (Fdb[2] == "ON")
                        {
                            if (Fdb[3] == "OK")
                            {
                                setDataMotor(true, true, 20);
                            }
                            else if (Fdb[3] == "WR")
                            {
                                setDataMotorOFF();
                                ComError = true;
                            }
                            else{ ComError = true; }
                        }
                        else if (Fdb[2] == "OFF")
                        {
                            if (Fdb[3] == "OK")
                            {
                                setDataMotorOFF();
                            }
                            else if (Fdb[3] == "WR")
                            {
                                ComError = true;
                            }
                            else { ComError = true; }
                        }
                        else { ComError = true; }
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
                        else { ComError = true; }
                    }
                    else { ComError = true; }
                    break;

                case "INF":
                    if (Fdb[1] == "ON")
                    {
                        if (Fdb[2] == "RIG")
                        {
                            setDataMotor(true, true, Int32.Parse(Fdb[3]));
                        }
                        else if(Fdb[2] == "LFT")
                        {
                            setDataMotor(false, true, Int32.Parse(Fdb[3]));
                        }
                        else { ComError = true; }

                    }
                    else if (Fdb[1]=="OFF")
                    {
                        if (Fdb[2] == "RIG")
                        {
                            setDataMotor(true, false, Int32.Parse(Fdb[3]));
                        }
                        else if(Fdb[2] == "LFT")
                        {
                            setDataMotor(false, false, Int32.Parse(Fdb[3]));
                        }
                        else { ComError = true; }
                    }
                    else { ComError = true; }
                    break;
            }
        }

        // Read and Upload Feedback
        public void ReadFeedback()
        {
            string str = mySerial.ReadLine();
            SaveData(str);
            UploadFeedback(Data);
        }

        // Read Order to send
        private string Order()
        {
            return myOrders.Order();
        }

        // Send Order
        public void SendOrder()
        {
            string str = Order();
            mySerial.Write(str);
        }

        // Conexion Satate acces and modifier
        public bool getConexionState() { return ConexionState; }
        public bool getComError() { return ComError; }
        public void ResetComError() { ComError = false; }

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
        
        // Motor data acces and modifier
        private void setDataMotorOFF()
        {
            myMotor.Direction = true;
            myMotor.On = false;
            myMotor.Velocity = 0;
        }
        private void setDataMotor (bool Direction, bool On, int Velocity)
        {
            myMotor.Direction = Direction;
            myMotor.On = On;
            myMotor.Velocity = Velocity;
        }

        public bool getDirectionMotor() { return myMotor.Direction; }
        public bool getOnMotor() { return myMotor.On; }
        public int getVelocityMotor() { return myMotor.Velocity; }



    }
}





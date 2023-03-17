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
        static FrameManager myFrameManager = new FrameManager(true);

        // Class varables
        private bool ConexionState, ComError, firstCom;
        private string Port;

        // Constructors
        public ComManager()
        {
            ConexionState = false;
            ComError = false;
            firstCom = true;
            Port = "";
        }

        // Conexion
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
                                ComError = false;
                            }
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
                        // Serial Pârameters
                        mySerial.PortName = Port;
                        mySerial.BaudRate = 19200;
                        mySerial.Encoding = System.Text.Encoding.Default;
                        mySerial.ReadTimeout = 2000;
                        mySerial.WriteTimeout = 2000;

                        // Serial Conexion
                        mySerial.Open();

                        // Orders and feedback conexion
                        SendOrder("STM", "CON", "", "");
                        ReadFeedback();
                        

                        if (getComError())
                        {
                            mySerial.Close();
                            ComError = false;
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

        

        // Read and Upload Feedback
        public void ReadFeedback()
        {
            string str = mySerial.ReadLine();
            myFrameManager.Frame(str);
            UploadData(myFrameManager.getCommand(),myFrameManager.getArg1(),myFrameManager.getArg2(),myFrameManager.getArg3());

            // Upload Motor and conexion state data
            void UploadData(string Command, string Arg1, string Arg2, string Arg3)
            {
                switch (Command)
                {
                    case "STM":
                        switch (Arg1)
                        {
                            case "CONO":
                                ConexionState = true;
                                break;
                            case "DISO":
                                ConexionState = false;
                                break;
                            default:
                                ConexionState = false;
                                ComError = true;
                                break;
                        }
                        break;
                    case "CON":
                        switch (Arg1)
                        {
                            case "MOV":
                                switch (Arg2)
                                {
                                    case "ON":
                                        if (Arg3 == "OK")
                                        {
                                            myMotor.updateOn();
                                        }
                                        else if (Arg3 == "WR")
                                        {
                                            myMotor.resetNewOn();
                                            ComError = true;
                                        }
                                        else
                                        {
                                            myMotor.resetNewOn();
                                            ComError = true;
                                        }
                                        break;
                                    case "OFF":
                                        if (Arg3 == "OK")
                                        {
                                            myMotor.updateOn();
                                        }
                                        else if (Arg3 == "WR")
                                        {
                                            myMotor.resetNewOn();
                                            ComError = true;
                                        }
                                        else
                                        {
                                            myMotor.resetNewOn();
                                            ComError = true;
                                        }
                                        break;
                                    default:
                                        myMotor.resetNewOn();
                                        ComError = true;
                                        break;
                                }
                                break;
                            case "VEL":
                                if (Arg2 == "OK")
                                {
                                    myMotor.updateVelocity();
                                }
                                else if (Arg2 == "WR")
                                {
                                    myMotor.resetNewVelocity();
                                    ComError = true;
                                }
                                else
                                {
                                    myMotor.resetNewVelocity();
                                    ComError = true;
                                }
                                break;
                            case "DIR":
                                if (Arg2 == "OK")
                                {
                                    myMotor.updateDirection();
                                }
                                else if (Arg2 == "WR")
                                {
                                    myMotor.resetNewDirection();
                                    ComError = true;
                                }
                                else
                                {
                                    myMotor.resetNewDirection();
                                    ComError = true;
                                }
                                break;
                            default: ComError = true; break;
                        }
                        break;
                    case "INF":
                        try
                        {
                            if (Arg1 == "ON")
                            {
                                myMotor.setCurrentOn(true);
                            }
                            else if (Arg1 == "OFF")
                            {
                                myMotor.setCurrentOn(false);
                            }
                            else { ComError = true; }

                            if (Arg2 != "RIG" && Arg2 != "LFT")
                            {
                                ComError = true;
                            }
                            else { myMotor.setCurrentDirection(Arg2); }

                            int a;
                            a = Int32.Parse(Arg3);
                            if (0 <= a && a >= 100)
                            {
                                myMotor.setCurrentVelocity(a);
                            }
                            else { ComError = true; }
                        }
                        catch (Exception)
                        {
                            ComError = true;
                        }
                        break;
                    default:
                        ComError = true;
                        break;
                }
            }

        }

        // Send Order
        public  void SendOrder()
        {
            string str;
            str = myFrameManager.Order();
            mySerial.Write(str);
        }
        public void SendOrder(string Command, string Arg1, string Arg2, string Arg3)
        {
            string str;
            str = myFrameManager.Order(Command, Arg1, Arg2, Arg3);
            mySerial.Write(str);
        }

        // Complete dialogue

        // Conexion state accessor and modifier
        public bool getConexionState() { return ConexionState; }
        public bool getComError() { return ComError; }
        public void ResetComError() { ComError = false; }


    }
}





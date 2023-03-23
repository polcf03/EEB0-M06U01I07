using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Com.AC3
{
    class ComManager
    {
        // Objects
        static SerialPort mySerial = new SerialPort();
        static Motor myMotor = new Motor();
        static FrameManager myFrameManager = new FrameManager();

        // Class varables
        private bool ConexionState, ComError, firstCom;
        private string Port;
        private string Data;

        // Constructors
        public ComManager()
        {
            ConexionState = false;
            ComError = false;
            firstCom = true;
            Port = "";
            Data = "";
        }

        // Conexion
        public void Conexion()
        {
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
                            SendOrder("STM","CON","","");
                            ReadFeedback();
                            if (getComError()) { mySerial.Close(); }
                            firstCom = false;
                        }
                        catch (Exception ex) { mySerial.Close(); }
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
                        mySerial.Open();


                        //Orders and feedback conexion
                        SendOrder("STM", "CON", "", "");
                        ReadFeedback();
                        if (getComError()) { mySerial.Close(); }
                    }
                    catch (Exception ex) { mySerial.Close(); }
                }
            }
            else
            {
                FullCom("STM", "DIS", "", "");
                ConexionState = false;
                mySerial.Close();
            }
        }

        // Complete dialogue (Send and recieve)
        public void FullCom(string Command, string Arg1, string Arg2, string Arg3)
        {
            SendOrder(Command, Arg1, Arg2, Arg3);
            ReadFeedback();
        }

        // Read and Upload Feedback
        private void ReadFeedback()
        {
            try
            {
                string str = mySerial.ReadLine();
                Data += str + "r/n/";
                if (str == null && str == "")
                {
                    ComError = true;
                }
                else
                {
                    myFrameManager.Frame(str);
                    UploadData(myFrameManager.getCommand(), myFrameManager.getArg1(), myFrameManager.getArg2(), myFrameManager.getArg3());
                }
                
            }
            catch (Exception ex)
            {
                ComError = true;
            }
        }
        // Upload Motor and conexion state data
        private void UploadData(string Command, string Arg1, string Arg2, string Arg3)
        {
            switch (Command)
            {
                case "STM":
                    switch (Arg1)
                    {
                        case "CONO":
                            ConexionState = true;
                            ComError = false;
                            break;
                        case "DISO":
                            ConexionState = false;
                            ComError = true;
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

        // Send Order
        private void SendOrder(string Command, string Arg1, string Arg2, string Arg3)
        {
            try
            {
                string str;
                str = myFrameManager.Order(Command, Arg1, Arg2, Arg3);
                Data += str + "r/n/";
                mySerial.Write(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                mySerial.Close();
                ConexionState = false;
                ComError = true;
            }
        }

        // Modifier
        public void setComError(bool state) { ComError = state; }

        public void setNewDirection(string direction) { myMotor.setNewDirection(direction); }
        public void setNewOn(bool on) { myMotor.setNewOn(on); }
        public void setNewVelocity(int velocity) { myMotor.setCurrentVelocity(velocity);  }

        // Accessor
        public bool getConexionState() { return ConexionState; }
        public bool getComError() { return ComError; }

        public bool getMotorOn() { return myMotor.getnCurrentOn(); }
        public string getMotorDirection() { return myMotor.getCurrentDirection(); }
        public int getMotorVelocity() { return myMotor.getCurrentVelocity(); }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class ComManager
    {
        static DataMotor myMotor = new Motor();
        private string [] Data;
        public ComManager()
        {
            Data = new string[] {"", "", "", ""};
        }

        private string [] ReadData(string str)
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
            return S;
        }

        public void setDataMotor (string Direction, bool On, int Velocity)
        {
            myDataMotor.Direction = Direction;
            myDataMotor.On = On;
            myDataMotor.Velocity = Velocity;
        }
        public string getDirectionMotor() { return myDataMotor.Direction; }
        public string geOnMotor() { return myDataMotor.On; }
        public string geVelocityMotor() { return myDataMotor.Velocity; }
    }
}
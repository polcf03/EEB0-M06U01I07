using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class ComManager
    {
        static Motor myMotor = new Motor();
        static Motor myOrdersArd = new OrdersArd();
        private string [] Data;

        public ComManager()
        {
            Data = new string[] {"", "", "", ""};
        }

        // Read Serial data
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

        // Arduino Orders
        public string [] ReadData(string str)
        { 
            SaveData(str)
            return Data;
        }
        
        // Motor data acces
        private void setDataMotor (string Direction, bool On, int Velocity)
        {
            myDataMotor.Direction = Direction;
            myDataMotor.On = On;
            myDataMotor.Velocity = Velocity;
        }
        private string getDirectionMotor() { return myDataMotor.Direction; }
        private string geOnMotor() { return myDataMotor.On; }
        private string geVelocityMotor() { return myDataMotor.Velocity; }
    }
}
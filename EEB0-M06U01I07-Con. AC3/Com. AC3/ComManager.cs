using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class ComManager
    {
        
        public ComManager()
        {
            
        }

        private string [] ReadData(string str)
        {
            string [] S = {"", "", "", ""} ;
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
            while (c[i] != '$')
            {
                a += c[i];
                i++;
            }
            S[0] = a;
            a = "";
            while (c[i] != '&')
            {
                a += c[i];
                i++;
            }
            S[1] = a;
            a = "";
            while (c[i] != '%')
            {
                a += c[i];
                i++;
            }
            S[2] = a;
            a = "";
            while (c[i] != '#')
            {
                a += c[i];
                i++;
            }
            S[3] = a;
            a = "";
            return S;

        }
        public string Data (string [] str) 
        {
            string Data = "";
            switch(str[0])
            {
                case "STM":
                    switch (str[1])
                    {
                        case "CONO":
                            Data = "ArdConnected";
                            break;
                        case "DISO":
                            Data = "ArdDisonnected";
                            break;
                    }
                    break;

                case "MOV":
                    switch(str[1])
                    {
                        case "ON":
                            if(str[2] == "OK") Data = Motor encendido;
                    }
                    break;


            }
            return Data;
        }
        public void setData (string data)
        {
            
        }
    }
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Com.AC3
{
    class OrdersToSend
    {
        private string order;

        public OrdersToSend()
        {
            order = "";
        }


        // Order Modifiers
        public void OrderSTM(bool connect)
        {
            if (connect)
            {
                order = "#STM$CON&%#";
            }
            else
            {
                order = "#STM$DIS&%#";
            }
        }
        public void OrderCON(int Mode, bool dir, int vel)
        {
            switch (Mode)
            {
                case 0: 
                    if (dir)
                    {
                        order = "#CON$ON&RIG%" + vel.ToString() + "#";
                            
                    }
                    else
                    {
                        order = "#CON$ON&LFT%" + vel.ToString() + "#";
                    }
                    break;
                case 1:
                    order = "#CON$OFF&RIG%0#";
                    break;
                case 2:
                    order = "#CON$VEL&" + vel.ToString() + "&#";
                    break;
                case 3:
                    if (dir)
                    {
                        order = "#CON$DIR&RIG%#";

                    }
                    else
                    {
                        order = "#CON$DIR&LFT%#";
                    }
                    break;

            }
        }
        public void OrderINF()
        {
            order = "#INF$EST&%#";
        }

        //Order Access
        public string Order () { return order; }
    }
}

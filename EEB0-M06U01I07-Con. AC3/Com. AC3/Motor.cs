using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class Motor
    {
        private string Direction;
        private bool On;
        private int Velocity;

        public Motor()
     
        {
            Direction = "";
            On = false;
            velocity = 0;
        }
        
        public string Direction { get { return Direction; } set{ Direction = value; } }
        public bool On { get { return On; } set { On = value; } }
        public int Velocity { get { return Velocity; } set { Velocity = value; } }
    }
}

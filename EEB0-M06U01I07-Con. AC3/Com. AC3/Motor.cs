using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class Motor
    {
        private string direction;
        private bool on;
        private int velocity;

        public Motor()
        {
            direction = "";
            on = false;
            velocity = 0;
        }
        
        public string Direction { get { return direction; } set{ direction = value; } }
        public bool On { get { return on; } set { on = value; } }
        public int Velocity { get { return velocity; } set { velocity = value; } }
    }
}

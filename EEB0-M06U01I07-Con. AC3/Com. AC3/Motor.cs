using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class Motor
    {
        // Motor Propieties
        private bool direction;
        private bool on;
        private int velocity;

        // Constructor
        public Motor()
        {
            direction = true;
            on = false;
            velocity = 0;
        }
        
        // Motor access and modifiers
        public bool Direction { get { return direction; } set{ direction = value; } }
        public bool On { get { return on; } set { on = value; } }
        public int Velocity { get { return velocity; } set { velocity = value; } }
    }
}

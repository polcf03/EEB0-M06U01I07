using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class Motor
    {
        // Motor Propieties
        private string currentDirection;
        private bool currentOn;
        private int currentVelocity;

        private string newDirection;
        private bool newOn;
        private int newVelocity;

        // Constructor
        public Motor()
        {
            currentDirection = "";
            currentOn = false;
            currentVelocity = 0;

            newDirection = "";
            newOn = false;
            newVelocity = 0;
        }
        
        // Motor data updater
        public void updateDirection() { currentDirection = newDirection; newDirection = ""; }
        public void updateOn() { currentOn = newOn; newOn = false; }
        public void updateVelocity() { currentVelocity= newVelocity; newVelocity = 0; }

        // Current motor data accessor
        public string getCurrentDirection() { return currentDirection; }
        public bool getnCurrentOn() { return currentOn; }
        public int getCurrentVelocity() { return currentVelocity; }

        // Current motor data modifier
        public void setCurrentDirection(string direction) { currentDirection = direction; }
        public void setCurrentOn(bool on) { currentOn = on; }
        public void setCurrentVelocity(int velocity) { currentVelocity = velocity; }

        // New motor data accessor
        public string getNewDirection() { return newDirection; }
        public bool getnNewOn() { return newOn; }
        public int getNewVelocity() { return newVelocity; }

        // Current motor data modifier
        public void setNewDirection(string direction) { newDirection = direction; }
        public void setNewOn(bool on) { newOn = on; }
        public void setNewVelocity(int velocity) { newVelocity = velocity; }

        public void resetNewDirection() { newDirection = ""; }
        public void resetNewOn() { newOn = false; }
        public void resetNewVelocity() { newVelocity = 0; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class Data
    {
        static Data myData = new Data();
        string Direction = "";
        bool On = false;
        int velocity = 0;


        public Data()
        {
            string Direction = "";
            bool On = false;
            int velocity = 0;
        }
    }
}

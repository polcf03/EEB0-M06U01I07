using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.AC3
{
    class DataEventArgs : EventArgs
    {
        public string Data { get; set; }
        public bool Sended { get; set; }
        public bool Received { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Com.AC3
{

        public partial class Exporter : Form
        {
            private string data;

            public Exporter()
            {
                data = "";
            }

            private string getData()
            {
                return data;

            }
            private void setData(string txt)
            {
                data = txt;
            }

            public void addData(string txt, bool sended, bool received)
            {
                if (sended && !received)
                {
                    data += "/" + DateTime.Now.ToString() + "," + "Pc to Ard" + "," + txt;
                }
                else if (!received && sended)
                {
                    data += "/" + DateTime.Now.ToString() + "," + "Ard to Pc" + "," + txt;
                }
                else
                {

                }
            }
            public void export(string txt)
            {
                FileStream fs;
                fs = new FileStream(txt, FileMode.CreateNew);
                StreamWriter writetext = new StreamWriter(fs);
                writetext.WriteLine(data);
            }

            private void button1_Click(object sender, EventArgs e)
            {
                export(textBox1.Text);
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {

        Clocks clocks;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
            timer1.Interval = 1000;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            clocks = new Clocks(new Point(60, 60), new Point(540,180), graphics);
        }

        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked) return;
            if (clocks.Hours.crossed(e))
            {
                if (e.Delta > 0)
                {
                    clocks.Hours.Up();
                }
                else
                {
                    clocks.Hours.Down();
                }

            }
            else if (clocks.Mins.crossed(e))
            {
                if (e.Delta > 0)
                {
                    clocks.Mins.Up();
                }
                else
                {
                    clocks.Mins.Down();
                }
            }
            else if (clocks.Secs.crossed(e))
            {
                if (e.Delta > 0)
                {
                    clocks.Secs.Up();
                }
                else
                {
                    clocks.Secs.Down();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (clocks.Hours.time == 0 && clocks.Mins.time == 0 && clocks.Secs.time == 0) {
                timer1.Stop();
                checkBox1.Checked = false;
                MessageBox.Show("Time out");
                return;
            }
            if (clocks.Secs.time < 0)
            {
                clocks.Secs.time = 59;
                clocks.Mins.time -= 1;
                if (clocks.Mins.time < 0)
                {
                    clocks.Mins.time = 59;
                    clocks.Hours.time -= 1;
                    clocks.Hours.repaintUp();
                }
                clocks.Mins.repaintUp();
            } else
            {
                clocks.Secs.time -= 1;
                clocks.Secs.repaintUp();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) timer1.Start();
            else timer1.Stop();
        }
    }
}

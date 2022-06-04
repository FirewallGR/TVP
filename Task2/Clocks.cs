using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    class Clocks
    {
        Rectangle Background;
        Graphics graphics;
        Size clockSize;
        public Clock Hours, Mins, Secs;
        CheckBox checkBox1;
        Timer timer1;
        int width = 360;
        int height = 120;
        int offsetX, offsetY, hX, mX, sX, Y, sizeX, sizeY;


        public Clocks(int x, int y, Graphics graphics, Form1 form) 
        {
            this.graphics = graphics;
            Background = new Rectangle(x, y, x + width, y + height);
            offsetX = x;
            offsetY = y;
            sizeY = height;
            sizeX = sizeY;
            hX = offsetX;
            mX = offsetX + sizeX;
            sX = offsetX + width - sizeX;
            Y = offsetY;
            clockSize = new Size(sizeX,sizeY);

            checkBox1 = new CheckBox();
            checkBox1.Left = Background.X + Background.Width + 50;
            checkBox1.Top = Background.Y;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1.Parent = form;
            checkBox1.Visible = true;
            checkBox1.Text = "Start / Stop";

            form.MouseWheel += this_MouseWheel;

            timer1 = new Timer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = 1000;


            Paint();
        }

        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked) return;
            if (Hours.crossed(e))
            {
                if (e.Delta > 0)
                {
                    Hours.Up();
                }
                else
                {
                    Hours.Down();
                }

            }
            else if (Mins.crossed(e))
            {
                if (e.Delta > 0)
                {
                    Mins.Up();
                }
                else
                {
                   Mins.Down();
                }
            }
            else if (Secs.crossed(e))
            {
                if (e.Delta > 0)
                {
                    Secs.Up();
                }
                else
                {
                    Secs.Down();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) timer1.Start();
            else timer1.Stop();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Hours.time == 0 && Mins.time == 0 && Secs.time == 0)
            {
                timer1.Stop();
                checkBox1.Checked = false;
                MessageBox.Show("Time out");
                return;
            }
            if (Secs.time < 0)
            {
                Secs.time = 59;
                Mins.time -= 1;
                if (Mins.time < 0)
                {
                    Mins.time = 59;
                    Hours.time -= 1;
                    Hours.repaintUp();
                }
                Mins.repaintUp();
            }
            else
            {
                Secs.time -= 1;
                Secs.repaintUp();
            }
        }

        private void Paint()
        {
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(31, 117, 255)), Background);
            Hours = new Clock(graphics, new Rectangle(new Point(hX, Y), clockSize), Math.PI / 6);
            Hours.maxTicks = 12;
            Mins = new Clock(graphics, new Rectangle(new Point(mX, Y), clockSize), Math.PI / 30);
            Mins.maxTicks = 60;
            Secs = new Clock(graphics, new Rectangle(new Point(sX, Y), clockSize), Math.PI / 30);
            Secs.maxTicks = 60;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{               //TODO: MOUSE WHEEL EVENT И ОТСЧЕТ ПО НАЖАТИЮ
    class Clock
    {
        Pen black = new Pen(Color.Black);
        Pen bg = new Pen(Color.FromArgb(133, 180, 255));
        public int x, y, width, height, xCenter, yCenter;
        public int radius, len;
        public int time, maxTicks;
        public double currentAngle, step;
        Graphics graphics;
        public Clock(Graphics graphics, Rectangle rect, double step)
        {
            this.graphics = graphics;
            this.step = step;
            x = rect.X;
            y = rect.Y;
            width = rect.Width;
            height = rect.Height;
            xCenter = x + width / 2;
            yCenter = y + height / 2;
            currentAngle = Math.PI / 2;
            radius = width / 2;
            len = width / 2 - 30;
            time = 0;
            paint();
        }

        internal void Up()
        {
            graphics.DrawLine(bg, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
            currentAngle += step;
            graphics.DrawLine(black, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
            if (time == 0) time = maxTicks-1;
            time--;
        }

        internal void Down()
        {
            graphics.DrawLine(bg, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
            currentAngle -= step;
            graphics.DrawLine(black, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
            if (time == maxTicks) time = 0;
            time++;
        }

        internal void repaintUp()
        {
            graphics.DrawLine(bg, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
            currentAngle += step;
            graphics.DrawLine(black, xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)), (float)(yCenter - len * Math.Sin(currentAngle)));
        }

        internal bool crossed(MouseEventArgs e)
        {
            return x < e.X && x + width > e.X && y < e.Y && y + height > e.Y;
        }

        private void paint()
        {
            graphics.DrawEllipse(new Pen(new SolidBrush(Color.Black)), new Rectangle(new Point(x, y), new Size(width, height)));
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(133, 180, 255)), new Rectangle(new Point(x, y), new Size(width, height)));
            int i = (int)(Math.PI * 2 / step);
            for (; i >= 0; i--)
            {
                graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), xCenter, yCenter,(float) (xCenter + radius * Math.Cos(step * i)), (float)(yCenter - radius * Math.Sin(step * i)));
            }
            graphics.FillEllipse(new SolidBrush(Color.FromArgb(133, 180, 255)), new Rectangle(new Point(x + 10, y + 10), new Size(width - 20, height - 20)));
            graphics.DrawLine(new Pen(new SolidBrush(Color.Black)), xCenter, yCenter, (float)(xCenter + len * Math.Cos(currentAngle)),(float)(yCenter - len * Math.Sin(currentAngle)));
        }
    }
}

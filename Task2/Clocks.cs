using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Clocks
    {
        Rectangle Background;
        Graphics graphics;
        Size clockSize;
        public Clock Hours, Mins, Secs;

        int offsetX, offsetY, hX, mX, sX, Y, sizeX, sizeY;
        public Clocks(Point p1, Point p2, Graphics graphics) 
        {
            this.graphics = graphics;
            Background = new Rectangle(p1.X, p1.Y, p2.X, p2.Y);
            offsetX = p1.X;
            offsetY = p1.Y;
            sizeY = Background.Height;
            sizeX = sizeY;
            hX = offsetX;
            mX = offsetX + sizeX;
            sX = offsetX + Background.Width - sizeX;
            Y = offsetY;
            clockSize = new Size(sizeX,sizeY);
            Paint();
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3WinForms
{
    class GameObject
    {
        public Rectangle rect;
        Color color;

        public GameObject(int x, int y, int width, int height, Color color)
        {
            rect = new Rectangle(new Point(x, y), new Size(width, height));
            this.color = color;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(color), rect);
            g.DrawRectangle(Pens.Black, rect);
        }

        public bool crossed(int x, int y)
        {
            if (x < rect.Left || x > rect.Right)
                return false;
            if (y < rect.Top || y > rect.Bottom)
                return false;
            return true;
        }

        public bool Intersect(GameObject obj)
        {
            return rect.IntersectsWith(obj.rect);
        }
    }
}

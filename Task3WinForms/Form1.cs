using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3WinForms
{
    public partial class Form1 : Form
    {
        const int count = 5;

        List<GameObject> objects;
        GameObject obj;
        Graphics graphics;
        Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.LightBlue, Color.Blue, Color.Violet };
        Random rand = new Random();
        Size vert = new Size(90, 180);
        Size hor = new Size(180, 90);

        public Form1()
        {
            InitializeComponent();
            objects = new List<GameObject>();
            graphics = this.CreateGraphics();
            timer1.Interval = 500;
        }
        
        private void CreateObject()
        {
            int orientation = rand.Next(1, 3);
            int color = rand.Next(7);
            if (orientation == 1)
            {
                int x = rand.Next(0, this.Width - hor.Width);
                int y = rand.Next(0, this.Height - hor.Height);
                obj = new GameObject(x, y, hor.Width, hor.Height, colors[color]);
               
            }
            else
            {
                int x = rand.Next(this.Width - vert.Width);
                int y = rand.Next(this.Height - vert.Height);
                obj = new GameObject(x, y, vert.Width, vert.Height, colors[color]);

            }
            objects.Add(obj);
            //obj.Draw(graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (objects.Count == Math.Pow(count, 2))
            {
                timer1.Stop();
                MessageBox.Show("You lose");
                Invalidate();
                objects.Clear();
                return;
            }
            if (objects.Count == 0)
            {
                timer1.Stop();
                MessageBox.Show("You win");
                return;
            }
            CreateObject();
            Invalidate();
        }

        private void gameStart()
        {
            for (int i = 0; i < count; i++) CreateObject();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameStart();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                if (objects[i].crossed(e.X, e.Y))
                {
                    bool ok = true;
                    for (int j = i + 1; j < objects.Count; j++)
                    {
                        if (objects[i].Intersect(objects[j]))
                        {
                            ok = false;
                            break;
                        }
                            
                    }
                    if (ok)
                    {
                        objects.RemoveAt(i);
                        Invalidate();
                        //redraw();
                        break;
                    }
                }
            }
        }
        
        private void redraw()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(graphics);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < objects.Count; i++)
                objects[i].Draw(graphics);
        }
    }
}

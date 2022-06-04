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
        Clocks clocks1;
        Graphics graphics;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            clocks = new Clocks(60,60, graphics, this);
            clocks1 = new Clocks(60,480, graphics, this);
        } 
    }
}

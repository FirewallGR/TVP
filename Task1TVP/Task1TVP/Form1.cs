using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Task1TVP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActionBox.SelectedItem == null)
            {
                MessageBox.Show("Action can not be nothing");
                return;
            }
            if (Key.Text.Equals(""))
            {
                MessageBox.Show("Key value can not be null");
                return;
            }
            
            String text = richTextBox1.Text;
            char[] str = new char[text.Length];
            char temp;
            int mod;
            int div;
            int key;
            try
            {
                key = Convert.ToInt32(Key.Text);
            } catch (System.FormatException ex)
            {
                MessageBox.Show("Key value has to be a number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
            Boolean flag = false;
            if (ActionBox.SelectedItem.ToString().Equals("Encrypt"))
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >=65 && text[i] <= 90 || text[i] >= 97 && text[i] <= 122)
                    {
                        flag = true;
                        temp =(char) (text[i] + key);
                        div = (int)(temp / 123);
                        mod = (int)(temp % 123);
                        if (div >= 1)
                        {
                            if (mod >= 91 && mod <= 96) str[i] = (char)(65 + 7 + mod);
                            else str[i] = (char)(65 + mod);
                        } else
                        {
                            if (mod >= 91 && mod <= 96) str[i] = (char)(7 + mod);
                            else str[i] = (char)(mod);
                        }
                    } else
                    {
                        str[i] = text[i];
                    }

                  //  str[i] =(char) (text[i] + Convert.ToInt32(Key.Text));
                }
            } else
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] >= 65 && text[i] <= 122)
                    {
                        flag = true;
                        temp = (char)(text[i] - key);
                        div = (int)(temp / 123);
                        mod = (int)(temp % 123);
                        if (mod < 65)
                        {
                            if ((123 - 65 - temp) >= 91 && (123-65-temp) <=96) str[i] = (char)(123 - 65 - 7 - temp);
                            else str[i] = (char)(123 - (65 - temp));
                        }
                        else
                        {
                            if (temp >= 91 && temp <= 96) str[i] = (char)(temp - 7);
                            else str[i] = (char)(temp);
                        }
                    }
                    else
                    {
                        str[i] = text[i];
                    }

                    //  str[i] =(char) (text[i] + Convert.ToInt32(Key.Text));
                }
                
            }
            if (flag == true)
            {
                text = "";
                for (int i = 0; i < str.Length; i++)
                {
                    text += str[i];
                }
                richTextBox1.Text = text;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string text = File.ReadAllText(filename);
                richTextBox1.Text = text;
            } 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                File.WriteAllText(path, richTextBox1.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("Do you want exit the application?", " ", messageBoxButtons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color[] colors = { Color.Aqua, Color.CadetBlue, Color.BlueViolet };
            Random random = new Random();
            int num = random.Next(0, 3);
            this.BackColor = colors[num];
        }

        private void buttonStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            FlatStyle[] styles = { FlatStyle.Flat, FlatStyle.Popup, FlatStyle.Standard, FlatStyle.System };
            int i = rand.Next(0, 5);
            button1.FlatStyle = styles[i];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string player;
        Button[,] buttons = new Button[80, 80];

        public MainWindow()
        {
            InitializeComponent();
            player = "X";
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    Button button = new Button
                    {
                        Margin = new Thickness(20 * i, 20 * j, 0, 0),
                        VerticalAlignment = VerticalAlignment.Top,
                        HorizontalAlignment = HorizontalAlignment.Left,
                        Content = null,
                        Width = 20,
                        Height = 20
                    };
                    button.Click += onClick;
                    GameZone.Children.Add(button);
                    buttons[i, j] = button;
                }
            }
        }
        private void onClick(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (b.Content == null)
            {
                b.Content = player;
            }

            if (player == "X")
                player = "0";
            else player = "X";

            winCheck();
        }

        private void winCheck1(int i, int j)
        {
            
        }

        private void winCheck()
        {
            for (int i = 0; i < 80; i++)
            {
                bool flag = false;
                for (int j = 0; j < 80; j++)
                { 
                    if (player == buttons[i, j].Content && player == buttons[i-1, j].Content && player == buttons[i - 2, j].Content && player == buttons[i + 1, j].Content && player == buttons[i + 2, j].Content)
                    {
                        flag = true;
                        Win();
                        break;
                    }
                    if (player == buttons[i, j].Content && player == buttons[i, j-1].Content && player == buttons[i, j-2].Content && player == buttons[i, j+1].Content && player == buttons[i, j+2].Content)
                    {
                        flag = true;
                        Win();
                        break;
                    }

                    if (player == buttons[i,j].Content && player == buttons[i - 1,j - 1].Content && player == buttons[i - 2,j - 2].Content && player == buttons[i + 1, j + 1].Content && player == buttons[i + 2, j + 2].Content)
                    {
                        flag = true;
                        Win();
                        break;
                    }
                    if (player == buttons[i,j].Content && player == buttons[i - 1, j + 1].Content && player == buttons[i - 2,j + 2].Content && player == buttons[i + 1, j - 1].Content && player == buttons[i + 2, j - 2].Content )
                    {
                        flag = true;
                        Win();
                        break;
                    }
                }
                if (flag) break;
            }
        }

        private void Win()
        {
            for (int i = 0; i < 80; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                   // buttons[i, j].IsEnabled = false;
                }
            }
            MessageBox.Show(player + " wins\nTo start new game press 'Esc'");
        }

        private void Esc_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
            {
                if (e.IsDown)
                {
                    for (int i = 0; i < 80; i++)
                    {
                        for (int j = 0; j < 80; j++)
                        {
                            buttons[i, j].IsEnabled = true;
                            buttons[i, j].Content = null;  
                        }
                    }
                }
            }
            
        }
    }
}

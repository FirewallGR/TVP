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
using System.Windows.Threading;

namespace Task3WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Random rand;
        DispatcherTimer timer;
        const int interval = 500;
        const int count = 5;
        int formWidth;
        int formHeight;
        Color[] colors = { Colors.Red, Colors.Orange, Colors.Yellow, Colors.Green, Colors.LightBlue, Colors.Blue, Colors.Purple };
        Size hor = new Size(180, 90);
        Size vert = new Size(90, 180);

        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Tick += timer_Tick;

            formWidth = (int)this.Width;
            formHeight = (int)this.Height;
            gameStart();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            createObject();
            if (grid.Children.Count == Math.Pow(count,2))
            {
                timer.Stop();
                MessageBox.Show("You lose");
                grid.Children.Clear();
                gameStart();
                return;
            }
        }

        private void createObject()
        {
            int x, y;
            Rectangle obj = new Rectangle();
            int orientation = rand.Next(1, 3);
            int color = rand.Next(7);
            if (orientation == 1)
            {
                x = rand.Next(0,(int)(formWidth - hor.Width));
                y = rand.Next(0,(int)(formHeight - hor.Height));
                obj.Width = hor.Width;
                obj.Height = hor.Height;
            }
            else
            {
                x = rand.Next(0, (int)(formWidth - vert.Width));
                y = rand.Next(0, (int)(formHeight - vert.Height));
                obj.Width = vert.Width;
                obj.Height = vert.Height;
            }

            obj.HorizontalAlignment = HorizontalAlignment.Left;
            obj.VerticalAlignment = VerticalAlignment.Top;
            obj.Margin = new Thickness(x, y, 0, 0);
            obj.Stroke = new SolidColorBrush(Colors.Black);
            obj.Fill = new SolidColorBrush(colors[color]);
            obj.MouseLeftButtonDown += obj_MouseLeftButtonDown;
            grid.Children.Add(obj);
        }

        private void obj_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle obj = (Rectangle)sender;
            int index = grid.Children.IndexOf(obj);
            Rect senderArea = new Rect(obj.Margin.Left, obj.Margin.Top, obj.Width, obj.Height);
            for (int j = index + 1; j < grid.Children.Count; j++)
            {
                Rectangle comparable = (Rectangle)grid.Children[j];
                Rect comparableArea = new Rect(comparable.Margin.Left, comparable.Margin.Top, comparable.Width, comparable.Height);

                if (comparableArea.IntersectsWith(senderArea)) return;
            }
            grid.Children.Remove(obj);

            if (grid.Children.Count == 0)
            {
                timer.Stop();
                MessageBox.Show("You win");
                gameStart();
                return;
            }

        }

        private void gameStart()
        {
            for (int i = 0; i < count; i++)
            {
                createObject();
            }
            timer.Start();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            formWidth = (int)this.ActualWidth;
            formHeight = (int)this.ActualHeight;
        }
    }
}

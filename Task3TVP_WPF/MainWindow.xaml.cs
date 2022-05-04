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

namespace Task3TVP_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Canvas> list = new List<Canvas>();
        Random random = new Random();
        Color[] colors = { Colors.Red, Colors.Yellow, Colors.Green, Colors.Blue };
        public MainWindow()
        {
            InitializeComponent();
        }
        

        private void mouseClick(object sender, MouseButtonEventArgs e)
        {

        }


        private void timerTick(object sender, EventArgs e)
        {
            Canvas canvas = new Canvas();
            Rectangle rectangle = new Rectangle();
            int colorNum = random.Next(0, 3);
            rectangle.Fill = new SolidColorBrush(colors[colorNum]);
            int var = random.Next(1, 2);
            if (var == 1)
            {
                rectangle.Width = 100;
                rectangle.Height = 20;
            } else
            {
                rectangle.Width = 20;
                rectangle.Height = 100;
            }
            canvas.Children.Add(rectangle);
            Canvas.SetTop(canvas, random.Next(0, (int)(this.parentCanvas.Width - rectangle.Width)));
            Canvas.SetLeft(canvas, random.Next(0, (int)(this.parentCanvas.Width - rectangle.Width)));
            list.Add(canvas);
            parentCanvas.Children.Add(canvas);

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timerTick);
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }
    }
}

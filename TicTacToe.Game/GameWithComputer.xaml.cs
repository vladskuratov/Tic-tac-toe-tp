using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe.Game
{
    public partial class GameWithComputer : UserControl
    {
        public GameWithComputer()
        {
            InitializeComponent();

            InitializeComponent();

            for (int i = 2; i <= 3; i++)
                DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30);

            for (int i = 2; i <= 3; i++)
                DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30);

            DrawX(-0.1, 3.39);
            DrawO(-0.07, 4.36);

            label.Background = Brushes.LightCyan;
        }

        private void DrawX(double i, double j)
        {
            Line line = new Line();

            line = new Line();
            line.Stroke = Brushes.LightGray;
            line.StrokeThickness = 8;

            line.X1 = 30 + step * j + 20;
            line.X2 = 30 + step * (j + 1) - 20;
            line.Y1 = 30 + step * i + 20;
            line.Y2 = 30 + step * (i + 1) - 20;

            grid.Children.Add(line);


            line = new Line();
            line.Stroke = Brushes.LightGray;
            line.StrokeThickness = 8;

            line.X1 = 30 + step * (j + 1) - 20;
            line.X2 = 30 + step * j + 20;
            line.Y1 = 30 + step * i + 20;
            line.Y2 = 30 + step * (i + 1) - 20;

            grid.Children.Add(line);
        }

        private void DrawO(double i, double j)
        {
            Ellipse ellipse = new Ellipse();

            SolidColorBrush brush = new SolidColorBrush();

            ellipse.StrokeThickness = 8;
            ellipse.Stroke = Brushes.LightGray;

            ellipse.Width = 55;
            ellipse.Height = 55;

            Canvas.SetLeft(ellipse, 44 + step * j);
            Canvas.SetTop(ellipse, 44 + step * i);

            grid.Children.Add(ellipse);
        }

        public void DrawLine(double x1, double x2, double x3, double x4)
        {
            Line line = new Line();

            line = new Line();
            line.Stroke = Brushes.LightGray;
            line.StrokeThickness = 8;

            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = x3;
            line.Y2 = x4;

            grid.Children.Add(line);
        }

        public event Action<ScreenType> SwitchScreen;

        const int step = 85;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.StartScreen);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }
    }
}

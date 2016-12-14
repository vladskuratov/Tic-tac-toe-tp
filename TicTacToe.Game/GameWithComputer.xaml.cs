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

            Line line;

            for (int i = 2; i <= 3; i++)
            {
                line = new Line();
                line.Stroke = Brushes.LightGray;
                line.StrokeThickness = 8;

                line.X1 = 30;
                line.X2 = 85 * 4 - 55;
                line.Y1 = 85 * (i - 1) + 30;
                line.Y2 = 85 * (i - 1) + 30;

                grid.Children.Add(line);
            }

            for (int i = 2; i <= 3; i++)
            {
                line = new Line();
                line.Stroke = Brushes.LightGray;
                line.StrokeThickness = 8;

                line.Y1 = 30;
                line.Y2 = 85 * 4 - 55;
                line.X1 = 85 * (i - 1) + 30;
                line.X2 = 85 * (i - 1) + 30;

                grid.Children.Add(line);
            }
        }

        public event Action<int> SwitchScreen;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(0);
        }
    }
}

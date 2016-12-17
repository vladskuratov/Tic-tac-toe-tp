using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe.Game
{
    class DrawActions : IDrawActions
    {
        public void DrawX(double i, double j, int step, Canvas grid)
        {
            var line = new Line();

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

        public void DrawO(double i, double j, int step, Canvas grid)
        {
            var ellipse = new Ellipse();

            ellipse.StrokeThickness = 8;
            ellipse.Stroke = Brushes.LightGray;

            ellipse.Width = 55;
            ellipse.Height = 55;

            Canvas.SetLeft(ellipse, 44 + step * j);
            Canvas.SetTop(ellipse, 44 + step * i);

            grid.Children.Add(ellipse);
        }

        public void DrawLine(double x1, double x2, double x3, double x4, Canvas grid)
        {
            var line = new Line();

            line.Stroke = Brushes.LightGray;
            line.StrokeThickness = 8;

            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = x3;
            line.Y2 = x4;

            grid.Children.Add(line);
        }
    }
}

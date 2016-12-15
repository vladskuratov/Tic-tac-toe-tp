using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TicTacToe.Game
{
    public partial class GameWithFriend : UserControl
    {
        public GameWithFriend()
        {
            InitializeComponent();

            for (int i = 2; i <= 3; i++)
                DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30);

            for (int i = 2; i <= 3; i++)
                DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30);

            DrawX(-0.1, 3.39);
            DrawO(-0.07, 4.36);

            label.Background = Brushes.LightCyan;
        }

        public event Action<ScreenType> SwitchScreen;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.StartScreen);
        }

        const int X = 1;
        const int O = 2;
        const int step = 85;

        bool isFieldBlocked = false;
        int[,] field = new int[3, 3];
        int playerPuts = X;

        int stepsMade = 0;

        int xWins = 0;
        int oWins = 0;

        private void grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!isFieldBlocked)
            {
                int x = (int)e.GetPosition(null).X;
                int y = (int)e.GetPosition(null).Y;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ((y >= 30 + step * i) && (y <= 30 + step * (i + 1)))
                        {
                            if ((x >= 30 + step * j) && (x <= 30 + step * (j + 1)))
                            {
                                if (field[i, j] == 0)
                                {
                                    field[i, j] = playerPuts;
                                    stepsMade++;

                                    if (playerPuts == X)
                                    {
                                        DrawX(i, j);
                                    }
                                    else
                                    {
                                        DrawO(i, j);
                                    }

                                    if (CheckForWinOrDraw() == false)
                                    {
                                        SwapStep();
                                        break;
                                    }
                                    else break;

                                }
                            }
                        }
                    }
                }
            }
        }

        private void SwapStep()
        {
            playerPuts++;
            if (playerPuts == 3)
            {
                playerPuts = 1;

                label1.Background = null;
                label.Background = Brushes.LightCyan;
            }
            else
            {
                label.Background = null;
                label1.Background = Brushes.LightCyan;
            }
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

        private bool? CheckForWinOrDraw()
        {
            if (stepsMade < 5) return false;

            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] && field[i, 2] != 0)
                {
                    Win(i, 2, 2);
                    return true;
                }

                else if (field[0, i] == field[1, i] && field[1, i] == field[2, i] && field[2, i] != 0)
                {
                    Win(2, i, 3);
                    return true;
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[2, 2] != 0)
            {
                Win(2, 2, 0);
                return true;
            }

            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0] && field[2, 0] != 0)
            {
                Win(2, 0, 1);
                return true;
            }

            if (stepsMade >= 9)
            {
                Draw();
                return null;
            }

            return false;
        }

        private void Win(int y, int x, int pos)
        {
            isFieldBlocked = true;

            if (pos == 0) DrawLine(30, 30 + 85 * 3, 30, 30 + 85 * 3);
            if (pos == 1) DrawLine(30 + 85 * 3, 30, 30, 30 + 85 * 3);
            if (pos == 2) DrawLine(30, 85 * 3 + 30, 30 + 85 * y + 85 / 2, 30 + 85 * y + 85 / 2);
            if (pos == 3) DrawLine(30 + 85 * x + 85 / 2, 30 + 85 * x + 85 / 2, 30, 85 * 3 + 30);

            MessageBox.Show(string.Format("Выиграл {0}", (field[y, x] == 1) ? "крестик" : "нолик"), "Партия!");

            if (field[y, x] == X)
            {
                xWins++;
                button2.Content = xWins.ToString();
            }

            if (field[y, x] == O)
            {
                oWins++;
                button3.Content = oWins.ToString();
            }
        }

        private void Draw()
        {
            isFieldBlocked = true;

            MessageBox.Show("Произошла ничья", "Партия!");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var line in grid.Children.OfType<Line>().ToList())
            {
                grid.Children.Remove(line);
            }

            foreach (var ellipse in grid.Children.OfType<Ellipse>().ToList())
            {
                grid.Children.Remove(ellipse);
            }

            for (int i = 2; i <= 3; i++)
                DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30);

            for (int i = 2; i <= 3; i++)
                DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30);

            DrawX(-0.1, 3.39);
            DrawO(-0.07, 4.36);

            label.Background = Brushes.LightCyan;
            label1.Background = null;

            isFieldBlocked = false;

            field = new int[3, 3];
            playerPuts = X;

            stepsMade = 0;     
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(sender, e);

            button2.Content = 0;
            button3.Content = 0;

            xWins = 0;
            oWins = 0;
        }
    }
}

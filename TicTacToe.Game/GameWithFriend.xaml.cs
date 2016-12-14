using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Linq;

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
        }

        public event Action<int> SwitchScreen;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(0);
        }

        bool isFieldBlocked = false;
        int step = 85;

        int[,] field = new int[3, 3];
        static int X = 1;
        static int O = 2;
        static int playerPuts = X;

        int stepsMade = 0;

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

                                    SwapStep();
                                    CheckForWin();
                                    break;
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
            }
        }

        private void DrawX(int i, int j)
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

        private void DrawO(int i, int j)
        {
            Ellipse ellipse = new Ellipse();

            SolidColorBrush brush = new SolidColorBrush();

            ellipse.StrokeThickness = 8;
            ellipse.Stroke = Brushes.LightGray;

            ellipse.Width = 65;
            ellipse.Height = 65;

            Canvas.SetLeft(ellipse, 40 + step * j);
            Canvas.SetTop(ellipse, 40 + step * i);

            grid.Children.Add(ellipse);
        }

        private void CheckForWin()
        {
            if (stepsMade >= 9)
            {
                Draw();
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] && field[i, 2] != 0)
                {
                    Win(i, 2, 2);
                    return;
                }

                else if (field[0, i] == field[1, i] && field[1, i] == field[2, i] && field[2, i] != 0)
                {
                    Win(2, i, 3);
                    return;
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[2, 2] != 0)
            {
                Win(2, 2, 0);
                return;
            }

            if (field[2, 0] == field[1, 1] && field[1, 1] == field[2, 0] && field[2, 0] != 0)
            {
                Win(2, 0, 1);
                return;
            }
        }

        private void Win(int y, int x, int pos)
        {
            // 0 - diagonal 1
            // 1 - diagonal 2
            // 2 - horizontal
            // 3 - vertical

            isFieldBlocked = true;

            if (pos == 0) DrawLine(30, 30 + 85 * 3, 30, 30 + 85 * 3);
            if (pos == 1) DrawLine(30 + 85 * 3, 30, 30, 30 + 85 * 3);
            if (pos == 2) DrawLine(30, 85 * 3 + 30, 30 + 85 * y + 85 / 2, 30 + 85 * y + 85 / 2);
            if (pos == 3) DrawLine(30 + 85 * x + 85 / 2, 30 + 85 * x + 85 / 2, 30, 85 * 3 + 30);

            if (field[y, x] == X) MessageBox.Show("show smth..........");
        }

        public void DrawLine(int x1, int x2, int x3, int x4)
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

        private void Draw()
        {
            isFieldBlocked = true;
        }
    }
}


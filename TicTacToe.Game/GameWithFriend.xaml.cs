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

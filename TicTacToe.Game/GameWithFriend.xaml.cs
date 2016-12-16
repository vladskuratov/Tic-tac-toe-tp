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
                da.DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30, grid);

            for (int i = 2; i <= 3; i++)
                da.DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30, grid);

            da.DrawX(-0.1, 3.39, step, grid);
            da.DrawO(-0.07, 4.36, step, grid);

            label.Background = Brushes.LightCyan;
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
                                        da.DrawX(i, j, step, grid);
                                    }
                                    else
                                    {
                                        da.DrawO(i, j, step, grid);
                                    }

                                    if (gp.CheckForWinOrDraw(field, stepsMade, ref isFieldBlocked, ref pos) == true)
                                    {
                                        Win(i, j, pos);
                                        return;
                                    }

                                    if (gp.CheckForWinOrDraw(field, stepsMade, ref isFieldBlocked, ref pos) == false)
                                    {
                                        SwapStep();
                                        return;
                                    }

                                    if (gp.CheckForWinOrDraw(field, stepsMade, ref isFieldBlocked, ref pos) == null)
                                    {
                                        gp.Draw(ref isFieldBlocked);
                                        return;
                                    }
                                }
                                else return;
                            }
                        }
                    }
                }
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.StartScreen);
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
                da.DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30, grid);

            for (int i = 2; i <= 3; i++)
                da.DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30, grid);

            da.DrawX(-0.1, 3.39, step, grid);
            da.DrawO(-0.07, 4.36, step, grid);

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

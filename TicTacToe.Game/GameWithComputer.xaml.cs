using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
                da.DrawLine(30, 85 * 3 + 30, 85 * (i - 1) + 30, 85 * (i - 1) + 30, grid);

            for (int i = 2; i <= 3; i++)
                da.DrawLine(85 * (i - 1) + 30, 85 * (i - 1) + 30, 30, 85 * 3 + 30, grid);
        }

        private void grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!isFieldBlocked)
            {
                if (!computersTurn)
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
                                        field[i, j] = userPuts;

                                        if (stepsMade == 0)
                                        {
                                            radioButton.IsEnabled = false;
                                            radioButton1.IsEnabled = false;
                                            checkBox.IsEnabled = false;
                                        }

                                        stepsMade++;

                                        if (userPuts == X)
                                        {
                                            da.DrawX(i, j, step, grid);
                                        }
                                        else
                                        {
                                            da.DrawO(i, j, step, grid);
                                        }

                                        if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == true)
                                        {
                                            Win(i, j, pos);
                                            return;
                                        }

                                        if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == false)
                                        {
                                            computersTurn = true;
                                            ComputersTurn();
                                            return;
                                        }

                                        if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == null)
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
                else ComputersTurn();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.StartScreen);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            radioButton.IsEnabled = true;
            radioButton1.IsEnabled = true;
            checkBox.IsEnabled = true;

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

            isFieldBlocked = false;

            field = new int[3, 3];

            checkBox.IsChecked = false;
            computersTurn = false;

            if (radioButton.IsChecked == true)
            {
                userPuts = X;
                computerPuts = O;
            }
            else
            {
                userPuts = O;
                computerPuts = X;
            }

            stepsMade = 0;
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            button1_Click(sender, e);

            button2.Content = 0;
            button3.Content = 0;

            userWins = 0;
            computerWins = 0;
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            computersTurn = true;

            if (stepsMade == 0)
            {
                radioButton.IsEnabled = false;
                radioButton1.IsEnabled = false;
                checkBox.IsEnabled = false;
            }

            grid_MouseLeftButtonDown(sender, null);
        }

        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            computersTurn = false;
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            userPuts = O;
            computerPuts = X;
        }

        private void radioButton_Checked(object sender, RoutedEventArgs e)
        {
            userPuts = X;
            computerPuts = O;
        }
    }
}

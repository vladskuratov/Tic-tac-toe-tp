using System;
using System.Windows;
using System.Windows.Media;

namespace TicTacToe.Game
{
    public partial class GameWithFriend
    {
        IDrawActions da = Factory.Default.GetDrawActions();

        public event Action<ScreenType> SwitchScreen;

        const int X = 1;
        const int O = 2;
        const int step = 85;

        bool isFieldBlocked = false;
        int[,] field = new int[3, 3];
        int playerPuts = X;

        int stepsMade = 0;

        int xWins = 0;
        int oWins = 0;

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

            if (pos == 0) da.DrawLine(30, 30 + 85 * 3, 30, 30 + 85 * 3, grid);
            if (pos == 1) da.DrawLine(30 + 85 * 3, 30, 30, 30 + 85 * 3, grid);
            if (pos == 2) da.DrawLine(30, 85 * 3 + 30, 30 + 85 * y + 85 / 2, 30 + 85 * y + 85 / 2, grid);
            if (pos == 3) da.DrawLine(30 + 85 * x + 85 / 2, 30 + 85 * x + 85 / 2, 30, 85 * 3 + 30, grid);

            if (field[y, x] == X) button2.Content = ++xWins;
            if (field[y, x] == O) button3.Content = ++oWins;

            MessageBox.Show(string.Format("Выиграл {0}", (field[y, x] == X) ? "крестик" : "нолик"), "Партия!");
        }

        private void Draw()
        {
            isFieldBlocked = true;

            MessageBox.Show("Произошла ничья", "Партия!");
        }
    }
}

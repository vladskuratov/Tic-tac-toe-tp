using System;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe.Game
{
    public partial class GameWithComputer
    {
        IDrawActions da = Factory.Default.GetDrawActions();

        public event Action<ScreenType> SwitchScreen;

        const int X = 1;
        const int O = 2;
        const int step = 85;

        bool isFieldBlocked = false;
        bool computersTurn = false;
        int[,] field = new int[3, 3];
        int userPuts = X;
        int computerPuts = O;

        int stepsMade = 0;

        int userWins = 0;
        int computerWins = 0;

        IComputerBrain cb;

        private async void ComputersTurn()
        {
            cb = Factory.Default.GetComputerBrain();

            await Task.Delay(250);

            int x = cb.MyTurnYX(field)[1];
            int y = cb.MyTurnYX(field)[0];

            field[y, x] = computerPuts;
            stepsMade++;

            if (computerPuts == X)
            {
                da.DrawX(y, x, step, grid);
            }
            else
            {
                da.DrawO(y, x, step, grid);
            }

            if (CheckForWinOrDraw() == false)
            {
                computersTurn = false;
                return;
            }
            else return;
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

        private async void Win(int y, int x, int pos)
        {
            isFieldBlocked = true;

            if (pos == 0) da.DrawLine(30, 30 + 85 * 3, 30, 30 + 85 * 3, grid);
            if (pos == 1) da.DrawLine(30 + 85 * 3, 30, 30, 30 + 85 * 3, grid);
            if (pos == 2) da.DrawLine(30, 85 * 3 + 30, 30 + 85 * y + 85 / 2, 30 + 85 * y + 85 / 2, grid);
            if (pos == 3) da.DrawLine(30 + 85 * x + 85 / 2, 30 + 85 * x + 85 / 2, 30, 85 * 3 + 30, grid);

            if (field[y, x] == computerPuts) button3.Content = ++computerWins;
            if (field[y, x] == userPuts) button2.Content = ++userWins;

            await Task.Delay(250);

            MessageBox.Show(string.Format("Выиграл {0}", (field[y, x] == userPuts) ? "ты" : "компьютер"), "Партия!");
        }

        private void Draw()
        {
            isFieldBlocked = true;

            MessageBox.Show("Произошла ничья", "Партия!");
        }
    }
}

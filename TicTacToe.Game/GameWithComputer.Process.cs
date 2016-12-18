using System;
using System.Threading.Tasks;
using System.Windows;

namespace TicTacToe.Game
{
    public partial class GameWithComputer
    {
        IComputerBrain cb = Factory.Default.GetComputerBrain();
        IDrawActions da = Factory.Default.GetDrawActions();
        IGameProcessing gp = Factory.Default.GetGameProcessing();

        public event Action<ScreenType> SwitchScreen;

        int pos = -1;

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

        private async void ComputersTurn()
        {
            computersTurn = false;

            int x = cb.MyTurnYX(field)[1];
            int y = cb.MyTurnYX(field)[0];

            field[y, x] = computerPuts;
            stepsMade++;

            if (computerPuts == X)
            {
                await Task.Delay(250);
                da.DrawX(y, x, step, grid);
            }
            else
            {
                await Task.Delay(250);
                da.DrawO(y, x, step, grid);
            }

            if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == true)
            {
                Win(y, x, pos);
                return;
            }

            if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == false)
                return;

            if (gp.CheckForWinOrDraw(field, stepsMade, ref pos) == null)
            {
                isFieldBlocked = true;
                Draw();
                return;
            }
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
            MessageBox.Show(string.Format("{0} wins", (field[y, x] == userPuts) ? "You" : "Computer"), "Game!");
        }

        public async void Draw()
        {
            await Task.Delay(250);
            MessageBox.Show("It's draw...", "Game!");
        }
    }
}

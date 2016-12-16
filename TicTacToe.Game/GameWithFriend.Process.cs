using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TicTacToe.Game
{
    public partial class GameWithFriend
    {
        IDrawActions da = Factory.Default.GetDrawActions();
        IGameProcessing gp = Factory.Default.GetGameProcessing();

        public event Action<ScreenType> SwitchScreen;

        int pos = -1;

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

        private async void Win(int y, int x, int pos)
        {
            isFieldBlocked = true;

            if (pos == 0) da.DrawLine(30, 30 + 85 * 3, 30, 30 + 85 * 3, grid);
            if (pos == 1) da.DrawLine(30 + 85 * 3, 30, 30, 30 + 85 * 3, grid);
            if (pos == 2) da.DrawLine(30, 85 * 3 + 30, 30 + 85 * y + 85 / 2, 30 + 85 * y + 85 / 2, grid);
            if (pos == 3) da.DrawLine(30 + 85 * x + 85 / 2, 30 + 85 * x + 85 / 2, 30, 85 * 3 + 30, grid);

            if (field[y, x] == X) button2.Content = ++xWins;
            if (field[y, x] == O) button3.Content = ++oWins;

            await Task.Delay(250);

            MessageBox.Show(string.Format("Выиграл {0}", (field[y, x] == X) ? "крестик" : "нолик"), "Партия!");
        }
    }
}

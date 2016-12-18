namespace TicTacToe.Game
{
    public class GameProcessing : IGameProcessing
    {
        public bool? CheckForWinOrDraw(int[,] field, int stepsMade, ref int pos)
        {
            // True - win situation
            // Null - draw situation
            // False - nothing happend]

            // Position 2 - horizontal win
            // Position 3 - vertical win
            // Position 0 - main diagonal win
            // Position 1 - adverce diagonal win

            if (stepsMade < 5) return false;

            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2] && field[i, 2] != 0)
                {
                    pos = 2;
                    return true;
                }

                else if (field[0, i] == field[1, i] && field[1, i] == field[2, i] && field[2, i] != 0)
                {
                    pos = 3;
                    return true;
                }
            }

            if (field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[2, 2] != 0)
            {
                pos = 0;
                return true;
            }

            if (field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0] && field[2, 0] != 0)
            {
                pos = 1;
                return true;
            }

            if (stepsMade >= 9)
                return null;

            return false;
        }
    }
}

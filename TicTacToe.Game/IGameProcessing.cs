namespace TicTacToe.Game
{
    interface IGameProcessing
    {
        bool? CheckForWinOrDraw(int[,] field, int stepsMade, ref int pos);
    }
}

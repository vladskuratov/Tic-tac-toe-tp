namespace TicTacToe.Game
{
    interface IGameProcessing
    {
        void Draw();
        bool? CheckForWinOrDraw(int[,] field, int stepsMade, ref int pos);
    }
}

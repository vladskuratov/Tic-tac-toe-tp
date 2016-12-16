namespace TicTacToe.Game
{
    interface IGameProcessing
    {
        void Draw(ref bool isFieldBlocked);
        bool? CheckForWinOrDraw(int[,] field, int stepsMade, ref int pos);
    }
}

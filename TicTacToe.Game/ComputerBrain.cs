namespace TicTacToe.Game
{
    class ComputerBrain : IComputerBrain
    {
        public int[] MyTurnYX(int[,] field)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] == 0)
                    {
                        return new int[2] { i, j };
                    }
                }
            }

            return null;
        }
    }
}

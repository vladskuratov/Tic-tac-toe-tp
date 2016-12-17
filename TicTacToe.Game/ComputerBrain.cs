namespace TicTacToe.Game
{
    class ComputerBrain : IComputerBrain
    {
        public int[] MyTurnYX(int[,] f)
        {
            for (int i = 0; i < 3; i++)
            {
                // Checking rows for the presence of two values (not 0)
                if (f[i, 0] == f[i, 1] && f[i, 1] != 0 && f[i, 2] == 0) return new int[2] { i, 2 };
                if (f[i, 0] == f[i, 2] && f[i, 2] != 0 && f[i, 1] == 0) return new int[2] { i, 1 };
                if (f[i, 1] == f[i, 2] && f[i, 2] != 0 && f[i, 0] == 0) return new int[2] { i, 0 };

                // Columns
                if (f[0, i] == f[1, i] && f[1, i] != 0 && f[2, i] == 0) return new int[2] { 2, i };
                if (f[0, i] == f[2, i] && f[2, i] != 0 && f[1, i] == 0) return new int[2] { 1, i };
                if (f[1, i] == f[2, i] && f[2, i] != 0 && f[0, i] == 0) return new int[2] { 0, i };
            }

            // Main diagonal
            if (f[0, 0] == f[1, 1] && f[1, 1] != 0 && f[2, 2] == 0) return new int[2] { 2, 2 };
            if (f[0, 0] == f[2, 2] && f[2, 2] != 0 && f[1, 1] == 0) return new int[2] { 1, 1 };
            if (f[1, 1] == f[2, 2] && f[2, 2] != 0 && f[0, 0] == 0) return new int[2] { 0, 0 };

            // Adverce diagonal
            if (f[0, 2] == f[1, 1] && f[1, 1] != 0 && f[2, 0] == 0) return new int[2] { 2, 0 };
            if (f[0, 2] == f[2, 0] && f[2, 0] != 0 && f[1, 1] == 0) return new int[2] { 1, 1 };
            if (f[1, 1] == f[2, 0] && f[2, 0] != 0 && f[0, 2] == 0) return new int[2] { 0, 2 };

            // Center
            if (f[1, 1] == 0) return new int[2] { 1, 1 };

            // Corners
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (f[i, j] == 0 && (i + j) % 2 == 0) return new int[2] { i, j };
                }
            }

            // Other
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (f[i, j] == 0) return new int[2] { i, j };
                }
            }

            return null;
        }
    }
}

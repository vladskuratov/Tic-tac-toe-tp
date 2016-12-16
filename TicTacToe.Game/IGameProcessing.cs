using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Game
{
    interface IGameProcessing
    {
        void Draw(ref bool isFieldBlocked);
        bool? CheckForWinOrDraw(int[,] field, int stepsMade, ref bool isFieldBlocked, ref int pos);
    }
}

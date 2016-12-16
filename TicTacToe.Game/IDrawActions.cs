using System.Windows.Controls;

namespace TicTacToe.Game
{
    interface IDrawActions
    {
        void DrawX(double i, double j, int step, Canvas grid);
        void DrawO(double i, double j, int step, Canvas grid);
        void DrawLine(double x1, double x2, double x3, double x4, Canvas grid);
    }
}

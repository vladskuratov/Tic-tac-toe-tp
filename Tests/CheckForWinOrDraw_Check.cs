﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToe.Game;

namespace Tests
{
    [TestClass]
    public class CheckForWinOrDraw_Check
    {
        GameProcessing gp = new GameProcessing();

        int test_pos = 0; // doesn't matter
        const int X = 1;
        const int O = 2;

        int StepsMade()
        {
            int s = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (test_field[i, j] != 0) s++;
                }
            }
            return s;
        }

        bool? win = true;
        bool? draw = null;
        bool? nothing = false;

        /// ////////////////////////////////////////////
        int[,] test_field = new int[,] {
                                        {0, X, 0},
                                        {0, X, O},
                                        {0, X, O}
                                       };

        /// ////////////////////////////////////////////

        [TestMethod]
        public void CheckForWinOrDraw()
        {
            var testedValue = gp.CheckForWinOrDraw(test_field, StepsMade(), ref test_pos);

            Assert.AreEqual(win, testedValue);
        }
    }
}

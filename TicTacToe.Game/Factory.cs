﻿namespace TicTacToe.Game
{
    class Factory
    {
        private Factory() { }

        static Factory _default;

        public static Factory Default
        {
            get
            {
                if (_default == null)
                    _default = new Factory();
                return _default;
            }
        }

        IComputerBrain _cb = new ComputerBrain();
        IDrawActions _da = new DrawActions();
        IGameProcessing _ga = new GameProcessing();

        public IComputerBrain GetComputerBrain()
        {
            return _cb;
        }

        public IDrawActions GetDrawActions()
        {
            return _da;
        }

        public IGameProcessing GetGameProcessing()
        {
            return _ga;
        }
    }
}

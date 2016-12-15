namespace TicTacToe.Game
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

        public IComputerBrain GetComputerBrain()
        {
            return _cb;
        }
    }
}

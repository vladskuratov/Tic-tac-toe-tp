using System.Windows;

namespace TicTacToe.Game
{
    public partial class MainWindow : Window
    {
        StartScreen ss = new StartScreen();
        GameWithFriend gf = new GameWithFriend();
        GameWithComputer gc = new GameWithComputer();

        public MainWindow()
        {
            InitializeComponent();

            ss.SwitchScreen += SwitchScreenImpl;
            gf.SwitchScreen += SwitchScreenImpl;
            gc.SwitchScreen += SwitchScreenImpl;

            contentControl.Content = ss;
        }

        public void SwitchScreenImpl(int s)
        {
            if (s == 0) contentControl.Content = ss;
            if (s == 1) contentControl.Content = gf;
            if (s == 2) contentControl.Content = gc;
        }
    }
}

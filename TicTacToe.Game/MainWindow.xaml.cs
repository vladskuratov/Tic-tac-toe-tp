using System.Windows;

namespace TicTacToe.Game
{
    public enum ScreenType
    {
        StartScreen,
        GameWithFriend,
        GameWithComputer
    }

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

        public void SwitchScreenImpl(ScreenType screen)
        {
            if (screen == ScreenType.StartScreen) contentControl.Content = ss;
            if (screen == ScreenType.GameWithFriend) contentControl.Content = gf;
            if (screen == ScreenType.GameWithComputer) contentControl.Content = gc;
        }
    }
}

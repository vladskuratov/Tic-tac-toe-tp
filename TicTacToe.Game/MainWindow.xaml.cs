using System.Threading.Tasks;
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
            contentControl.Margin = new Thickness { Left = 0 };
        }

        public async void SwitchScreenImpl(ScreenType screen)
        {
            contentControl.Margin = new Thickness{ Left = 0 };

            if (screen == ScreenType.StartScreen) contentControl.Content = ss;
            if (screen == ScreenType.GameWithFriend) contentControl.Content = gf;
            if (screen == ScreenType.GameWithComputer) contentControl.Content = gc;

            //for (int i = 400; i < 0; i--)
            //{
            //    //await Task.Delay(5);
            //    contentControl.Margin = new Thickness { Left = i };
            //}
        }
    }
}

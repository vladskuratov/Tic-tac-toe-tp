using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

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
            int d, r;

            if (screen != ScreenType.StartScreen)
            {
                contentControl2.Margin = new Thickness { Left = 525 };

                if (screen == ScreenType.GameWithFriend) contentControl2.Content = gf;
                if (screen == ScreenType.GameWithComputer) contentControl2.Content = gc;

                d = 0;
                r = 525;
                var timer = new DispatcherTimer();
                timer.Tick += delegate
                {
                    contentControl.Margin = new Thickness { Left = d -= 50 };
                    contentControl2.Margin = new Thickness { Left = r -= 25 };
                    if (contentControl2.Margin.Left == 0) timer.Stop();
                };

                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Start();
            }
            else
            {
                d = -1050;
                r = 0;
                var timer = new DispatcherTimer();
                timer.Tick += delegate
                {
                    contentControl.Margin = new Thickness { Left = d += 50 };
                    contentControl2.Margin = new Thickness { Left = r += 25 };
                    if (contentControl.Margin.Left == 0) timer.Stop();
                };

                timer.Interval = TimeSpan.FromMilliseconds(1);
                timer.Start();
            }
        }
    }
}

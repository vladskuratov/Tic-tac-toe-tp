using System;
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

            // Move to the right screens
            if (screen != ScreenType.StartScreen)
            {
                if (screen == ScreenType.GameWithFriend) contentControl2.Content = gf;
                if (screen == ScreenType.GameWithComputer) contentControl2.Content = gc;

                contentControl2.Margin = new Thickness { Left = 525 };

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
            // Move to the left screen (start)
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

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe.Game
{
    public partial class StartScreen : UserControl
    {
        public StartScreen()
        {
            InitializeComponent();

            label.Background = Brushes.LightCyan;
        }

        public event Action<ScreenType> SwitchScreen;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.GameWithFriend);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(ScreenType.GameWithComputer);
        }
    }
}

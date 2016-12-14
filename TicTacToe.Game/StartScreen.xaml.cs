using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe.Game
{
    public partial class StartScreen : UserControl
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        public event Action<int> SwitchScreen;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(1);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SwitchScreen?.Invoke(2);
        }
    }
}

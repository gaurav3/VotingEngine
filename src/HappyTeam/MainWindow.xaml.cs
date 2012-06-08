using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hardcodet.Wpf.TaskbarNotification;

namespace HappyTeam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Hide();

            DataContext = new MainWindowViewModel();

            ShowBalloon();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //clean up notifyicon (would otherwise stay open until application finishes)
            MainNotifyIcon.Dispose();

            base.OnClosing(e);
        }

        private void ShowBalloon()
        {
            string title = "Happy Team";
            string text = "I'll be right here!";

            MainNotifyIcon.ShowBalloonTip(title, text, Hardcodet.Wpf.TaskbarNotification.BalloonIcon.Info);

            Thread.Sleep(4000);
            MainNotifyIcon.HideBalloonTip();
        }


    }
}

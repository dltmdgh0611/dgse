using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace dgse
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer myTimer = new DispatcherTimer();
        DateTime nowtime = new DateTime();
        public MainWindow()
        {
            InitializeComponent();
            myTimer.Interval = new TimeSpan(0, 0, 1);
            myTimer.Tick += myTimer_Tick;
            myTimer.Start();
        }

        void myTimer_Tick(object sender, EventArgs e)

        {
            nowtime = DateTime.Now;
            Time_lb.Content = nowtime.ToString("tt hh:mm");
            Day_lb.Content = nowtime.ToString("yyyy-mm-dd ddd요일");
        }


        private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void Close_bt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DgswSite_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.dgsw.hs.kr");
        }
        private void Nas_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://10.64.160.114:5000/");
        }
        private void Checking_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://dgsw.meistergo.co.kr/cert/");
        }
        private void CodeUp_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://codeup.kr/index.php");
        }
        private void Band_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://band.us/home");
        }
        private void Classroom_bt_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://classroom.google.com/");
        }
        private void Minimode_bt_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}

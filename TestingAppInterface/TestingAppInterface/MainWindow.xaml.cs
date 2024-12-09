using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestingAppInterface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;


        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public static class WindowStateManeger
        {
            public static WindowState WindowState { get; set; } = WindowState.Maximized;
            public static WindowStyle WindowStyle { get; set; }= WindowStyle.SingleBorderWindow;

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ButtonTraining_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainwindow = new MainWindow();
            //Window1 window = new Window1(this.Width, this.Height);

            //mainwindow.Close();
            //window.ShowDialog();
            //NavigationService nav = new NavigationService;
            //nav 
            var mainmenu = new MainWindow();
            var window2 = new Training();
            window2.Show();
            mainmenu.Close();

            //Content = null;
            //Content = window2.Content;
            
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonTesting_Click(object sender, RoutedEventArgs e)
        {
            var window1 = new Window1();
            Content = null;
            Content = window1.Content;

        }
    }
}



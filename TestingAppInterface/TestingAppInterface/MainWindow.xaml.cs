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
        Window _currentWindow;
        public MainWindow(Window currentWindow)
        {
            InitializeComponent();
            _currentWindow = currentWindow;
            this.Closing += MainWindow_Closing;
        }
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWindow_Closing;
            _currentWindow = this;
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
            var trainingWindow = new Training(_currentWindow);
            _currentWindow.Content = null;
            _currentWindow.Content = trainingWindow.Content;
        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonTesting_Click(object sender, RoutedEventArgs e)
        {
            var testingWindow = new Testing(_currentWindow);
            _currentWindow.Content = null;
            _currentWindow.Content = testingWindow.Content;

        }
    }
}



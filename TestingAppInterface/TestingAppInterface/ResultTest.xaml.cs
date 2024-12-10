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
using System.Windows.Shapes;

namespace TestingAppInterface
{
    /// <summary>
    /// Логика взаимодействия для ResultTest.xaml
    /// </summary>
    public partial class ResultTest : Window
    {
        Window _currentWindow;
        public ResultTest(Window currentWindow)
        {
            InitializeComponent();
            _currentWindow = currentWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var mainwindow = new MainWindow();
            //var Result = new ResultTest();
            //mainwindow.Show();
            //Result.Close();
            var mainWindow = new MainWindow(_currentWindow);
            //var current = Application.Current.Windows.
            _currentWindow.Content = null;
            _currentWindow.Content = mainWindow.Content;
        }
        public static class WindowStateManeger
        {
            public static WindowState WindowState { get; set; } = WindowState.Maximized;
            public static WindowStyle WindowStyle { get; set; } = WindowStyle.SingleBorderWindow;

        }

        private void AnswerGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

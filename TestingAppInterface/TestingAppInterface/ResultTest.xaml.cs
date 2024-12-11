using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TranslationOfInfUnits;

namespace TestingAppInterface
{
    /// <summary>
    /// Логика взаимодействия для ResultTest.xaml
    /// </summary>
    public partial class ResultTest : Window
    {
        Window _currentWindow;
        public ResultTest(Window currentWindow, List<TaskResult> results)
        {
            InitializeComponent();
            _currentWindow = currentWindow;
            foreach (var taskResult in results)
            {
                ResultGrid.Items.Add(taskResult);
                if (taskResult.IsCorrect)
                {
                    ResultGrid.RowBackground = Brushes.Green;
                }
                else
                {
                    ResultGrid.RowBackground = Brushes.Red;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow(_currentWindow);
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

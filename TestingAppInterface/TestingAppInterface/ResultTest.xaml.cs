using Microsoft.Win32;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TranslationOfInfUnits;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.IO;

namespace TestingAppInterface
{
    /// <summary>
    /// Логика взаимодействия для ResultTest.xaml
    /// </summary>
    public partial class ResultTest : Window
    {
        Window _currentWindow;
        List<TaskResult> _results = new List<TaskResult>();
        public ResultTest(Window currentWindow, List<TaskResult> results)
        {
            InitializeComponent();
            _currentWindow = currentWindow;
            _results = results;
            foreach (var taskResult in _results)
            {
                ResultGrid.Items.Add(taskResult);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var saveresult = MessageBox.Show("Хотите сохранить данные из таблицы перед выходом?", "Сохранение данных", MessageBoxButton.YesNo, MessageBoxImage.Question);
            var mainWindow = new MainWindow(_currentWindow);
            if (saveresult == MessageBoxResult.Yes)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Сохранение данных в выбранный файл
                    MessageBox.Show("Данные успешно сохранены.", "Сохранение завершено", MessageBoxButton.OK, MessageBoxImage.Information);
                    var save = new SaveResult();
                    save.Save(_results, saveFileDialog.FileName + ".pdf");
                    //File.SetAttributes(saveFileDialog.FileName, FileAttributes.ReadOnly);
                }
                else
                {
                    MessageBox.Show("Сохранение отменено.", "Сохранение отменено", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            _currentWindow.Content = null;
            _currentWindow.Content = mainWindow.Content;
            //var saveresult = MessageBox.Show("Хотите сохранить данные из таблицы перед выходом?", "Сохранение данных", MessageBoxButton.YesNo, MessageBoxImage.Question);
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

﻿using System.Windows;

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
            public static WindowStyle WindowStyle { get; set; }= WindowStyle.None;

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
        private void ChangeWindow(Window newWindow)
        {
            _currentWindow.Content = null;
            _currentWindow.Content = newWindow.Content;
        }
    }
}



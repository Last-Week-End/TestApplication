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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1(double width, double height)
        {
            InitializeComponent();
            this.Width = width;
            this.Height = height;
        }
        public Window1()
        {
            InitializeComponent();
            
        }

        private void ButtonTraining_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FinishTest_Click(object sender, RoutedEventArgs e)
        {
            var Test = new Window1();
            var Result = new ResultTest();
            //Content = null;
            //Content = Result.Content;
            Result.Show();
            Test.Close();
        }
    }
}

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
using TranslationOfInfUnits;

namespace TestingAppInterface
{
    /// <summary>
    /// Логика взаимодействия для Testing.xaml
    /// </summary>
   
    public partial class Testing : Window
    {
        public Window _currentWindow;
        Exercise _exercise;
        bool flag = false; 
        public List<(string,string,string,bool)> testData = new List<(string, string, string, bool)> ();
        int currentTask = 0;

        public Testing()
        {
            InitializeComponent();
        }
        public Testing( Window currentWindow)
        {
            InitializeComponent();
            LastTaskTest.Visibility = Visibility.Hidden;

            _currentWindow = currentWindow;
            _exercise = new Exercise(new GeneratorTranslate());
            ExerciseTestTextBlock.Text = _exercise.Data;
        }
        public void InitTestList()
        {
            for (int i = 0; i < 20; i++)
            {
                if(i < 10)
                {
                    _exercise = new Exercise(new GeneratorTranslate());
                    testData.Add((_exercise.Data, _exercise.Answer, "", false));
                }
                else
                {
                    _exercise = new Exercise(new GeneratorComparison());
                    testData.Add((_exercise.Data, _exercise.Answer, "", false));
                }
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            LastTaskTest.Visibility = Visibility.Visible;
            if (currentTask == 20) NextTaskTest.Visibility = Visibility.Hidden;
            else NextTaskTest.Visibility = Visibility.Visible;
            currentTask++;
            bool IsCorrect = CheckAnswer.Check(_exercise.Answer, YourAnswerTestTextBox.Text);
            testData.Add((_exercise.Data, _exercise.Answer, YourAnswerTestTextBox.Text, IsCorrect));
            if (flag)
            {
                _exercise = new Exercise(new GeneratorTranslate());
                ExerciseTestTextBlock.Text = _exercise.Data;
                flag = false;
            }
            else
            {
                _exercise = new Exercise(new GeneratorComparison());
                ExerciseTestTextBlock.Text = _exercise.Data;
                //CorrectAnswerTextBlock.Text = _exercise.Answer;
                flag = true;
            }
            YourAnswerTestTextBox.Text = "";
        }

        private void FinishTest_Click(object sender, RoutedEventArgs e)
        {
            //var Test = new Testing(_currentWindow);
            var Result = new ResultTest(_currentWindow);
            //var current = Application.Current.Windows.
            _currentWindow.Content = null;
            _currentWindow.Content = Result.Content;
            //Result.Show();
            //Test.Close();
        }

       

        private void AnswerTAsk_Click(object sender, RoutedEventArgs e)
        {
            bool IsCorrect = CheckAnswer.Check(_exercise.Answer, YourAnswerTestTextBox.Text);
            testData.Add((_exercise.Data, _exercise.Answer, YourAnswerTestTextBox.Text, IsCorrect));
        }

        private void LastTaskTest_Click(object sender, RoutedEventArgs e)
        {
            if(currentTask == 0) LastTaskTest.Visibility = Visibility.Hidden;
            else LastTaskTest.Visibility = Visibility.Visible;
            currentTask--;
            YourAnswerTestTextBox.Text = testData[currentTask].Item3;
            ExerciseTestTextBlock.Text = testData[currentTask].Item1;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {  
            if (YourAnswerTestTextBox.Text.Length > 15)
            {
                YourAnswerTestTextBox.Text = YourAnswerTestTextBox.Text.Substring(0, 15);
            }
            try
            {
                long.Parse(YourAnswerTestTextBox.Text);
            }
            catch
            {
                //YourAnswerTextBox.Text = YourAnswerTextBox.Text.Substring(0, YourAnswerTextBox.Text.Length - 2);
                //YourAnswerTextBox.Text = "";
            }
                
        }
    }
}

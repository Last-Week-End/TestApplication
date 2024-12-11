using System.Windows;
using System.Windows.Controls;
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
        public List<TaskResult> testData = new List<TaskResult> ();
        int currentTask = 1;

        public Testing()
        {
            InitializeComponent();
        }
        public Testing( Window currentWindow)
        {
            InitializeComponent();
            LastTaskTest.Visibility = Visibility.Hidden;
            _currentWindow = currentWindow;
            testData = TasksForTest.Generate();
            UpdateTask();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            LastTaskTest.Visibility = Visibility.Visible;

            if (currentTask == 20) NextTaskTest.Visibility = Visibility.Hidden;
            else NextTaskTest.Visibility = Visibility.Visible;

            UpdateTestData();
            currentTask++;

            UpdateTask();

        }
        private void FinishTest_Click(object sender, RoutedEventArgs e)
        {
            testData[currentTask].UserAnswer = YourAnswerTestTextBox.Text;
            var Result = new ResultTest(_currentWindow,testData);
            _currentWindow.Content = null;
            _currentWindow.Content = Result.Content;
        }
        private void AnswerTAsk_Click(object sender, RoutedEventArgs e)
        {
            bool IsCorrect = CheckAnswer.Check(_exercise.Answer, YourAnswerTestTextBox.Text);
            var taskResult = new TaskResult(_exercise.Data, _exercise.Answer, YourAnswerTestTextBox.Text, IsCorrect);
            testData.Add(taskResult);
        }
        private void LastTaskTest_Click(object sender, RoutedEventArgs e)
        {
            currentTask--;

            if (currentTask == 1) LastTaskTest.Visibility = Visibility.Hidden;
            else LastTaskTest.Visibility = Visibility.Visible;

            UpdateTask();
        }
        private void UpdateTask()
        {
            TaskCounterTextBlock.Text = $"{currentTask}/20";
            ExerciseTestTextBlock.Text = testData[currentTask - 1].ExerciseData;
            YourAnswerTestTextBox.Text = testData[currentTask - 1].UserAnswer;
        }
        private void UpdateTestData()
        {
            bool IsCorrect = CheckAnswer.Check(testData[currentTask - 1].CorrectAnswer, YourAnswerTestTextBox.Text);
            var taskResult = new TaskResult(testData[currentTask - 1].ExerciseData, testData[currentTask - 1].CorrectAnswer, YourAnswerTestTextBox.Text, IsCorrect);

            testData[currentTask - 1] = taskResult;
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

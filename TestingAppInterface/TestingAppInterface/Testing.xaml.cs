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
        public List<TaskResult> _testData = new List<TaskResult> ();
        int _currentTask = 1;

        public Testing()
        {
            InitializeComponent();
        }
        public Testing( Window currentWindow)
        {
            InitializeComponent();
            LastTaskTest.Visibility = Visibility.Hidden;
            _currentWindow = currentWindow;
            _testData = TasksForTest.Generate();
            UpdateTask();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            LastTaskTest.Visibility = Visibility.Visible;

            if (_currentTask == 20) NextTaskTest.Visibility = Visibility.Hidden;
            else NextTaskTest.Visibility = Visibility.Visible;

            Update_testData();
            _currentTask++;
            UpdateTask();
        }
        private void FinishTest_Click(object sender, RoutedEventArgs e)
        {
            _testData[_currentTask -1].UserAnswer = YourAnswerTestTextBox.Text;
            var Result = new ResultTest(_currentWindow,_testData);
            _currentWindow.Content = null;
            _currentWindow.Content = Result.Content;
        }
        private void LastTaskTest_Click(object sender, RoutedEventArgs e)
        {
            Update_testData();
            _currentTask--;

            if (_currentTask == 1) LastTaskTest.Visibility = Visibility.Hidden;
            else LastTaskTest.Visibility = Visibility.Visible;

            UpdateTask();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputProcessing.CorrectInput(sender);
        }
        private void UpdateTask()
        {
            TaskCounterTextBlock.Text = $"{_currentTask}/20";
            ExerciseTestTextBlock.Text = _testData[_currentTask - 1].ExerciseData;
            YourAnswerTestTextBox.Text = _testData[_currentTask - 1].UserAnswer;
        }
        private void Update_testData()
        {
            bool IsCorrect = CheckAnswer.Check(_testData[_currentTask - 1].CorrectAnswer, YourAnswerTestTextBox.Text);
            var taskResult = new TaskResult(_testData[_currentTask - 1].ExerciseData, _testData[_currentTask - 1].CorrectAnswer, YourAnswerTestTextBox.Text, IsCorrect);

            _testData[_currentTask - 1] = taskResult;
        }
        
    }
}

using System.Windows;
using System.Windows.Media;
using TranslationOfInfUnits;
using Windows.UI;

namespace TestingAppInterface
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class Training : Window
    {
        public Window _currentWindow;
        Exercise _exercise;

        //GeneratorComparison generatorComparison = new GeneratorComparison();
        //GeneratorTranslate generatorTranslate = new GeneratorTranslate();
        bool flag = false;
        public Training()
        {
            InitializeComponent();
        }
        public Training(Window currentWindow)
        {
            InitializeComponent();
            _currentWindow = currentWindow;
            _exercise = new Exercise(new GeneratorTranslate());
            ExerciseTextBlock.Text = _exercise.Data;
            CorrectAnswerTextBlock.Visibility = Visibility.Hidden;
        }
        private void FinishTheTraining_Click(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow(_currentWindow);
            _currentWindow.Content = null;
            _currentWindow.Content = main.Content;
        }

        private void NextTask_Click(object sender, RoutedEventArgs e)
        {
            YourAnswerTextBox.Background = Brushes.White;
            CorrectAnswerTextBlock.Text = "";
            CorrectAnswerTextBlock.Visibility = Visibility.Hidden;
            YourAnswerTextBox.Text = "";
            if (flag)
            {
                _exercise = new Exercise(new GeneratorTranslate());
                ExerciseTextBlock.Text = _exercise.Data;
                flag = false;
            }
            else
            {
                _exercise = new Exercise(new GeneratorComparison());
                ExerciseTextBlock.Text = _exercise.Data;
                //CorrectAnswerTextBlock.Text = _exercise.Answer;
                flag = true;
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            CorrectAnswerTextBlock.Visibility = Visibility.Visible;
            CorrectAnswerTextBlock.Text = _exercise.Answer;
            if (YourAnswerTextBox.Text == CorrectAnswerTextBlock.Text)
            {
                YourAnswerTextBox.Background = Brushes.Green;
            }
            else
            {
                YourAnswerTextBox.Background = Brushes.Red;
            }
        }
              

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
            if(YourAnswerTextBox.Text.Length > 15)
            {
                YourAnswerTextBox.Text = YourAnswerTextBox.Text.Substring(0, 15);
            }
            try
            {
                long.Parse(YourAnswerTextBox.Text);
            }
            catch
            {
                //YourAnswerTextBox.Text = YourAnswerTextBox.Text.Substring(0, YourAnswerTextBox.Text.Length - 2);
                //YourAnswerTextBox.Text = "";
            }
        }
    }
}

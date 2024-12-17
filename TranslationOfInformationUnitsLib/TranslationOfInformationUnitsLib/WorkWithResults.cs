using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace TranslationOfInfUnits
{
    public class SaveResult
    {
        public void Save(List<TaskResult> testData, string path)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont font = new XFont("Arial", 11);

            // Начальные координаты для текста
            double x = 50; // Позиция по горизонтали
            double y = 50; // Позиция по вертикали

            for (int i = 0; i < testData.Count; i++)
            {
                gfx.DrawString($"Задание {i + 1}", font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку
                gfx.DrawString(testData[i].ExerciseData, font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку
                gfx.DrawString("Ваш ответ: " + testData[i].UserAnswer, font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку
                gfx.DrawString("Правильный ответ: " + testData[i].CorrectAnswer, font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку

                // Если текст выходит за пределы страницы, добавляем новую страницу
                if (y + 20 > page.Height)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = 50; // Сбрасываем позицию по вертикали
                }
            }
            document.Save(path);
        }
    }
    public class TaskResult
    {
        public string ExerciseData { get; private set; }
        public string CorrectAnswer { get; private set; }
        public string UserAnswer { get; set; }
        public bool IsCorrect { get; private set; }
        public TaskResult(string exerciseData, string correctAnswer, string userAnswer, bool isCorrect)
        {
            ExerciseData = exerciseData;
            CorrectAnswer = correctAnswer;
            UserAnswer = userAnswer;
            IsCorrect = isCorrect;
        }
    }
    public static class CountCorrectAnswer
    {
        public static int Count(List<TaskResult> testData)
        {
            int count = 0;
            for (int i = 0; i < testData.Count; i++)
            {
                if (testData[i].IsCorrect) count++;
            }
            return count;
        }
    }

}

using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.UniversalAccessibility.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace TranslationOfInfUnits
{
    public static class Translate
    {
        public static Number TranslateTo(Number number, string type)
        {
            switch (type)
            {
                case "Бит":
                    return ToBit(number);

                case "Байт":
                    return ToByte(number);

                case "Кбайт":
                    return ToKbyte(number);

                case "Мбайт":
                    return ToMbyte(number);

                case "Гбайт":
                    return ToGbyte(number); ;
            }
            return number;
        }
        public static Number ToBit(Number number)
        {
            switch (number.Type)
            {
                case "Бит":
                    return number;

                case "Байт":
                    return new Number("Бит", number.Value * 8);

                case "Кбайт":
                    return new Number("Бит", number.Value * 8192);

                case "Мбайт":
                    return new Number("Бит", number.Value * 8388608);

                case "Гбайт":
                    return new Number("Бит", number.Value * 8589934592);
            }
            return number;
        }
        private static Number ToByte(Number number)
        {
            number = new Number("Байт", ToBit(number).Value / 8);
            return number;
        }
        private static Number ToKbyte(Number number)
        {
            number = new Number("Кбайт", ToBit(number).Value / 8192);
            return number;
        }
        private static Number ToMbyte(Number number)
        {
            number = new Number("Мбайт", ToBit(number).Value / 8388608);
            return number;
        }
        private static Number ToGbyte(Number number)
        {
            number = new Number("Гбайт", ToBit(number).Value / 8589934592);
            return number;
        }
    }
    public class Number
    {
        public string Type { get; private set; }
        public long Value { get; private set; }
        public Number(string type, long value)
        {
            Type = type;
            Value = value;
        }
        public Number()
        {
            Type = "notype";
            Value = 0;
        }
        public static bool operator >(Number number1, Number number2)
        {
            return
            number1.Value > number2.Value;
        }
        public static bool operator <(Number number1, Number number2)
        {
            return number1.Value < number2.Value;
        }
    }
    public class Exercise
    {
        public string Data { get; private set; }
        public string Answer { get; private set; }
        public Exercise(IGenerator generator)
        {
            (string, string) AllData = generator.GenerateAllData();
            Data = AllData.Item1;
            Answer = AllData.Item2;
        }
        public Exercise()
        {
            Data = "no content";
            Answer = "no content";
        }
    }
    public class RandomNumber
    {
        private readonly Dictionary<string, int> units = new Dictionary<string, int>
        {
            { "notype", 0 },
            { "Бит", 1 },
            { "Байт", 2 },
            { "Кбайт", 3 },
            { "Мбайт", 4 },
            { "Гбайт", 5 },
        };
        Random random = new Random();
        public Number GenerateNumber(Number inputNumber)
        {
            string newType = GenerateType(inputNumber.Type);
            long newValue = GenerateValue(inputNumber, newType);
            return new Number(newType, newValue);
        }

        public string GenerateType(string currentType)
        {
            if (currentType == "notype")
            {
                return units.ElementAt(random.Next(1, units.Count)).Key;
            }
            else
            {
                int currentIndex = units[currentType];
                int newIndex = currentIndex;
                if (currentIndex == 1)
                {
                    newIndex = 2;
                    newIndex = random.Next(2, 4);
                }
                else if (currentIndex == 5)
                {
                    newIndex = 4;
                }
                else
                {
                    while (currentIndex == newIndex)
                    {
                        newIndex = random.Next(currentIndex - 1, currentIndex + 2);
                    }
                }
                return units.ElementAt(newIndex).Key;
            }
        }

        private long GenerateValue(Number inputNumber, string newType)
        {
            if (inputNumber.Value == 0)
            {
                return random.Next(10000, 100001);
            }
            else
            {
                int currentIndex = units[inputNumber.Type];
                int newIndex = units[newType];

                if (currentIndex == 1)
                {
                    if (newIndex == 2)
                    {
                        return random.Next(1000, 10000);
                    }
                    else if (newIndex == 3)
                    {
                        return random.Next(10, 100);
                    }
                }
                else if (newIndex > currentIndex)
                {
                    return random.Next(10, 100);
                }
                else if (newIndex < currentIndex)
                {
                    return random.Next(10000000, 100000000);
                }
                return 0;
            }
        }
    }
    public static class CheckAnswer
    {
        public static bool Check(string exerciseAnswer, string userAnswer)
        {
            if (exerciseAnswer == userAnswer)
            {
                return true;
            }
            else return false;
        }
    }
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

            // Разбиваем текст на строки, чтобы уместить его на странице
            //string[] lines = text.Split(new[] { '\n' }, StringSplitOptions.None);

            for (int i =0;i<testData.Count;i++)
            {
                gfx.DrawString($"Задание {i+1}", font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку
                gfx.DrawString(testData[i].ExerciseData, font, XBrushes.Black, x, y);
                y += 20; // Переходим на следующую строку
                gfx.DrawString("Ваш ответ: "+testData[i].UserAnswer, font, XBrushes.Black, x, y);
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

            // Сохраняем PDF-документ
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
    public class CountCorrectAnswer
    {
        public int count;
        public int Count(List<TaskResult> testData)
        {
            for (int i = 0; i < testData.Count; i++)
            {
                if(testData[i].IsCorrect) count++;
            }
            return count;
        }
    }
    public static class TasksForTest
    {
        public static List<TaskResult> Generate()
        {
            var _exercise = new Exercise();
            var testData = new List<TaskResult>();
            for (int i = 0; i < 20; i++)
            {
                if (i < 10)
                {
                    _exercise = new Exercise(new GeneratorTranslate());
                    var taskResult = new TaskResult(_exercise.Data, _exercise.Answer, "", false);
                    testData.Add(taskResult);
                }
                else
                {
                    _exercise = new Exercise(new GeneratorComparison());
                    var taskResult = new TaskResult(_exercise.Data, _exercise.Answer, "", false);
                    testData.Add(taskResult);
                }
            }
            return testData;
        }
        
    }
}

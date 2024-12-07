namespace TranslationOfInfUnits
{
    public interface IGenerator
    {
        public (string,string) GenerateAllData();
    }
    public class GeneratorTranslate : IGenerator
    {
        public (string,string) GenerateAllData()
        {
            RandomNumber random = new RandomNumber();

            List<Number> exerciseData = new List<Number>()
            {
                random.GenerateNumber(new Number())
            };
            string type = random.GenerateType(exerciseData[0].Type);
            string answer = GenerateAnswer(exerciseData, type);
            string exerciseText = $"Переведите {exerciseData[0].Value} {exerciseData[0].Type} в {type}. " +
                                  $"Ответ округлите до целых.";
            return (exerciseText,answer);
        }
        public string GenerateAnswer(List<Number> exerciseData, string type)
        {
            RandomNumber random = new RandomNumber();
            return Translate.TranslateTo(exerciseData[0], type).Value.ToString() + " " + type.ToString();
        }
    }
    public class GeneratorComparison : IGenerator
    {
        public (string,string) GenerateAllData()
        {
            RandomNumber random = new RandomNumber();
            Number firstNumber = random.GenerateNumber(new Number());
            Number secondNumber = random.GenerateNumber(firstNumber);

            List<Number> exerciseData = new List<Number>()
            {
                firstNumber,
                secondNumber
            };
            string answer = GenerateAnswer(exerciseData);
            string exerciseText = $"Сравните {exerciseData[0].Value} {exerciseData[0].Type} и " +
                                  $"{exerciseData[1].Value} {exerciseData[1].Type}. " +
                                  $"В ответе напишите >, < или =. ";
            return (exerciseText,answer);
        }
        public string GenerateAnswer(List<Number> exerciseData)
        {
            if (Translate.ToBit(exerciseData[0]) > Translate.ToBit(exerciseData[1]))
            {
                return ">";
            }
            else if (Translate.ToBit(exerciseData[0]) < Translate.ToBit(exerciseData[1]))
            {
                return "<";
            }
            else return "=";
        }
    }
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
        public void Save(List<(string,string,string)> testData, string path)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                for (int i  = 0; i < testData.Count; i++)
                {
                    sw.WriteLine($"Задание {i + 1}.");
                    sw.WriteLine(testData[0]);
                    sw.WriteLine($"Правильный ответ: {testData[1]}");
                    sw.WriteLine($"Ваш ответ: {testData[1]}\n");
                }
            }
        }
    }
}

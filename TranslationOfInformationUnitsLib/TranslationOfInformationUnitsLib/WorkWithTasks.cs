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

using System;
namespace TranslationOfInfUnits
{
    public interface IGenerator
    {
        public List<Number> GenerateData();
        public string GenerateAnswer(List<Number> exerciseData);
    }
    public class GeneratorTranslate : IGenerator
    {
        public List<Number> GenerateData()
        {
            RandomNumber random = new RandomNumber();

            List<Number> exerciseData = new List<Number>()
            {
                random.GenerateNumber(new Number())
            };
            return exerciseData;
        }
        public string GenerateAnswer(List<Number> exerciseData)
        {
            RandomNumber random = new RandomNumber();
            string type = random.GenerateType(exerciseData[0].Type);
            return Translate.TranslateTo(exerciseData[0], type).Value.ToString() + " " + type.ToString();
        }
    }
    public class GeneratorComparison : IGenerator
    {
        public List<Number> GenerateData()
        {
            RandomNumber random = new RandomNumber();
            Number firstNumber = random.GenerateNumber(new Number());
            Number secondNumber = random.GenerateNumber(firstNumber);

            List<Number> exerciseData = new List<Number>()
            {
                firstNumber,
                secondNumber
            };
            return exerciseData;
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
                case "bit":
                    return ToBit(number);

                case "byte":
                    return ToByte(number);

                case "kbyte":
                    return ToKbyte(number);

                case "mbyte":
                    return ToMbyte(number);

                case "gbyte":
                    return ToGbyte(number); ;
            }
            return number;
        }
        public static Number ToBit(Number number)
        {
            switch (number.Type)
            {
                case "bit":
                    return number;

                case "byte":
                    return new Number("bit", number.Value * 8);

                case "kbyte":
                    return new Number("bit", number.Value * 8192);

                case "mbyte":
                    return new Number("bit", number.Value * 8388608);

                case "gbyte":
                    return new Number("bit", number.Value * 8589934592);
            }
            return number;
        }
        private static Number ToByte(Number number)
        {
            number = new Number("byte", ToBit(number).Value / 8);
            return number;
        }
        private static Number ToKbyte(Number number)
        {
            number = new Number("kbyte", ToBit(number).Value / 8192);
            return number;
        }
        private static Number ToMbyte(Number number)
        {
            number = new Number("mbyte", ToBit(number).Value / 8388608);
            return number;
        }
        private static Number ToGbyte(Number number)
        {
            number = new Number("gbyte", ToBit(number).Value / 8589934592);
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
        public List<Number> ExerciseData { get; private set; }
        public string Answer { get; private set; }
        public Exercise(IGenerator generator)
        {
            ExerciseData = generator.GenerateData();
            Answer = generator.GenerateAnswer(ExerciseData);
        }
    }
    public class RandomNumber
    {
        private readonly Dictionary<string, int> units = new Dictionary<string, int>
        {
            { "notype", 0 },
            { "bit", 1 },
            { "byte", 2 },
            { "kbyte", 3 },
            { "mbyte", 4 },
            { "gbyte", 5 },
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
}

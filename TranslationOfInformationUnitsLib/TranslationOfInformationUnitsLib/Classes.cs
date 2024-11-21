namespace TranslationOfInfUnits
{
    public interface IGenerator
    {
        public  List<Number> GenerateData();
        public string GenerateAnswer(List<Number> exerciseData);
    }
    public class GeneratorTranslate : IGenerator
    {
        public  List<Number> GenerateData()
        {
            RandomNumber random = new RandomNumber();

            List<Number> exerciseData = new List<Number>()
            {
                random.Generate()
            };
            return exerciseData;
        }
        public string GenerateAnswer(List<Number> exerciseData)
        {
            RandomNumber random = new RandomNumber();
            string type = random.RandomNumberType(0,5);
            return Translate.TranslateTo(exerciseData[0], type).Value.ToString() + " " +type.ToString();
        }
    }
    public class GeneratorComparison: IGenerator
    {
        public List<Number> GenerateData()
        {
            RandomNumber random = new RandomNumber();
            
            List<Number> exerciseData = new List<Number>() 
            {
                random.Generate(),
                random.Generate()
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
            switch (number.NumberType)
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
            number = new Number("byte",ToBit(number).Value/8);
            return number;
        }
        private static Number ToKbyte(Number number)
        {
            number = new Number("kbyte",ToBit(number).Value/ 8192);
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
    public class RandomNumber
    {
        private List<string> InformationType = new List<string>()
        {
            "bit",
            "byte",
            "kbyte",
            "mbyte",
            "gbyte"
        };
        public Number Generate()
        {
            Random random = new Random();
            string informationType = RandomNumberType(0,5);
            Number number = new Number();

            if (informationType == "bit")
            {
                number = new Number(informationType, random.Next(100, 10000));
            }
            else if (informationType == "byte")
            {
                number = new Number(informationType, random.Next(100, 10000));
            }
            else if (informationType == "kbyte")
            {
                number = new Number(informationType, random.Next(100, 10000));
            }
            else if (informationType == "mbyte")
            {
                number = new Number(informationType, random.Next(100, 10000));
            }
            else if (informationType == "gbyte")
            {
                number = new Number(informationType, random.Next(100, 10000));
            }
            return number;
        }
        public string RandomNumberType(int start, int end)
        {
            return InformationType[new Random().Next(start, end)];
        }
    }
    public class Number
    {
        public string NumberType { get; private set; }
        public long Value { get; private set; }
        public Number(string numberType,long value)
        {
            NumberType = numberType;
            Value = value;
        }
        public Number()
        {
            NumberType = "notype";
            Value = -1;
        }
        public static bool operator >(Number number1, Number number2)
        {
            return number1.Value > number2.Value;
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
    
}

namespace TranslationOfInfUnits
{
    public abstract class Generator
    {
        protected Number firstNumber;
        protected Number secondNumber;

        public abstract Exercise GenerateExercise();
        public abstract long GenerateAnswer();
    }
    public class GeneratorTranslate : Generator
    {
        public override Exercise GenerateExercise()
        {
            RandomNumber random = new RandomNumber();
            firstNumber = random.Generate();
            secondNumber = random.Generate();
            
            long answer = GenerateAnswer();

            List<Number> exerciseData = new List<Number>()
            {
                firstNumber,
            };

            return new Exercise(exerciseData, answer);
        }
        public override long GenerateAnswer()
        {
            if(secondNumber.NumberType == "bit")
            {
                return Translate.ToBit(firstNumber).Value;
            }
            else if (secondNumber.NumberType == "byte")
            {
                return Translate.ToByte(firstNumber).Value;
            }
            else if (secondNumber.NumberType == "kbyte")
            {
                return Translate.ToKbyte(firstNumber).Value;
            }
            else if (secondNumber.NumberType == "mbyte")
            {
                return Translate.ToMbyte(firstNumber).Value;
            }
            else
            {
                return Translate.ToGbyte(firstNumber).Value;
            }
        }
    }
    public class GeneratorComparison: Generator
    {
        public override Exercise GenerateExercise()
        {
            RandomNumber random = new RandomNumber();

            firstNumber = random.Generate();
            secondNumber = random.Generate();
            
            List<Number> exerciseData = new List<Number>() 
            { 
                firstNumber,
                secondNumber,
            };
            long answer = GenerateAnswer();
            return new Exercise(exerciseData, answer);
        }
        public override long GenerateAnswer()
        {
            if (Translate.ToBit(firstNumber) > Translate.ToBit(secondNumber))
            {
                return 1;
            }
            else if (Translate.ToBit(firstNumber) < Translate.ToBit(secondNumber))
            {
                return -1;
            }
            else return 0;
        }
    }
    public static class Translate
    {
        public static Number ToBit(Number number)
        {
            switch (number.NumberType)
            {
                case "bit":
                    return number;
                    
                case "byte":
                    return new Number("bit", number.Value * 8);
                    
                case "kbyte":
                    return new Number("bit", number.Value * 8000);
                    
                case "mbyte":
                    return new Number("bit", number.Value * 8000000);
                    
                case "gbyte":
                    return new Number("bit", number.Value * 8000000000);
                    
            }
            return number;
        }
        public static Number ToByte(Number number)
        {
            number = new Number("byte",ToBit(number).Value/8);
            return number;
        }
        public static Number ToKbyte(Number number)
        {
            number = new Number("kbyte",ToBit(number).Value/8000);
            return number;
        }
        public static Number ToMbyte(Number number)
        {
            number = new Number("mbyte", ToBit(number).Value / 8000000);
            return number;
        }
        public static Number ToGbyte(Number number)
        {
            number = new Number("gbyte", ToBit(number).Value / 8000000000);
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
            string informationType = RandomNumberType();
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
        public string RandomNumberType()
        {
            return InformationType[new Random().Next(0, 4)];
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
        public List<Number> ExerciseData { get; set; }
        public long Answer { get; set; }
        public Exercise(List<Number> _exerciseData, long _answer)
        {
            ExerciseData = _exerciseData;
            Answer = _answer;
        }
    }
    
}

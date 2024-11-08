namespace TranslationOfInfUnits
{
    public abstract class Generator
    {
        protected Number firstNumber;
        protected Number secondNumber;

        public abstract Exercise GenerateExercise();
        public abstract int GenerateAnswer();
    }
    //public class GeneratorTranslate: Generator
    //{
    //    public override Exercise GenerateExercise()
    //    {
    //        return null;
    //    }
    //}
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
            int answer = GenerateAnswer();
            return new Exercise(exerciseData, answer);
        }
        public override int GenerateAnswer()
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
                    return new Number("bit", number.Value / 8);
                    
                case "kbyte":
                    return new Number("bit", number.Value / 8000);
                    
                case "mbyte":
                    return new Number("bit", number.Value / 8000000);
                    
                case "gbyte":
                    return new Number("bit", number.Value / 8000000000);
                    
            }
            return number;
        }
    }
    public class RandomNumber
    {
        public List<string> InformationType =
        [
            "bit",
            "byte",
            "kbyte",
            "mbyte",
            "gbyte"
        ];
        public Number Generate()
        {
            Random random = new Random();
            Number number = new Number(InformationType[new Random().Next(0, 4)],random.Next(100, 1000));
            return number;
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
        public int Answer { get; set; }
        public Exercise(List<Number> _exerciseData, int _answer)
        {
            ExerciseData = _exerciseData;
            Answer = _answer;
        }
    }
    
}

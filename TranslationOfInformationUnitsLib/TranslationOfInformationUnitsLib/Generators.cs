namespace TranslationOfInfUnits
{
    public interface IGenerator
    {
        public (string, string) GenerateAllData();
    }
    public class GeneratorTranslate : IGenerator
    {
        public (string, string) GenerateAllData()
        {
            RandomNumber random = new RandomNumber();

            List<Number> exerciseData = new List<Number>()
            {
                random.GenerateNumber(new Number())
            };
            string type = random.GenerateType(exerciseData[0].Type);
            string answer = GenerateAnswer(exerciseData, type);
            string exerciseText = $"Переведите {exerciseData[0].Value} {exerciseData[0].Type} в {type}. " +
                                  $"" +
                                  $"В ответ напишите только целую часть.";
            return (exerciseText, answer);
        }
        public string GenerateAnswer(List<Number> exerciseData, string type)
        {
            RandomNumber random = new RandomNumber();
            return Translate.TranslateTo(exerciseData[0], type).Value.ToString();
        }
    }
    public class GeneratorComparison : IGenerator
    {
        public (string, string) GenerateAllData()
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
            return (exerciseText, answer);
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

}

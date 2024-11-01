namespace TranslationOfInfUnits
{
    public class GeneratorTranslate: IGenerator
    {
        public Exercise Generate()
        {
            return null;
        }
    }
    public class GeneratorComparison: IGenerator
    {
        public Exercise Generate()
        {
            return null;
        }
    }
    public class Exercise
    {
        protected List<int> exerciseData;
        protected int answer;
        public List<int> ExerciseData { get { return exerciseData; } }
        public int Answer { get { return answer; } }
        public Exercise(List<int> _exerciseData, int _answer)
        {
            exerciseData = _exerciseData;
            answer = _answer;
        }
    }
}

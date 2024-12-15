namespace TranslationOfInfUnits
{
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

}

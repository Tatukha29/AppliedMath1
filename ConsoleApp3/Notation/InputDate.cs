namespace ConsoleApp3.Notation
{
    public class InputDate
    {
        public InputDate(double leftLimit, double rightLimit, double epsilon)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            Epsilon = epsilon;
        }

        public double LeftLimit { get; }
        public double RightLimit { get; }
        public double Epsilon { get; }
    }
}
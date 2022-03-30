namespace ConsoleApp3.Notation
{
    public class IterationNotation
    {
        public IterationNotation(double leftLimit, double rightLimit, Point currentExtr)
        {
            LeftLimit = leftLimit;
            RightLimit = rightLimit;
            CurrentExtr = currentExtr;
        } 
        public double LeftLimit { get; }
        public double RightLimit { get; }
        public Point CurrentExtr { get; }
    }
}
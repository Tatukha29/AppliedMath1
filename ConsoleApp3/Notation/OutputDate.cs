using System.Collections.Generic;

namespace ConsoleApp3.Notation
{
    public class OutputDate
    {
        public OutputDate(Point point, int countIteration, long functionCalc, List<IterationNotation> iterationNotations)
        {
            Point = point;
            CountIteration = countIteration;
            FunctionCalc = functionCalc;
            IterationNotations = iterationNotations;
        }
        public Point Point { get; }
        public int CountIteration { get; }
        public long FunctionCalc { get; }
        public List<IterationNotation> IterationNotations { get; }
    }
}
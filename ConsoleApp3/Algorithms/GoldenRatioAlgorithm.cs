using System;
using System.Collections.Generic;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public class GoldenRatioAlgorithm : MinAlgorithm
    {
        private double GoldenRatio = (1 + Math.Sqrt(5)) / 2;

        public GoldenRatioAlgorithm(Function function)
            : base(function)
        {
        }

        public override OutputDate MakeAlgorithm(InputDate inputDate)
        {
            var iterations = new List<IterationNotation>();

            double a = inputDate.LeftLimit;
            double b = inputDate.RightLimit;
            double middle = (a + b) / 2;
            int iteration;
            for (iteration = 0; Math.Abs(b - a) > inputDate.Epsilon; iteration++)
            {
                double argument1 = b - (b - a) / GoldenRatio;
                double argument2 = a + (b - a) / GoldenRatio;
                if (_function.GetResult(argument1) >= _function.GetResult(argument2))
                {
                    a = argument1;
                }
                else
                {
                    b = argument2;
                }

                middle = (a + b) / 2;
                iterations.Add(new IterationNotation(a, b,
                new Point(middle, _function.GetResult(middle))));
            }

            return new OutputDate(new Point(middle, _function.GetResult(middle)), iteration, iteration * 2, iterations);
        }
    }
}
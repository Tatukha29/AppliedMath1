using System;
using System.Collections.Generic;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public class ParabolaAlgorithm : MinAlgorithm
    {
        private readonly Random _random;
        public ParabolaAlgorithm(Function function)
            : base(function)
        {
            _random = new Random();
        }
        
        private Random random = new Random();

        public double NotNan(double value) =>
            double.IsNaN(value) ? 0.0 : value;

        private double GetMinParabola(Point p1, Point p2, Point p3)
        {
            double u = p2.X - (Math.Pow(p2.X - p1.X, 2) * (p2.Y - p3.Y) - Math.Pow(p2.X - p3.X, 2) * (p2.Y - p1.Y)) /
                (2 * (p2.X - p1.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p2.Y - p1.Y));
            return u;
        }

        public override OutputDate MakeAlgorithm(InputDate inputDate)
        {
            var iterations = new List<IterationNotation>();
            
            double a = inputDate.LeftLimit;
            double b = inputDate.RightLimit;
            double middle = (a + b) / 2;
            Point p1 = new Point(a, _function.GetResult(a));
            Point p2 = new Point(middle, _function.GetResult(middle));
            Point p3 = new Point(b, _function.GetResult(b));

            int iteration;
            for (iteration = 0; Math.Abs(p3.X - p1.X) > inputDate.Epsilon; iteration++)
            {
                double parabolaMin = GetMinParabola(p1, p2, p3);
                var u = new Point(parabolaMin, _function.GetResult(parabolaMin));

                if (u.X < p2.X)
                {
                    if (u.Y < p2.Y)
                    {
                        p3 = p2;
                    }
                    else
                    {
                        p1 = u;
                    }
                }
                else
                {
                    if (u.Y < p2.Y)
                    {
                        p1 = p2;
                    }
                    else
                    {
                        p3 = u;
                    }
                }
                iterations.Add(new IterationNotation(p1.X, p3.X, p2));

                double randomDouble = _random.NextDouble() * (p1.X - p3.X) + p3.X;
                p2 = new Point(randomDouble, _function.GetResult(randomDouble));
            }

            return new OutputDate(p2, iteration, iteration * 4, iterations);
        }
    }
}
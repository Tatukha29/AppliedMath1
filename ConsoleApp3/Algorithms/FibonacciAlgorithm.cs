using System;
using System.Collections.Generic;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public class FibonacciAlgorithm : MinAlgorithm
    {
        public FibonacciAlgorithm(Function function)
            : base(function)
        {
        }

        public double FibonacciNumber(int index)
        {
            if (index == 0) return 0;
            if (index == 1) return 1;

            double granParent = 0;
            double parent = 1;
            double child = granParent + parent;

            for (int i = 2; i < index; i++)
            {
                child = granParent + parent;
                granParent = parent;
                parent = child;
            }

            return child;
        }

        public int FindFuction(InputDate inputDate)
        {
            int count = 0;
            double currentNumber = 0;
            double countEpsilon = (inputDate.RightLimit - inputDate.LeftLimit) / inputDate.Epsilon;

            while (currentNumber < countEpsilon)
            {
                currentNumber = FibonacciNumber(count);
                count++;
            }

            return count;
        }

        public override OutputDate MakeAlgorithm(InputDate inputDate)
        {
            var iterations = new List<IterationNotation>();

            int iterationCount = 1;
            int functionNumber = FindFuction(inputDate);

            double a = inputDate.LeftLimit;
            double b = inputDate.RightLimit;
            double middle = (a + b) / 2;

            double x1 = a + FibonacciNumber(functionNumber - 2) / FibonacciNumber(functionNumber) * (b - a);
            double x2 = a + FibonacciNumber(functionNumber - 1) / FibonacciNumber(functionNumber) * (b - a);

            double f1 = _function.GetResult(x1);
            double f2 = _function.GetResult(x2);

            while (Math.Abs(b - a) > inputDate.Epsilon)
            {
                iterationCount++;
                if (f1 >= f2)
                {
                    a = x1;
                    x1 = x2;
                    f1 = f2;
                    x2 = a + FibonacciNumber(functionNumber - iterationCount - 1) /
                        FibonacciNumber(functionNumber - iterationCount) * (b - a);
                    f2 = _function.GetResult(x2);
                }
                else
                {
                    b = x2;
                    x2 = x1;
                    f2 = f1;
                    x1 = a + FibonacciNumber(functionNumber - iterationCount - 2) /
                        FibonacciNumber(functionNumber - iterationCount) * (b - a);
                    f1 = _function.GetResult(x1);
                }

                middle = (a + b) / 2;
                iterations.Add(new IterationNotation(a, b,  new Point(middle, _function.GetResult(middle))));
            }
            return new OutputDate(new Point(middle, _function.GetResult(middle)), iterationCount, iterationCount * 2, iterations);
        }
    }
}
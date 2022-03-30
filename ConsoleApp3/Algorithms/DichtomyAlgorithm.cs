using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public class DichtomyAlgorithm : MinAlgorithm
    {
        public DichtomyAlgorithm(Function function)
            : base(function)
        {
        }
        
        public override OutputDate MakeAlgorithm(InputDate inputDate)
        {
            var iterations = new List<IterationNotation>();

            double a = inputDate.LeftLimit;
            double b = inputDate.RightLimit;
            double middle = (a + b) / 2;
            double indentation = inputDate.Epsilon / 2; // что такое почему эпсилон и тд  тп
            int iteration = 0;

            for (iteration = 0; Math.Abs(b - a) > inputDate.Epsilon; iteration++)
            {
                double firstArg = _function.GetResult(middle - inputDate.Epsilon);
                double secondArg = _function.GetResult(middle + inputDate.Epsilon);
                if (firstArg <= secondArg)
                {
                    b = middle - indentation;
                }
                else
                {
                    a = middle + indentation;
                }

                middle = (b + a) / 2;
                iterations.Add(new IterationNotation(a, b, new Point(middle, _function.GetResult(middle))));
            }
            return new OutputDate(new Point(middle, _function.GetResult(middle)), iteration, iteration * 2, iterations);
        }
    }
}
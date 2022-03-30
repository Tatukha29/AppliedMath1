using System;

namespace ConsoleApp3.Functions
{
    public class Function
    {
        public Function()
        {
        }

        public double GetResult(double x)
        {
            return Math.Sin(x) * Math.Pow(x, 3);
        }
    }
}
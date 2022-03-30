using System;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public abstract class MinAlgorithm
    {
        public Function _function;

        protected MinAlgorithm(Function function)
        {
            _function = function;
        }
        
        public abstract OutputDate MakeAlgorithm(InputDate inputDate);
    }
}
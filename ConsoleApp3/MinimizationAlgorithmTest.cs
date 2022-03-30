using System.Collections.Generic;
using AppliedMath.Lab1.Tests;
using ConsoleApp3.Excel;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;
using NUnit.Framework;

namespace ConsoleApp3
{
    [TestFixture]
    public class MinimizationAlgorithmTests
    {   
        private const double Epsilon = 1e-5;

        private ExcelOutput _excelOutput;
        
        private InputDate _inputDate;
        private Function _function;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _excelOutput = new ExcelOutput();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _excelOutput.SaveReport($@"D:\experiment\ConsoleApp3\ConsoleApp3\Report\report.xlsx");
        }
        
        [SetUp]
        public void SetUp()
        {
            _function = new Function();
            _inputDate = new InputDate(3, 8, Epsilon);
        }
        
        [TestCase(MinimizationAlgorithmType.Dichotomy)]
        [TestCase(MinimizationAlgorithmType.GoldenRatio)]
        [TestCase(MinimizationAlgorithmType.Fibonacci)]
        [TestCase(MinimizationAlgorithmType.Parabolic)]
        [TestCase(MinimizationAlgorithmType.Brent)]
        public void MinimizationTest(MinimizationAlgorithmType algorithmType)
        {
            var algorithm = algorithmType.GetAlgorithm(_function);
            var result = algorithm.MakeAlgorithm(_inputDate);
        }

        [TestCase(MinimizationAlgorithmType.Dichotomy)]
        [TestCase(MinimizationAlgorithmType.GoldenRatio)]
        [TestCase(MinimizationAlgorithmType.Fibonacci)]
        [TestCase(MinimizationAlgorithmType.Parabolic)]
        [TestCase(MinimizationAlgorithmType.Brent)]
        public void ReportCreator(MinimizationAlgorithmType algorithmType)
        {
            var algorithm = algorithmType.GetAlgorithm(_function);
            
            foreach (double delta in new List<double> {1e-1, 1e-3, 1e-5})
            {
                var request = new InputDate(4, 8, delta);
                var result = algorithm.MakeAlgorithm(request);
                
                _excelOutput.AddAlgorithm($"{algorithmType}_{delta}", request, result.IterationNotations);
            }
        }
        
        [TestCase(MinimizationAlgorithmType.Dichotomy)]
        [TestCase(MinimizationAlgorithmType.GoldenRatio)]
        [TestCase(MinimizationAlgorithmType.Fibonacci)]
        [TestCase(MinimizationAlgorithmType.Parabolic)]
        [TestCase(MinimizationAlgorithmType.Brent)]
        public void FunctionCalculationReportCreator(MinimizationAlgorithmType algorithmType)
        {
            var algorithm = algorithmType.GetAlgorithm(_function);
            var countReports = new List<(double delta, long count)>();
            
            for (double delta = 1e-1; delta > 1e-6; delta /= 2)
            {
                var request = new InputDate(4, 8, delta);
                var result = algorithm.MakeAlgorithm(request);
                countReports.Add((request.Epsilon, result.FunctionCalc));                
            }
            _excelOutput.AddFunctionCalculationReport($"{algorithmType}", countReports);
        }
        
    }
}
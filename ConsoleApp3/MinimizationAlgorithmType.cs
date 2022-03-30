using System;
using ConsoleApp3.Algorithms;
using ConsoleApp3.Functions;

namespace AppliedMath.Lab1.Tests
{
    public enum MinimizationAlgorithmType
    {
        Dichotomy,
        GoldenRatio,
        Fibonacci,
        Parabolic,
        Brent
    }

    public static class MinimizationAlgorithmTypeExtension
    {
        public static MinAlgorithm GetAlgorithm(this MinimizationAlgorithmType algorithmType,
            Function function) =>
            algorithmType switch
            {
                MinimizationAlgorithmType.Dichotomy => new DichtomyAlgorithm(function),
                MinimizationAlgorithmType.GoldenRatio => new GoldenRatioAlgorithm(function),
                MinimizationAlgorithmType.Fibonacci => new FibonacciAlgorithm(function),
                MinimizationAlgorithmType.Parabolic => new ParabolaAlgorithm(function),
                MinimizationAlgorithmType.Brent => new BrentAlgorithm(function),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithmType), algorithmType, null)
            };

    }
}
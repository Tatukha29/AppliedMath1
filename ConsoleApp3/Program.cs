// using System;
// using ConsoleApp3.Algorithms;
// using ConsoleApp3.Functions;
// using ConsoleApp3.Notation;
//
// namespace ConsoleApp3
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             double a = 4;
//             double b = 6;
//             var inp = new InputDate(a, b, 0.1);
//             var Func = new Function();
//             
//             var fgh = new DichtomyAlgorithm(Func);
//             var test = fgh.MakeAlgorithm(inp);
//
//             var gldrt = new GoldenRatioAlgorithm(Func);
//             var test2 = gldrt.MakeAlgorithm(inp);
//
//             var vbrje = new FibonacciAlgorithm(Func);
//             var test3 = vbrje.MakeAlgorithm(inp);
//
//             var buwef = new ParabolaAlgorithm(Func);
//             var test4 = buwef.MakeAlgorithm(inp);
//
//             var mfwf = new BrentAlgorithm(Func);
//             var test5 = mfwf.MakeAlgorithm(inp);
//
//             Console.WriteLine(test.CountIteration);
//             Console.WriteLine(test.Point.X);
//             Console.WriteLine(test.Point.Y);
//             Console.WriteLine("--------------");
//             Console.WriteLine(test2.CountIteration);
//             Console.WriteLine(test2.Point.X);
//             Console.WriteLine(test2.Point.Y);
//             Console.WriteLine("--------------");
//             Console.WriteLine(test3.CountIteration);
//             Console.WriteLine(test3.Point.X);
//             Console.WriteLine(test3.Point.Y);
//             Console.WriteLine("--------------");
//             Console.WriteLine(test4.CountIteration);
//             Console.WriteLine(test4.Point.X);
//             Console.WriteLine(test4.Point.Y);
//             Console.WriteLine("--------------");
//             Console.WriteLine(test5.CountIteration);
//             Console.WriteLine(test5.Point.X);
//             Console.WriteLine(test5.Point.Y);
//         }
//     }
// }
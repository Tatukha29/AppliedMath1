using System;
using System.Collections.Generic;
using ConsoleApp3.Functions;
using ConsoleApp3.Notation;

namespace ConsoleApp3.Algorithms
{
    public class BrentAlgorithm : MinAlgorithm
    {
        private double K = (3 - Math.Sqrt(5)) / 2;
        private double microEpsilon = 1e-12;
        
        public BrentAlgorithm(Function function)
            : base(function)
        {
        }
        
        private double GetMinParabola(Point p1, Point p2, Point p3)
        {
            double u = p2.X - (Math.Pow(p2.X - p1.X, 2) * (p2.Y - p3.Y) - Math.Pow(p2.X - p3.X, 2) * (p2.Y - p1.Y)) /
                (2 * (p2.X - p1.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p2.Y - p1.Y));
            return u;
        }

        public bool EpsEqual(Point a, Point b, Point c)
        {
            bool b1 = Math.Abs(a.X - b.X) < microEpsilon;
            bool b2 = Math.Abs(b.X - c.X) < microEpsilon;

            return b1 && b2;
        }
        
        public bool EpsEqual(Point a, Point b)
        {
            bool b1 = Math.Abs(a.X - b.X) < microEpsilon;

            return b1;
        }

        public override OutputDate MakeAlgorithm(InputDate inputDate)
        {
            var iterations = new List<IterationNotation>();
            long count = 0;

            var left = inputDate.LeftLimit;
            var right = inputDate.RightLimit;
            
            var a = new Point(left, _function.GetResult(left));
            var c = new Point(right, _function.GetResult(right));

            var x = new Point(a.X + K * (c.X - a.X), _function.GetResult(a.X + K * (c.X - a.X)));
            var w = x;
            var v = x;

            double d = c.X - a.X;
            double e = d;

            int iteration;
            for (iteration = 0; Math.Abs(c.X - a.X) > inputDate.Epsilon; iteration++)
            {
                double g = e;
                e = d;
                double tol = inputDate.Epsilon * Math.Abs(x.X) + inputDate.Epsilon / 10;

                if (Math.Abs(x.X - (a.X + c.X) / 2) + (c.X - a.X) / 2 <= 2 * tol)
                    break;

                bool parabolic = false;
                Point u = null;

                if (!EpsEqual(x, w, v))
                {
                    double parabolaMin = GetMinParabola(x, w, v);
                    count += 3;

                    u = new Point(parabolaMin, _function.GetResult(parabolaMin));

                    if (u.X >= a.X && u.X <= c.X && Math.Abs(u.X - x.X) < g / 2)
                    {
                        parabolic = true;
                        if (u.X - a.X < 2 * tol || c.X - u.X < 2 * tol)
                        {
                            double uX = x.X - Math.Sign(x.X - (a.X + c.X) / 2) * tol;
                            u = new Point(uX, _function.GetResult(uX));
                        }
                    }
                }

                if (!parabolic)
                {
                    if (x.X < (a.X + c.X) / 2)
                    {
                        double goldenRatio = x.X + K * (c.X - x.X);
                        u = new Point(goldenRatio, _function.GetResult(goldenRatio));
                        e = c.X - x.X;
                    }
                    else
                    {
                        double goldenRatio = x.X - K * (x.X - a.X);
                        u = new Point(goldenRatio, _function.GetResult(goldenRatio));
                        e = x.X - a.X;
                    }
                }

                if (Math.Abs(u.X - x.X) < tol)
                {
                    double minApprox = x.X + Math.Sign(u.X - x.X) * inputDate.Epsilon;
                    u = new Point(minApprox, _function.GetResult(minApprox));
                }

                d = Math.Abs(u.X - x.X);

                count += parabolic ? 1u : 2;

                if (u.Y <= x.Y)
                {
                    if (u.X >= x.X)
                    {
                        a = x;
                    }
                    else
                    {
                        c = x;
                    }

                    v = w;
                    w = x;
                    x = u;
                }
                else
                {
                    if (u.X >= x.X)
                    {
                        c = u;
                    }
                    else
                    {
                        a = u;
                    }

                    count += parabolic ? 0u : 1;
                    if (u.Y <= w.Y || EpsEqual(w, x))
                    {
                        v = w;
                        w = u;
                    }
                    else
                    {
                        count += parabolic ? 0u : 1;
                        if (u.Y <= v.Y || EpsEqual(v, x) || EpsEqual(v, w))
                        {
                            v = u;
                        }
                    }
                }
                iterations.Add(new IterationNotation(a.X, c.X, x));
            }

            return new OutputDate(x, iteration, count, iterations);
        }
    }
}
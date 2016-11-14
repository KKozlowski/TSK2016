using System;

class Numeric
{
    Func<double, double> func;

    double fa, f0, eps = 0.000000000000001d;

    public void InitNewFunction(Func<double, double, double> function, double val, bool first)
    {
        if (first)  func = (x => function(val, x));
        else        func = (x => function(x, val));
    }

    public double FindZero(double a, double b, int recurences = 100)
    {
        fa = func(a);
        f0 = a - fa * (a - b) / (fa - func(b));
        if (double.IsNaN(f0))
            throw new InvalidOperationException("Brak miejsca zerowego");
        if (--recurences == 0)
            return f0;
        return (Math.Abs(func(f0)) < eps) ? f0 : FindZero(f0, a, recurences);
    }
}
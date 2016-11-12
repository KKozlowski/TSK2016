using System;

class Numeric
{
    Func<double, double> func;

    public void InitNewFunction(Func<double, double, double> function, double val, bool first)
    {
        if (first)  func = (x => function(val, x));
        else        func = (x => function(x, val));
    }

    public double FindZero(double start, double end)
    {
        return 0;
    }
}
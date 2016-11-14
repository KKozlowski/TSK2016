using System.Collections.Generic;

// this structure stores results of all calculations ready to be drawn

// dt - time step
// t0 - helper variable
// x - bullet transition
// v - bullet velocity
// a - bullet acceleration
// F - pressure force
// P - barrel presure
// n - moles of gas

public class Results
{
    public double dt, t0;
    public List<double> t = new List<double>();
    public List<double> x = new List<double>();
    public List<double> v = new List<double>();
    public List<double> a = new List<double>();
    public List<double> F = new List<double>();
    public List<double> P = new List<double>();
    public List<double> n = new List<double>();
}
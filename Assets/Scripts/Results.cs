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

struct Results
{
    public double dt, t0;
    public List<double> t, x, v, a, F, P, n;
}
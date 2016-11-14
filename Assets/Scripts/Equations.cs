class Equations
{
    double x0, x1, t0, t1, v1, C1, C2, C3, m;

    public void Init(double x0, double x1, double t0, double t1, double C1, double C2, double C3, double m)
    {
        this.x0 = x0;
        this.x1 = x1;
        this.t0 = t0;
        this.t1 = t1;
        this.C1 = C1;
        this.C2 = C2;
        this.C3 = C3;
        this.m = m;
        v1 = P1v(t1, x1);
    }

    // used to calculate x(t) and x1 in first phase
    public double P1x(double t, double x)
    {
        return C1*(t*t-t0*t0)*(t-t0)/x - C2*(t-t0)*(t-t0) + x0 - x;
    }

    // used to calculate v(t) and v1 in first phase
    public double P1v(double t, double x)
    {
        return C1*(t*t - t0*t0)/x - C2*(t-t0);
    }

    // used to calculate F(t) in first phase
    public double P1F(double t, double x)
    {
        return m*(2*C1*t/x - C2);
    }

    // used to calculate a(t) in first phase
    public double P1a(double t, double x)
    {
        return 2*C1*t/x - C2;
    }

    // used to calculate x(t) and t2 in second phase
    public double P2x(double t, double x)
    {
        return  (t-t1)*(t-t1)*(C3/x - C2) + x1 - x + v1*(t-t1);
    }

    // used to calculate v(t) in second phase
    public double P2v(double t, double x)
    {
        return (t-t1)*(C3/x - C2) - (t-t1)*C2 + v1;
    }

    // used to calculate F(t) in second phase
    public double P2F(double t, double x)
    {
        return m*(C3/x - C2);
    }

    // used to calculate a(t) in second phase
    public double P2a(double t, double x)
    {
        return C3/x - C2;
    }
}
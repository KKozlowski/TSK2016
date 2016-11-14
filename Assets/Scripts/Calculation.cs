using System;
using UnityEngine;

class Calculation
{
    Equations equations;
    Numeric numeric;
    Results results;

    const double R = 8.3144598d; // J / (K * mol)
    const double P2 = 101325d; //pa 

    // known variables
    double T, m, n1, Vsp, Sn;

    // helper constants
    double C1, C2, C3, x0, x1, x2, t0, t1, t2, dt;
    int firstPhaseSteps, secondPhaseSteps, totalSteps;

    // helper variables
    double t, x, v, F, a, P, n;

    public void Init(CartridgeInfo cartridge, LockInfo locki, PowderInfo powder, int timeSteps)
    {
        equations = new Equations();
        numeric = new Numeric();
        results = new Results();

        totalSteps = timeSteps;
        T = powder.temperatureOfBuring;
        m = cartridge.massOfBullet;
        n1 = powder.molesPerKilo * powder.mass;
        Vsp = n1 / powder.timeOfBurning;
        Sn = cartridge.diameterOfBullet * cartridge.diameterOfBullet * Math.PI;
        
        x0 = cartridge.lengthOfCasing;
        x2 = locki.lengthOfBarrel;

        t0 = (P2 * x0 * Sn) / (Vsp * R * T);
        t1 = powder.timeOfBurning;

        // calculate C1 = RTVsp/2m
        C1 = (R * T * Vsp) / (2 * m);

        // calculate C2 = P2Sn/m
        C2 = (P2 * Sn) / m;

        // calculate C3 = nRT/m
        C3 = (n1 * R * T) / m;
        
        equations.Init(x0, x1, t0, t1, C1, C2, C3, m);

        // get x1
        numeric.InitNewFunction(equations.P1x, t1, true);
        x1 = numeric.FindZero(x0, x2 + 1.0f);

        equations.Init(x0, x1, t0, t1, C1, C2, C3, m);

        // get t2
        numeric.InitNewFunction(equations.P2x, x2, false);
        t2 = numeric.FindZero(t1, 1.0d);

        equations.Init(x0, x1, t0, t1, C1, C2, C3, m);

        firstPhaseSteps = (int)((t1 - t0) / (t2 - t0) * totalSteps);
        secondPhaseSteps = totalSteps - firstPhaseSteps;
        dt = (t2 - t0) / totalSteps;
    }

    public void Calculate()
    {
        // get results for first phase
        for (int i = 0; i < firstPhaseSteps; ++i)
        {
            t = t0 + i * dt;
            numeric.InitNewFunction(equations.P1x, t, true);
            
            x = numeric.FindZero(0.001d, 100d);
            v = equations.P1v(t, x);
            F = equations.P1F(t, x);
            a = equations.P1a(t, x);
            n = Vsp * t;
            P = (n * R * T) / (x * Sn);

            AddResults();
        }

        // get results for second phase
        for (int i = 0; i <= secondPhaseSteps; ++i)
        {
            t = t0 + (firstPhaseSteps + i) * dt;
            numeric.InitNewFunction(equations.P2x, t, true);

            x = numeric.FindZero(0.001d, 100d);
            v = equations.P2v(t, x);
            F = equations.P2F(t, x);
            a = equations.P2a(t, x);
            n = n1;
            P = (n * R * T) / (x * Sn);

            AddResults();
        }
    }

    public Results GetResults()
    {
        return results;
    }

    void AddResults()
    {
        results.t.Add(t);
        results.x.Add(x);
        results.v.Add(v);
        results.F.Add(F);
        results.a.Add(a);
        results.P.Add(P);
        results.n.Add(n);
    }
}

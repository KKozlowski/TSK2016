using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Text field;

    float progress;
    float interpolation;
    double t, x, v, a, P, F;
    int A, B;

    void Update ()
    {
        Results r = Simulation.Me.Presentation.Results;
        progress = Simulation.Me.Presentation.bulletProgress;

        interpolation = progress * r.x.Count;
        A = (int)interpolation;
        B = A + 1;

        if (B < r.x.Count) // inteprolate
        {
            interpolation %= 1;
            x = Lerp(r.x[A], r.x[B], interpolation);
            a = Lerp(r.a[A], r.a[B], interpolation);
            P = Lerp(r.P[A], r.P[B], interpolation);
            v = Lerp(r.v[A], r.v[B], interpolation);
            F = Lerp(r.F[A], r.F[B], interpolation);
            t = Lerp(r.t[A], r.t[B], interpolation);
        }
        else // extrapolate
        {
            double diff = r.x[r.x.Count - 1] - r.x[r.x.Count - 2];
            interpolation = (progress - 1.0f) * (r.x.Count);
            interpolation += 1;

            x = r.x[r.x.Count - 1] + interpolation * diff;
            diff = r.t[r.t.Count - 1] - r.t[r.t.Count - 2];
            t = r.t[r.t.Count - 1] + interpolation * diff;
            a = 0;
            P = 0;
            v = r.v[r.x.Count - 1];
            F = 0;
        }        

        field.text =
	        "<b>t:</b>   " + (t * 1000).ToString("F4") + " ms"
	        + "\n<b>x:</b>   " + x.ToString("F4") + " m"
            + "\n<b>v:</b>   " + v.ToString("F4") + " m/s"
            + "\n<b>a:</b>   " + a.ToString("F4") + " m/s²"
            + "\n<b>P:</b>   " + (P * 0.00001d).ToString("F4") + " bar"
            + "\n<b>F:</b>   " + (F * 0.001d).ToString("F4") + " kN";
    }

    double Lerp(double first, double second, double progress)
    {
        return first + (second - first)*progress;
    }
}

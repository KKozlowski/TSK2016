using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Text field;

    float progress;
    float interpolation;
    double t, x, v, a, P;
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
        }
        else // extrapolate
        {
            double diff = r.x[r.x.Count - 2] - r.x[r.x.Count - 1];
            interpolation = (progress - 1.0f) * (r.x.Count);
            interpolation += 1;

            x = r.x[r.x.Count - 1] + interpolation * diff;
            a = 0;
            P = 0;
            v = r.v[r.x.Count - 1];
        }

        A = (int)Mathf.Clamp(interpolation, 0, r.x.Count-2);
        B = A + 1;

        t = Lerp(r.t[A], r.t[B], interpolation);
        

        field.text =
	        "<b>t:</b>   " + t.ToString("F8") + " s"
	        + "\n<b>x:</b>   " + x.ToString("F8") + " m"
            + "\n<b>v:</b>   " + v.ToString("F8") + " m/s"
            + "\n<b>a:</b>   " + a.ToString("F4") + " m/s²"
            + "\n<b>P:</b>   " + P.ToString("F4") + " W";
    }

    double Lerp(double first, double second, double progress)
    {
        return first + (second - first)*progress;
    }
}

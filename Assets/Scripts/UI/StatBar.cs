using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatBar : MonoBehaviour
{
    [SerializeField] private Text field;

	void Update ()
	{
        int one = (int)Simulation.Me.Presentation.Interpolation;
        int two = one + 1;
        double interpolation = Simulation.Me.Presentation.Interpolation % 1;

	    Results r = Simulation.Me.Presentation.Results;
	    if (two == r.x.Count)
	        two = one;
	    

        double t = Lerp(r.t[one], r.t[two], interpolation);
        double x = Lerp(r.x[one], r.x[two], interpolation);
        double a = Lerp(r.a[one], r.a[two], interpolation);
        double P = Lerp(r.P[one], r.P[two], interpolation);


        field.text =
	        "<b>t:</b>   " + t.ToString("F8") + " s"
	        + "\n<b>x:</b>   " + x.ToString("F8") + " m"
	        + "\n<b>a:</b>   " + a.ToString("F4") + " m/s²"
            + "\n<b>P:</b>   " + P.ToString("F4") + " W";
    }

    double Lerp(double first, double second, double progress)
    {
        return first + (second - first)*progress;
    }
}

using UnityEngine;
using System.Collections;

public class Presentation : MonoBehaviour
{
    Results results;
    [SerializeField] Bullet bullet;

    bool wasInit;
    public bool animate;
    float animTime;

    // helpers
    public float progress;
    float interpolation;
    int samples, x, y;

	void Update ()
    {
        if (!wasInit)
            return;

	    animate = Ui.Me.progressBar.GetAutoAnimation();
	    if (animate)
	    {
	        progress = (progress + Time.deltaTime/animTime)%1.0f;
	        Ui.Me.progressBar.SetProgress(progress);
	    }
	    else
	    {
	        progress = Ui.Me.progressBar.GetProgress();
	    }

	    Pistol.Me.Progress = Mathf.Clamp((progress - 0.2f)/0.4f,0,2);

        interpolation = progress * samples;
        x = (int)interpolation;
        y = x + 1;
        interpolation %= 1.0f;

        if (y == samples) return;
        double[] ds = new double[100];
        for (int i = 1; i < 100; ++i)
            ds[i - 1] = results.x[i] - results.x[i - 1];
        bullet.SetPosition(Mathf.Lerp((float)results.x[x], (float)results.x[y], interpolation));
	}

    public void Init(Results results, float animTime = 10)
    {
        this.results = results;
        this.animTime = animTime;
        progress = 0;
        samples = results.t.Count;
        wasInit = true;
    }

    public void SetAnimating(bool active) { animate = active; }
    public void SetProgress(float value) { progress = value; }
}

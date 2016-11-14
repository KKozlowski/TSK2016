using UnityEngine;
using System.Collections;

public class Presentation : MonoBehaviour
{
    public Results Results { get; private set; }
    [SerializeField] Bullet bullet;

    bool wasInit;
    public bool animate;
    float animTime;

    // helpers
    public float progress;
    public float Interpolation { get; private set; }
    int samples, x, y;

	void Update ()
    {
        if (!wasInit)
            return;
        if (Results.x.Count < 2)
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

        Interpolation = progress * samples;
        x = (int)Interpolation;
        y = x + 1;
        float interpolation = Interpolation % 1.0f;

        if (y == samples) return;
        double[] ds = new double[100];
        for (int i = 1; i < 100; ++i)
            ds[i - 1] = Results.x[i] - Results.x[i - 1];
        bullet.SetPosition(Mathf.Lerp((float)Results.x[x], (float)Results.x[y], interpolation));
	}

    public void Init(Results results, float animTime = 10)
    {
        this.Results = results;
        this.animTime = animTime;
        progress = 0;
        samples = results.t.Count;
        wasInit = true;
    }

    public void SetAnimating(bool active) { animate = active; }
    public void SetProgress(float value) { progress = value; }
}

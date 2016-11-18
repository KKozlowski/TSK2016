using UnityEngine;
using System.Collections;

public class Presentation : MonoBehaviour
{
    public Results Results { get; private set; }
    [SerializeField] Bullet bullet;

    bool wasInit;
    public bool animate;
    float animTime;
    float strikerPart = 0.1f;
    float bulletPart = 0.5f;
    float sliderPart = 0.9f;

    public float strikerProgress;
    public float bulletProgress;
    public float sliderProgress;

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

        strikerProgress = Mathf.Lerp(0, 1, progress / (strikerPart));
        bulletProgress = Mathf.LerpUnclamped(0, 1, (progress - strikerPart) / bulletPart);
        sliderProgress = Mathf.Lerp(0, 1, (progress - strikerPart) / sliderPart);

        if (bulletProgress < 0.0f)
            bulletProgress = 0.0f;

        if (strikerProgress == 1 && progress >= 0.55f)
        {
            strikerProgress = 4 * (sliderProgress - sliderProgress * sliderProgress);
        }

        Pistol.Me.Striker.SetOutProgress(strikerProgress);
        Pistol.Me.Progress = 4*(sliderProgress- sliderProgress * sliderProgress);

        if (bulletProgress <= 1.0f)
        {
            Interpolation = bulletProgress * samples;
            x = (int)Interpolation;
            y = x + 1;
            Interpolation = Interpolation % 1.0f;
            if (y == samples) y = x;
            bullet.SetPosition(Mathf.Lerp((float)Results.x[x], (float)Results.x[y], Interpolation));
        }
        else
        {
            x = Results.x.Count - 2;
            y = Results.x.Count - 1;
            double diff = Results.x[y] - Results.x[x];
            Interpolation = (bulletProgress - 1.0f) * samples;
            bullet.SetPosition(Results.x[Results.x.Count - 1] + diff * Interpolation);
        }
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

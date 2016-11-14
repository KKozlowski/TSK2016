using UnityEngine.UI;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle autoAnimToggle;
    [SerializeField] private Text lastTimeText;

    public void SetProgress(float p)
    {
        slider.value = Mathf.Clamp(p, 0, 1);
    }

    public float GetUnboundProgress()
    {
        return slider.value;
    }

    public float GetProgress() {
        return Mathf.Clamp(slider.value, 0, 0.9999f);
    }

    public bool GetAutoAnimation()
    {
        return autoAnimToggle.isOn;
    }

    void Update()
    {
        lastTimeText.text = Simulation.Me.Presentation.Results.t.Last().ToString("F8");
    }
}

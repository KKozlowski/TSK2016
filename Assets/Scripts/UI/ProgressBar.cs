using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Toggle autoAnimToggle;

    public void SetProgress(float p)
    {
        slider.value = Mathf.Clamp(p, 0, 1);
    }

    public float GetProgress() {
        return Mathf.Clamp(slider.value, 0, 0.9999f);
    }

    public bool GetAutoAnimation()
    {
        return autoAnimToggle.isOn;
    }
}

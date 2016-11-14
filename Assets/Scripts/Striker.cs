using UnityEngine;
using System.Collections;

public class Striker : MonoBehaviour {
    public float xStart;
    public float xFinal;

    public float triggetYStart;
    public float triggerYFinal;

    [SerializeField]
    private Transform trigger;
    
    public void SetInProgress(float progress) {
        Debug.Log(progress);
        Vector3 localPos = transform.localPosition;
        SetTriggerProgress(progress * 10f);
        progress = Mathf.Clamp01(progress*1.1f - 0.1f);
        localPos.x = Mathf.Lerp(xStart, xFinal, progress);
        transform.localPosition = localPos;
    }

    public void SetOutProgress(float progress) {
        Vector3 localPos = transform.localPosition;
        progress = Mathf.Clamp01(progress);
        localPos.x = Mathf.Lerp(xFinal, xStart, progress);
        transform.localPosition = localPos;
        SetTriggerProgress(1);
    }

    void SetTriggerProgress(float progress) {
        Vector3 localPos = trigger.localPosition;
        progress = Mathf.Clamp01(progress);
        localPos.y = Mathf.Lerp(triggetYStart, triggerYFinal, progress);
        trigger.localPosition = localPos;
    }
}

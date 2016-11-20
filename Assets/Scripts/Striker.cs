using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class Striker : MonoBehaviour {
    public float xStart;
    public float xFinal;

    public float triggerYStart;
    public float triggerYFinal;

    [SerializeField]
    private Transform trigger;
    
    public void SetOutProgress(float progress)
    {
        Vector3 localPos = transform.localPosition;
        localPos.x = Mathf.Lerp(xStart, xFinal, progress);
        transform.localPosition = localPos;

        float triggerProgress = Mathf.Clamp(progress*7, 0, 1);
        Vector3 triggPos = trigger.position;
        triggPos.y = Mathf.Lerp(triggerYStart, triggerYFinal, triggerProgress);
        trigger.position = triggPos;
    }
}

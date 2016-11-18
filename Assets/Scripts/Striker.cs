using UnityEngine;
using System.Collections;

public class Striker : MonoBehaviour {
    public float xStart;
    public float xFinal;

    public float triggetYStart;
    public float triggerYFinal;

    [SerializeField]
    private Transform trigger;
    
    public void SetOutProgress(float progress)
    {
        Vector3 localPos = transform.localPosition;
        localPos.x = Mathf.Lerp(xStart, xFinal, progress);
        transform.localPosition = localPos;
    }
}

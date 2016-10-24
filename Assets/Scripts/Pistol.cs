using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {

    public static Pistol Me { get; private set; }

	public float BarrelLength { get; private set; }
    public float LockInclination { get; private set; }

    public Transform barrelMainTransform;
    public Transform barrelInnerTransform;

    public Transform slideTransform;

    public Vector3[] slidePositions;

    public Quaternion[] barrelRotations;
    public Vector3[] barrelPositions;

    public float Progress = 0;

    public const float Scale = 50;

    public bool PingPong = true;

    public void SetBarrelLength(double l)
    {
        SetBarrelLength((float)l);
    }

    public void SetBarrelLength(float l)
    {
        BarrelLength = l;
        l *= Scale;
        barrelInnerTransform.localScale = new Vector3(l, barrelInnerTransform.localScale.y, barrelInnerTransform.localScale.z);
    }

    public void SetInclination(double i)
    {
        SetInclination((float)i);
    }

    public void SetInclination(float i)
    {
        LockInclination = i;
        barrelRotations[1] = barrelRotations[0]*Quaternion.Euler(0, 0, -i*37.5f);

        i *= Scale;
        slidePositions[1] = slidePositions[0] + new Vector3(i, 0, 0);

        barrelPositions[1] = barrelPositions[0] + new Vector3(0, -i / 14f, 0);
    }

    void Awake()
    {
        Me = this;
    }

    void Start()
    {
        slidePositions = new Vector3[2];
        slidePositions[0] = slideTransform.localPosition;
        slidePositions[1] = slidePositions[0];

        barrelRotations = new Quaternion[2];
        barrelRotations[0] = barrelMainTransform.localRotation;
        barrelRotations[1] = barrelRotations[0];

        barrelPositions = new Vector3[2];
        barrelPositions[0] = barrelMainTransform.localPosition;
        barrelPositions[1] = barrelPositions[0];

        SetBarrelLength(0.115);
        SetInclination(0.05);
        
    }

    void Update()
    {
        if (PingPong)
        {
            Progress += Time.deltaTime * 1.5f;
        }

        float pong = Mathf.PingPong(Progress, 1);

        slideTransform.localPosition = Vector3.Lerp(slidePositions[0], slidePositions[1], pong);
        barrelMainTransform.localPosition = Vector3.Lerp(barrelPositions[0], barrelPositions[1], pong);
        barrelMainTransform.localRotation = Quaternion.Lerp(barrelRotations[0], barrelRotations[1], pong);
    }
}

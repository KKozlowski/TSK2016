using UnityEngine;
using System.Collections;

public class Pistol : MonoBehaviour {

    public static Pistol Me { get; private set; }

	public float BarrelLength { get; private set; }
    public float BarrelDiameter { get; private set; }
    public float LockInclination { get; private set; }

    public Transform barrelMainTransform;
    public Transform barrelInnerTransform;

    public Transform slideTransform;

    public Vector3[] slidePositions;

    public Quaternion[] barrelRotations;
    public Vector3[] barrelPositions;

    public Transform barrelTop, barrelBottom, barrelBack, hinge;

    public Transform strikerMainTransform, strikerZeroPosition;

    public Transform slideBack, slideBackBack, slideZeroPosition, slideTopOverBarrel, slideTopOther;

    [SerializeField]
    private Cartridge _cartridge;
    public Cartridge Cartridge { get { return _cartridge; } }

    [SerializeField] private Striker _striker;
    public Striker Striker { get { return _striker; } }

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
        slideTopOverBarrel.localScale = new Vector3(l - 1.58f, slideTopOverBarrel.localScale.y, slideTopOverBarrel.localScale.z);
        slideBackBack.localScale = new Vector3(l + 4.16f, slideBackBack.localScale.y, slideBackBack.localScale.z);
    }

    public void SetBarrelDiameter(double d)
    {
        SetBarrelDiameter((float)d);
    }

    public void SetBarrelDiameter(float diameter)
    {
        BarrelDiameter = diameter;
        diameter *= Scale;
        var hingePrevParent = hinge.parent;
        hinge.parent = barrelTop;
        barrelTop.localPosition = barrelBottom.localPosition + new Vector3(0,diameter,0);
        hinge.parent = hingePrevParent;
        

        barrelBack.localScale = new Vector3(1, diameter+0.02f, 1);
        barrelBack.localPosition = barrelBottom.localPosition + new Vector3(0, diameter/2, 0);

        strikerMainTransform.position = strikerZeroPosition.position + new Vector3(0, diameter / 2, 0);

        Cartridge.transform.localPosition = barrelBottom.localPosition +new Vector3(0, diameter / 2, 0);

        float slideBackHeight = diameter + 0.67f;
        Vector3 slideBackScale = slideBack.localScale;
        slideBackScale.y = slideBackHeight;
        slideBack.localScale = slideBackScale;

        Vector3[] slidesPositions = {slideTopOverBarrel.localPosition, slideTopOther.localPosition};
        slidesPositions[1].y = slidesPositions[0].y = slideZeroPosition.localPosition.y + slideBackHeight- 0.25f;
        slideTopOther.localPosition = slidesPositions[1];
        slideTopOverBarrel.localPosition = slidesPositions[0];
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
        slidePositions = new Vector3[2];
        slidePositions[0] = slideTransform.localPosition;
        slidePositions[1] = slidePositions[0];

        barrelRotations = new Quaternion[2];
        barrelRotations[0] = barrelMainTransform.localRotation;
        barrelRotations[1] = barrelRotations[0];

        barrelPositions = new Vector3[2];
        barrelPositions[0] = barrelMainTransform.localPosition;
        barrelPositions[1] = barrelPositions[0];
    }

    void Start()
    {
        

        

        //SetBarrelLength(0.115);
        //SetInclination(0.05);
        
    }

    public void UpdateElements()
    {
        float pong = Mathf.PingPong(Progress, 1);
        slideTransform.localPosition = Vector3.Lerp(slidePositions[0], slidePositions[1], pong);
        barrelMainTransform.localPosition = Vector3.Lerp(barrelPositions[0], barrelPositions[1], pong);
        barrelMainTransform.localRotation = Quaternion.Lerp(barrelRotations[0], barrelRotations[1], pong);
    }

    void Update()
    {
        if (PingPong)
        {
            Progress += Time.deltaTime * 1.5f;
        }

        UpdateElements();
    }
}

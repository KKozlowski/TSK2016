using UnityEngine;
using System.Collections;

public class Cartridge : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    public Bullet Bullet { get { return _bullet; } }

    public Transform casing;

    public void SetLength(double l) { SetLength((float)l);}

    public void SetLength(float l)
    {
        l *= Pistol.Scale;
        Vector3 casingScale = casing.localScale;
        casingScale.x = l;
        casing.localScale = casingScale;

        Bullet.transform.localPosition = new Vector3(-l, 0,0);
    }

    public void SetDiameter(double d) { SetDiameter((float)d);}
    public void SetDiameter(float d)
    {
        d *= Pistol.Scale;
        Vector3 bulletScale = Bullet.Representation.transform.localScale;
        Vector3 casingScale = casing.localScale;
        casingScale.y = d;
        casingScale.z = d;

        bulletScale.y = d*0.95f;
        bulletScale.z = d*0.95f;
        Bullet.Representation.transform.localScale = bulletScale;
        casing.localScale = casingScale;


    }
}

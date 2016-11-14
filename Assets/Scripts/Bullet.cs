using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Transform Representation { get { return _representation; } }
    [SerializeField] private Transform _representation;
    public float ZeroPosition;

    public void SetPosition(double x)
    {
        transform.localPosition = new Vector3((float)x * -50, 0, 0);
    }
}

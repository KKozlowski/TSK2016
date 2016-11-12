using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Transform Representation { get { return _representation; } }
    [SerializeField] private Transform _representation;
    public float ZeroPosition;
}

using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public Transform Representation { get { return _representation; } }
    [SerializeField] private Transform _representation;
    public float ZeroPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

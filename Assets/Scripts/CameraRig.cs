using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour
{
    private Vector2 mousePositionStart;
    private Vector3 startEuler;

	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1))
	    {
	        mousePositionStart = Input.mousePosition;
	        startEuler = transform.rotation.eulerAngles;
	    } else if (Input.GetMouseButton(1))
	    {
	        Vector2 mousePositionNow = Input.mousePosition;
	        Vector3 newEuler = startEuler + 0.5f*new Vector3(-mousePositionNow.y + mousePositionStart.y, mousePositionNow.x - mousePositionStart.x, 0);
	        transform.rotation = Quaternion.Euler(newEuler);
	    }
	}
}

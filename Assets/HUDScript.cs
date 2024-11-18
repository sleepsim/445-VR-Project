using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        transform.LookAt(targetPosition);
        //transform.LookAt(cam.position);

        transform.Rotate(0, 180f, 0);
    }
}

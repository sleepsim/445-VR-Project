using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        SwitchToCamera(currentCameraIndex);
    }

    public void SwitchToCamera(int index)
    {
        if (index < 0 || index >= cameras.Length)
            return;

        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }
        currentCameraIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToCamera(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToCamera(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    public GameObject[] rigs;

    // Start is called before the first frame update
    void Start()
    {
        SwitchToCamera(currentCameraIndex);
    }

    public void SwitchToCamera(int index)
    {
        if (index < 0 || index >= cameras.Length)
            return;

        //Change current camera
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }

        //
        for (int i = 0;i < rigs.Length; i++)
        {
            rigs[i].gameObject.SetActive(i == index);
            //rigs[i].gameObject.GetComponentInChildren<XRController>().enabled = (i == index);
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

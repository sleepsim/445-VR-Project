using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPriorityController : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    public KeyCode changePriorityKey = KeyCode.Tab;

    private void Start()
    {
        // Ensure all cameras start with the same priority
        foreach (var camera in virtualCameras)
        {
            camera.Priority = 0;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(changePriorityKey))
        {
            ChangeCameraPriority();
        }
    }

    private void ChangeCameraPriority()
    {
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority += 1; // Increment priority
            if (virtualCameras[i].Priority > 10) // Reset if priority exceeds a limit
            {
                virtualCameras[i].Priority = 0;
            }
        }

        // Optionally, you can set the highest priority to the first camera
        // if you want a specific behavior:
        int maxPriorityIndex = 0;
        for (int i = 1; i < virtualCameras.Length; i++)
        {
            if (virtualCameras[i].Priority > virtualCameras[maxPriorityIndex].Priority)
            {
                maxPriorityIndex = i;
            }
        }
        // Set the camera with the highest priority to be active
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = i == maxPriorityIndex ? 10 : 0;
        }
    }
}

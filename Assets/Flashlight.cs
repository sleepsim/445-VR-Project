using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flashlight : MonoBehaviour
{
    public AudioSource audioClip;
    public GameObject flashlight;

    public InputAction oculusController;

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyUp(KeyCode.Space))
        //{
        //    flashlight.SetActive(!flashlight.activeSelf); //Toggle on and off
        //}

        if (oculusController.triggered)
        {
            flashlight.SetActive(!flashlight.activeSelf);
            audioClip.Play();
        }
    }

    private void OnEnable()
    {
        oculusController.Enable();
    }

    private void OnDisable()
    {
        oculusController.Disable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public AudioSource audioClip;
    public GameObject flashlight;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            flashlight.SetActive(!flashlight.activeSelf); //Toggle on and off
        }
    }
}

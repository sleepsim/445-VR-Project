using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorButton : MonoBehaviour
{
    public int numVal;
    public GameObject RedButton,BlueButton, GreenButton;
    public GameObject selfButton;
    public AudioSource audioSuccess, audioFail;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (GlobalVariables.numSequence.Count < 3)
        {
            GlobalVariables.numSequence.Add(numVal);
            Debug.Log("Added number: " + numVal + "Current List: " + GlobalVariables.numSequence);
            selfButton.SetActive(false);
        }
        else if (GlobalVariables.numSequence.Count == 3)
        {
            if (GlobalVariables.checkSequence())
            {
                Debug.Log("Check Sequence Success: " + GlobalVariables.numSequence);
                GlobalVariables.numSequence.Clear();
                audioSuccess.Play();
                return;
            }
            audioFail.Play();
            GlobalVariables.numSequence.Clear();
            RedButton.SetActive(true);
            BlueButton.SetActive(true);
            GreenButton.SetActive(true);
            GlobalVariables.numSequence.Add(numVal);
            selfButton.SetActive(false);
        }
    }
    
}

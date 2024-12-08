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
        GlobalVariables.numSequence.Add(numVal);
        Debug.Log(GlobalVariables.numSequence.Count);
        if (GlobalVariables.numSequence.Count < 3)
        {
            //GlobalVariables.numSequence.Add(numVal);
            Debug.Log("Added number: " + numVal + "Current List: " + GlobalVariables.numSequence.ToString());
            selfButton.SetActive(false);
        }
        else if (GlobalVariables.numSequence.Count == 3)
        {
            if (GlobalVariables.checkSequence())
            {
                //Debug.Log("Added number: " + numVal + "Current List: " + GlobalVariables.numSequence.ToString());
                //Debug.Log("Check Sequence Success: " + GlobalVariables.numSequence.ToString());
                GlobalVariables.numSequence.Clear();
                audioSuccess.Play();
                RedButton.SetActive(false);
                BlueButton.SetActive(false);
                GreenButton.SetActive(false);
                return;
            }
            Debug.Log("Check sequence failed");
            audioFail.Play();
            GlobalVariables.numSequence.Clear();
            //Debug.Log(GlobalVariables.numSequence.ToString());
            RedButton.SetActive(true);
            BlueButton.SetActive(true);
            GreenButton.SetActive(true);
            //GlobalVariables.numSequence.Add(numVal);
            //selfButton.SetActive(false);
        }
    }
    
}

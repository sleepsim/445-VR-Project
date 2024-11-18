using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestInteractObject : MonoBehaviour
{
    public void LogMessage()
    {
        Debug.Log("XR Simple Interactable selected!");
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Get the Interactor that triggered the event
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

        if (interactor != null)
        {
            // Log the Interactor's name
            Debug.Log($"Interactor: {interactor.name}");

            // Log the Interactor's parent (if it has one)
            if (interactor.transform.parent != null)
            {
                Debug.Log($"Interactor's Parent: {interactor.transform.parent.name}");
            }
            else
            {
                Debug.Log("Interactor has no parent.");
            }
        }
        else
        {
            Debug.Log("No valid interactor found.");
        }
    }
}

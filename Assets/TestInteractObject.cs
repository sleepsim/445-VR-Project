using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestInteractObject : MonoBehaviour
{
    public Transform socketTransform;
    public AudioSource audioPlate;

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

            // Access the parent of the Interactor
            Transform parent = interactor.transform.parent;
            if (parent != null)
            {
                Debug.Log($"Interactor's Parent: {parent.name}");

                // Try to find the "Sphere Drop Zone" object
                Transform sphereDropZone = parent.Find("Sphere Drop Zone"); // Use the exact name of the object
                if (sphereDropZone != null)
                {
                    // Get the XRSocketInteractor script from the Sphere Drop Zone
                    XRSocketInteractor socketInteractor = sphereDropZone.GetComponent<XRSocketInteractor>();
                    if (socketInteractor != null)
                    {
                        // Run the if statement to check the selectTarget
                        if (socketInteractor.interactablesSelected.Count > 0)
                        {
                            audioPlate.Play();

                            XRBaseInteractable attachedInteractable = (XRBaseInteractable)socketInteractor.interactablesSelected[0];
                            Debug.Log("Attached Object: " + attachedInteractable.transform.name);

                            GameObject attachedObject = attachedInteractable.gameObject;

                            //Disable socket interactor
                            socketInteractor.enabled = false;

                            //Remove parents and transform
                            attachedObject.transform.SetParent(null);
                            attachedObject.transform.position = socketTransform.position;

                            Debug.Log(attachedObject.transform.position);
                            Debug.Log(socketTransform.localPosition);

                            socketInteractor.enabled = true;
                        }
                        else
                        {
                            Debug.Log("No object attached.");
                        }
                    }
                    else
                    {
                        Debug.LogWarning("Sphere Drop Zone does not have an XRSocketInteractor script.");
                    }
                }
                else
                {
                    Debug.LogWarning("Sphere Drop Zone not found in the parent's hierarchy.");
                }
            }
            else
            {
                Debug.LogWarning("Interactor has no parent.");
            }
        }
        else
        {
            Debug.LogWarning("No valid interactor found.");
        }
    }
}

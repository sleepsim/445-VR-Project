using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class CakeScript : MonoBehaviour
{
    public GameObject cake;
    public GameObject dropZone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear"))
        {
            Debug.Log("Game Done");
            SceneManager.LoadScene("EndScreen");
            //endScreen();
        }

        Debug.Log(other.tag);
    }

    //private IEnumerator endScreen()
    //{
    //    Debug.Log("Game Done");

    //    yield return new WaitForSeconds(5f); // Wait for 5 seconds
    //    SceneManager.LoadScene("EndScreen");

    //}

    //public void OnSelectEntered(SelectEnterEventArgs args)
    //{
    //    // Get the Interactor that triggered the event
    //    XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;

    //    if (interactor != null)
    //    {
    //        // Log the Interactor's name
    //        Debug.Log($"Interactor: {interactor.name}");

    //        // Access the parent of the Interactor
    //        Transform parent = interactor.transform.parent;
    //        if (parent != null)
    //        {
    //            Debug.Log($"Interactor's Parent: {parent.name}");

    //            // Try to find the "Sphere Drop Zone" object
    //            Transform sphereDropZone = parent.Find("Sphere Drop Zone"); // Use the exact name of the object
    //            if (sphereDropZone != null)
    //            {
    //                sphereDropZone.gameObject.SetActive(true);
    //                // Get the XRSocketInteractor script from the Sphere Drop Zone
    //                XRSocketInteractor socketInteractor = sphereDropZone.GetComponent<XRSocketInteractor>();

    //                if (socketInteractor != null)
    //                {
    //                    socketInteractor.enabled = true;
    //                    Vector3 worldPosition = cake.transform.position;
    //                    cake.transform.SetParent(null);
    //                    cake.transform.SetParent(sphereDropZone.transform, false);
    //                    cake.transform.position = worldPosition;
    //                }
    //                else
    //                {
    //                    Debug.LogWarning("That shit empty dawg");
    //                }
    //            }
    //            else
    //            {
    //                Debug.LogWarning("Sphere Drop Zone not found in the parent's hierarchy.");
    //            }
    //        }
    //        else
    //        {
    //            Debug.LogWarning("Interactor has no parent.");
    //        }
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No valid interactor found.");
    //    }
    //}
}

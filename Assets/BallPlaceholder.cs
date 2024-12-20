using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallPlaceholder : MonoBehaviour
{
    public Material r, g, b;
    public MeshRenderer placeholderBallMesh;
    public GameObject placeholderBall;
    public XRSocketInteractor socket;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        XRBaseInteractable grabbedObj = (XRBaseInteractable)args.interactableObject;
        //Debug.Log("Grabbed object: " + grabbedObj.gameObject.name);
        if (grabbedObj != null)
        {
            //Debug.Log("Grabbed object: " + grabbedObj.gameObject.name);
            if (grabbedObj.CompareTag("ball"))
            {
                string strHold = grabbedObj.name;
                switch (strHold)
                {
                    case string s when s.Contains("Red"):
                        placeholderBall.SetActive(true);
                        placeholderBallMesh.material = r;
                        //Debug.Log("red");
                        break;
                    case string s when s.Contains("Blue"):
                        placeholderBall.SetActive(true);
                        placeholderBallMesh.material = b;
                        //Debug.Log("blue");
                        break;
                    case string s when s.Contains("Green"):
                        placeholderBall.SetActive(true);
                        placeholderBallMesh.material = g;
                        //Debug.Log("Green");
                        break;
                    default:
                        break;
                }
            }

        }
        else
        {
            Debug.Log("Empty not grabbing anything");
        }

    }

    public void Update()
    {
        //// Find the GameObject by name
        //IXRSelectInteractable foundObject = socket.interactablesSelected.Find(obj => obj.transform.name == "Red Sphere");
        //Debug.Log(foundObject.transform.name);

        IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

        //Debug.Log(objName);

        //Debug.Log(objName != null);
        placeholderBall.SetActive(objName != null);
    }
}

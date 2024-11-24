using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallColourReveal : MonoBehaviour
{
    public GameObject collisionObj;
    public GameObject ball;
    public Material ballColour;
    public Material defaultBallColour;
    public MeshRenderer ballRenderer;

    XRGrabInteractable parentScript;

    public void Start()
    {
       parentScript = GetComponentInParent<XRGrabInteractable>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //If the collider is the player (toy) activate color and allow it to be grabbable
        {
            var materialsCopy = ballRenderer.materials;
            materialsCopy[0] = ballColour;
            ballRenderer.materials = materialsCopy;
            parentScript.enabled = true;
        }

        //else {
        //    var materialsCopy = ballRenderer.materials;
        //    materialsCopy[0] = defaultBallColour;
        //    ballRenderer.materials = materialsCopy;
        //}
    }

    public void OnTriggerExit(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    var materialsCopy = ballRenderer.materials;
        //    materialsCopy[0] = defaultBallColour;
        //    ballRenderer.materials = materialsCopy;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColourReveal : MonoBehaviour
{
    public GameObject collisionObj;
    public GameObject ball;
    public Material ballColour;
    public Material defaultBallColour;
    public MeshRenderer ballRenderer;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            var materialsCopy = ballRenderer.materials;
            materialsCopy[0] = ballColour;
            ballRenderer.materials = materialsCopy;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            var materialsCopy = ballRenderer.materials;
            materialsCopy[0] = defaultBallColour;
            ballRenderer.materials = materialsCopy;
        }
    }
}

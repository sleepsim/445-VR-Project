using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bear")
        {
            //End game
        }
    }
}

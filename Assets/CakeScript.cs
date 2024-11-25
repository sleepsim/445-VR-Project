using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeScript : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bear")
        {
            

        }
    }

    private IEnumerator endScreen()
    {
        Debug.Log("Game Done");

       


        yield return new WaitForSeconds(5f); // Wait for 5 seconds

    }
}

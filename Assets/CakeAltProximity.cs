using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CakeAltProximity : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Done");
            SceneManager.LoadScene("Outro");
            //endScreen();
        }
    }
}

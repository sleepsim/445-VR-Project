using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject doorBlock;
    public AudioSource audioClip;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorBlock.SetActive(false);
            audioClip.Play();
        }

        else
        {
            doorBlock.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorBlock.SetActive(true);
            audioClip.Play();
        }
    }
}

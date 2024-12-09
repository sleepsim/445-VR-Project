using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class CakeAlt : MonoBehaviour
{
    public GameObject toyCakeCollider;
    public GameObject cakeObj;
    public GameObject placehold;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        placehold.SetActive(true);
        cakeObj.SetActive(false);
        toyCakeCollider.SetActive(true);
    }
}

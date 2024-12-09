using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class CakeAlt : MonoBehaviour
{
    public GameObject toyCakeCollider;
    public GameObject cakeObj;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        cakeObj.SetActive(false);
        toyCakeCollider.SetActive(true);
    }
}

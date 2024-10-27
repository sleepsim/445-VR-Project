using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureSwitch : MonoBehaviour
{
    [SerializeField] private Value currentVal; // Reference to the Value object
    [SerializeField] private Animator animator; // Reference to the Animator

    [SerializeField] private GameObject correctBall;

    private void OnTriggerEnter(Collider other )
    {
        // Check if the collider is the sphere (or whatever tag you use)
        if (other.gameObject == correctBall) // Ensure the sphere has the "Player" tag
        {
            currentVal.AddPressureSwitch(this); // Notify the current value
            animator.SetBool("Down", true); // Trigger the animation to go down
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider is the sphere (or whatever tag you use)
        if (other.gameObject == correctBall) // Ensure the sphere has the "Player" tag
        {
            currentVal.RemovePressureSwitch(this); // Notify the current value
            animator.SetBool("Down", false); // Reset the animation
        }
    }
}

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

            switch(correctBall.name)
            {
                case "Green Sphere":
                    GlobalVariables.switch3 = true;
                    break;
                case "Blue Sphere":
                    GlobalVariables.switch2 = true;
                    break;
                case "Red Sphere":
                    GlobalVariables.switch1 = true;
                    break;
                default:
                    break;
            }
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

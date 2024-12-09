using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolveCanvas : MonoBehaviour
{
    public Camera playerCamera;  // The camera that the canvas will revolve around
    public float distanceFromCamera = 5f;  // Distance of the canvas from the camera
    public float height = 2f;  // The fixed height of the canvas from the ground
    public float positionSmoothSpeed = 5f;  // Speed of position smoothing

    void Update()
    {
        // Get the camera's position
        Vector3 cameraPosition = playerCamera.transform.position;

        // Get the camera's horizontal (yaw) rotation angle
        float yaw = playerCamera.transform.eulerAngles.y;

        // Calculate the direction to the canvas position (horizontal rotation only)
        Vector3 direction = new Vector3(Mathf.Sin(yaw * Mathf.Deg2Rad), 0, Mathf.Cos(yaw * Mathf.Deg2Rad));

        // Calculate the target position for the canvas
        Vector3 targetPosition = cameraPosition + direction * distanceFromCamera;

        // Fix the canvas height to be constant
        targetPosition.y = height;

        // Smoothly move the canvas towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * positionSmoothSpeed);

        // Make the canvas face the camera instantly
        transform.LookAt(playerCamera.transform);
        transform.Rotate(0, 180f, 0);
    }
}

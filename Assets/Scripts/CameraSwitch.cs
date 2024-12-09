using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using XRController = UnityEngine.XR.Interaction.Toolkit.XRController;

public class CameraSwitch : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    public GameObject[] rigs;

    public GameObject toyModel;
    public GameObject childModel;

    [Header("Controller Inputs")]
    public InputAction cameraOneButton;
    public InputAction cameraTwoButton;
    public InputAction instructionsButton;

    [Header("Instruction Canvas")]
    public GameObject toyInstruction;
    public GameObject childInstruction;

    // Start is called before the first frame update
    void Start()
    {
        SwitchToCamera(currentCameraIndex);
        toyModel.SetActive(false);
    }

    public void SwitchToCamera(int index)
    {
        if (index < 0 || index >= cameras.Length)
            return;

        //Change current camera
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(i == index);
        }

        //
        for (int i = 0;i < rigs.Length; i++)
        {
            rigs[i].gameObject.SetActive(i == index);
            //rigs[i].gameObject.GetComponentInChildren<XRController>().enabled = (i == index);
        }

        currentCameraIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToCamera(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToCamera(1);
        //if (primaryButtonAction.action.triggered) SwitchToCamera(0);
        //if (secondaryButtonAction.action.triggered)SwitchToCamera(1);

        if (cameraOneButton.triggered)
        {
            toyModel.SetActive(false);
            childModel.SetActive(true);
            //Vector3 scaledVec = new Vector3(rigs[1].transform.position.x / childModel.transform.localScale.x, rigs[1].transform.position.y / childModel.transform.localScale.y, rigs[1].transform.position.z / childModel.transform.localScale.z);
            childModel.transform.position = new Vector3(rigs[1].transform.position.x, rigs[1].transform.position.y - 115, rigs[1].transform.position.z + 105);

            Vector3 targetPosition = new Vector3();
            Vector3 targetRotation = new Vector3();

            Transform childPos = rigs[1].transform;
            if (childPos.position.x > - 5 && childPos.position.x < 90)
            {
                //Middle
                targetPosition = new Vector3(108, -16, -90);
                targetRotation = new Vector3(0, 3, 0);
            }
            else if(childPos.position.x > -5 && childPos.position.x > 90)
            {
                //Right
                targetPosition = new Vector3(130, -16, 158);
                targetRotation = new Vector3(0, -92, 0);
            }
            else if(childPos.position.x < -5)
            {
                //Left
                targetPosition = new Vector3(-143,-16,-56);
                targetRotation = new Vector3(0,94,0);
            }

            childModel.transform.position = targetPosition;
            childModel.transform.rotation = Quaternion.Euler(targetRotation);

            SwitchToCamera(0);
        }
        if (cameraTwoButton.triggered)
        {
            toyModel.SetActive(true);
            childModel.SetActive(false);
            toyModel.transform.position = rigs[0].transform.position;
            Vector3 heightOffset = toyModel.transform.position;
            heightOffset.y = 3.85f;
            toyModel.transform.position = heightOffset;
            toyModel.transform.rotation = rigs[0].transform.rotation;
            SwitchToCamera(1);
        }

        if(instructionsButton.triggered)
        {
            //If in toy view open instructions for toy
            if (currentCameraIndex == 0)
            {
                toyInstruction.SetActive(!toyInstruction.activeSelf);
            }
            //If in child view open instructions for child
            if(currentCameraIndex == 1)
            {
                childInstruction.SetActive(!childInstruction.activeSelf);
            }
        }
    }

    void OnEnable()
    {
        //flashlight = action.FindAction()
        cameraOneButton.Enable();
        cameraTwoButton.Enable();
        instructionsButton.Enable();
    }

    private void OnDisable()
    {
        cameraOneButton.Disable();
        cameraTwoButton.Disable();
        instructionsButton.Disable();
    }
}

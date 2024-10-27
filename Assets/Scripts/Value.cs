using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Value : MonoBehaviour
{
    public bool IsValueRevealed = false;
    [SerializeField] private int requiredSwitchesToOpen = 1;
    private List<PressureSwitch> currentSwitchesOpen = new();
    [SerializeField] private GameObject cubeToReveal;

    public void AddPressureSwitch(PressureSwitch currentSwitch){
        if (!currentSwitchesOpen.Contains(currentSwitch)){
            currentSwitchesOpen.Add(currentSwitch);
        }
        TryOpen();
    }
    public void RemovePressureSwitch(PressureSwitch currentSwitch){
        if (currentSwitchesOpen.Contains(currentSwitch)){
            currentSwitchesOpen.Remove(currentSwitch);
        }
        TryOpen();
    }

    public void TryOpen(){
        if(currentSwitchesOpen.Count == requiredSwitchesToOpen){
            ShowVal();
        } else if (currentSwitchesOpen.Count < requiredSwitchesToOpen){
            HideVal();
        }
    }

    private void ShowVal()
    {
        IsValueRevealed = true;
        // Reveal the cube when the conditions are met
        if (cubeToReveal != null)
        {
            cubeToReveal.SetActive(true); // Make the cube visible
        }
    }

    private void HideVal()
    {
        IsValueRevealed = false;
        // Hide the cube if the conditions are not met
        if (cubeToReveal != null)
        {
            cubeToReveal.SetActive(false); // Make the cube invisible
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ensure the cube is hidden at the start
        if (cubeToReveal != null)
        {
            cubeToReveal.SetActive(false); // Hide the cube initially
        }
    }
}

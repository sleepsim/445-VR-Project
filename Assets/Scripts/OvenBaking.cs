using System.Collections;
using UnityEngine;

public class OvenController : MonoBehaviour
{
    public GameObject button; // Reference to the button (cylinder)
    public Material redMaterial; // Material for the red (non-pressable) state
    public Material greenMaterial; // Material for the green (pressable) state
    public GameObject cakePrefab; // Cake object to spawn
     [SerializeField] private Animator animator;

    private bool[] itemsPresent = new bool[4]; // Tracks which items are present
    private bool buttonPressable = false; // Tracks if the button can be pressed
    private bool cakeRevealed = false; // To prevent multiple reveals
    private Renderer buttonRenderer; // Renderer for the button

    private void Start()
    { 
        // Spawn the cake at a fixed position relative to the oven
    
          if (cakePrefab != null)
        {
            cakePrefab.SetActive(false); // Make the cube invisible
        }
       

        // Get the Renderer of the button to change its color
        buttonRenderer = button.GetComponent<Renderer>();
        if (buttonRenderer != null)
        {
            buttonRenderer.material = redMaterial; // Default to red
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckItemTag(other, true);
        if (buttonPressable && !cakeRevealed && IsButtonPressed())
        {
        animator.SetBool("Down", true);  // Reset the animation when button is not pressable or cake revealed
    }
    }

    private void OnTriggerExit(Collider other)
    {
        CheckItemTag(other, false);
    }

    private void CheckItemTag(Collider other, bool isEntering)
    {
        switch (other.tag)
        {
            case "item1":
            Debug.Log("sugar in");
                itemsPresent[0] = isEntering;
                break;
            case "item2":
             Debug.Log("milk in");
                itemsPresent[1] = isEntering;
                break;
            case "item3":
             Debug.Log("egg in");
                itemsPresent[2] = isEntering;
                break;
            case "item4":
             Debug.Log("flour in");
                itemsPresent[3] = isEntering;
                break;
        }
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        buttonPressable = itemsPresent[0] && itemsPresent[1] && itemsPresent[2] && itemsPresent[3];

        // Change button color based on pressability
        if (buttonRenderer != null)
        {
            buttonRenderer.material = buttonPressable ? greenMaterial : redMaterial;
        }
    }

    private void Update()
    {
        if (buttonPressable && !cakeRevealed && IsButtonPressed())
        {
            StartCoroutine(RevealCake());
            Debug.Log("revealCake");
        }  
    }

    private bool IsButtonPressed()
    {
        return Input.GetKeyDown(KeyCode.Alpha3);
    }

    private IEnumerator RevealCake()
    {Debug.Log("Cake Revealed");
        cakeRevealed = true; // Prevent multiple reveals
        yield return new WaitForSeconds(5f); // Wait for 5 seconds
        cakePrefab.SetActive(true); // Show the cake
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public GameObject pic1, pic2, buttonNext, buttonPrev;
    private int currIndex = 0;

    public void next()
    {
        currIndex++;
        Debug.Log("clicked");
    }

    public void prev()
    {
        currIndex--;
        Debug.Log("clicked");
    }

    void Update()
    {
        switch (currIndex)
        {
            case 0:
                pic1.SetActive(true);
                pic2.SetActive(false);
                buttonPrev.SetActive(false);
                break;
            case 1: 
                pic1.SetActive(false);
                pic2.SetActive(true); 
                buttonPrev.SetActive(true);
                break;
            case 2:
                SceneManager.LoadScene("Main");
                break;
            default:
                break;
        }
    }
}

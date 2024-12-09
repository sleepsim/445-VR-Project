using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButtonOutro : MonoBehaviour
{
    //Modified for outro (3)
    public GameObject out1, out2, out3, buttonNext, buttonPrev;
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
                out1.SetActive(true);
                out2.SetActive(false);
                out3.SetActive(false);
                buttonPrev.SetActive(false);
                break;
            case 1:
                out1.SetActive(false);
                out2.SetActive(true);
                out3.SetActive(false);
                buttonPrev.SetActive(true);
                break;
            case 2:
                out1.SetActive(false);
                out2.SetActive(false);
                out3.SetActive(true);
                buttonPrev.SetActive(true);
                break;
            case 3:
                SceneManager.LoadScene("EndScreen");
                break;
            default:
                break;
        }
    }
}

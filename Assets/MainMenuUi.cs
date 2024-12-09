using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuUi : MonoBehaviour
{

    public void playGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void mainMene()
    {
        SceneManager.LoadScene("StartMenu");
    }

}

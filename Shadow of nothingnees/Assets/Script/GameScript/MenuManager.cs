using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject GaneMenu;
    public GameObject StartMenu;
    public GameObject Can;
   public void PlayGame()
    {
       SceneManager.LoadScene("Game");
    }

    public void GainMenu()
    {

        GaneMenu.SetActive(true);
        StartMenu.SetActive(false);
        Can.SetActive(false);
    }

    public void ExitGainMenu()
    {
        GaneMenu.SetActive(false);
        Can.SetActive(true);
        StartMenu.SetActive(true);

    }
}

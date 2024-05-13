using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateLogic : MonoBehaviour
{
    public GameObject menu;
    private void Start()
    {
        Pause();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Continue() 
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Pause() 
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}

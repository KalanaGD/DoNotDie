using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;

    private void Update()
    {
        PauseMenu();
        
    }

    private void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _pauseMenu.SetActive(true);
        }
    }

    public void PauseButton()
    {
        _pauseMenu.SetActive(true);
    }

    public void Continue()
    {
        _pauseMenu.SetActive(false);
    }

    public void MainMenu()
    {

    }
    
    public void Setting()
    {

    }
    
    public void Quit()
    {
        Application.Quit();
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject shopButton;

    public static bool gameisPaused = false;




    private void Update()
    {
        PauseMenu();
    }



    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }



    public void ExitGame()
    {
        Application.Quit();
    }



    public void PauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }
    }



    public void ReturnToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("0-MainMenu");

    }



    public void Resume()
    {
        pauseMenu.SetActive(false);
        shopButton.SetActive(true);
        Time.timeScale = 1f;
        gameisPaused = false;

    }



    public void Pause()
    {
        pauseMenu.SetActive(true);
        shopButton.SetActive(false);
        Time.timeScale = 0f;
        gameisPaused = true;


    }
}

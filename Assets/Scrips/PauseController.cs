using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject pausePanel;

   // [SerializeField]
    //GameObject settingsPanel;

    public static bool isPaused;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0.0F;
        isPaused = true;
    }

    public void Home(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0F;
        isPaused=false;
    }

    public void Reload()
    {
        Time.timeScale = 1.0F;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

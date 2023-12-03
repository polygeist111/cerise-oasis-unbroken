using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject infoMenuUI;
    public GameObject HUDUI;
    public GameObject StatsUI;
    public Object menuScene;
    private bool inHelpMenu = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inHelpMenu) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        //Closes tab stats menu if needed
        if (Input.GetKey(KeyCode.Tab)) {
            if (isPaused) {
                StatsUI.SetActive(false);
            }
        }
    }

    void Pause() {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        HUDUI.SetActive(false);
        //Time.timeScale = 0f;
    }

    public void Resume() {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        HUDUI.SetActive(true);
        //Time.timeScale = 1f;
    }

    public void LoadMenu() {
        Debug.Log("loading menu");
        //Time.timeScale = 1f;
        SceneManager.LoadScene(menuScene.name);
    }

    public void QuitGame() {
        Debug.Log("quitting game");
        Application.Quit();
    }

    public void Info() {
        Debug.Log("info time");
        pauseMenuUI.SetActive(false);
        infoMenuUI.SetActive(true);
        inHelpMenu = true;
        //SceneManager.LoadScene(menuScene.name);
    }

    public void Return() {
        infoMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        inHelpMenu = false;
    }
}

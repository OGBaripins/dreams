using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    private GameObject player;
    public GameObject optionMenuUI;

    private void Awake()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<FirstPersonController>().enabled = true;
        player.GetComponent<PlayerShoot>().enabled = true;
        Cursor.visible = false;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        player.GetComponent<FirstPersonController>().enabled = false;
        player.GetComponent<PlayerShoot>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);
    }

    public void LoadMenu_Back()
    {
        pauseMenuUI.SetActive(true);
        optionMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Audio_Video()
    {
        Debug.Log("Just a test for now");
    }
}

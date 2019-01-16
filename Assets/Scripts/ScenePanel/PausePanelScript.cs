using System;
using UnityEngine;


public class PausePanelScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;

    public static bool isGamePaused = false;
    public GameObject pausePanel;
    public GameObject pausePopup;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        // show cursor
        Cursor.visible = true;

        pausePanel.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    private void ResumeGame()
    {
        // hide cursor
        Cursor.visible = false;

        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    public void ClickResumeGame()
    {
        ResumeGame();
    }

    public void ClickSaveGame()
    {
        SaveGame.Save(gameManager.GetPlayerData());
        pausePopup.SetActive(true);
    }

    public void ClickExitMenu()
    {
        gameManager.ExitMainMenu();
    }

    public void ClickOkPausePopup()
    {
        pausePopup.SetActive(false);
    }
}

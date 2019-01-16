using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject dayNightPanel;
    public GameObject helpPanel;
    public GameObject settingsPanel;
    public GameObject popupSave;

    private void Start()
    {
        Debug.Log(Application.persistentDataPath);
    }

    public void ClickNewGame()
    {
        menuPanel.SetActive(false);
        dayNightPanel.SetActive(true);
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

    public void ClickLoadGame()
    {
        PlayerData playerData = SaveGame.Load();
        if (playerData != null)
        {
            PlayerPrefs.SetInt("isLoadGame", 1);
            SceneManager.LoadScene(playerData.level);
        }
        else
        {
            PlayerPrefs.SetInt("isLoadGame", 0);
            popupSave.SetActive(true);
        }
    }

    public void ClickOkPopup()
    {
        popupSave.SetActive(false);
    }

    public void ClickExitMenu()
    {
        menuPanel.SetActive(true);
        dayNightPanel.SetActive(false);
        helpPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ClickDayMode()
    {
        SceneManager.LoadScene("Level01");
    }

    public void ClickNightMode()
    {
        SceneManager.LoadScene("Level11");
    }

    public void ClickHelp()
    {
        menuPanel.SetActive(false);
        helpPanel.SetActive(true);
    }

    public void ClickSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
}

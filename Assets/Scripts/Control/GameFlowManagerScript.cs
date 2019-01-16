using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameFlowManagerScript : MonoBehaviour
{
    // for trigger game over
    bool isOver = false;
    public float gameOverDelay;

    public GameObject completePanel;
    public GameObject gameOverPanel;
    public GameObject congraPanel;

    // for level
    public static int maxLevel = 3;

    // for game over display
    public Text aliveScoreText;
    public Text dieScoreText;
    string curScore;

    // for save
    public static bool isLoadSave = false;
    public Transform player_tf;

    // background music
    public AudioSource backgroundAudioSource;

    public void GameOver()
    {
        if (!isOver)
        {
            isOver = true;

            // stop score
            curScore = aliveScoreText.text;
            aliveScoreText.enabled = false;
            dieScoreText.text = curScore;

            Invoke("ShowGameOverPanel", gameOverDelay);
        }
    }

    public void ShowGameOverPanel()
    {
        // show cursor
        Cursor.visible = true;

        // stop background music
        if (backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop();
        }

        gameOverPanel.SetActive(true);
    }

    public void CompleteLevel()
    {
        // show cursor
        Cursor.visible = true;

        // stop background music
        if (backgroundAudioSource.isPlaying)
        {
            backgroundAudioSource.Stop();
        }

        int curLevel = SceneManager.GetActiveScene().buildIndex;
        if (curLevel % maxLevel == 0)
        {
            congraPanel.SetActive(true);
        }
        else
        {
            completePanel.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        // make sure game not freeze
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        // make sure game not freeze
        Time.timeScale = 1;

        int curLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(curLevel + 1);
    }

    public void ExitMainMenu()
    {
        // make sure game not freeze
        Time.timeScale = 1;

        // make sure load game is reset
        PlayerPrefs.SetInt("isLoadGame", 0);

        SceneManager.LoadScene("MenuScene");
    }

    public PlayerData GetPlayerData()
    {
        return new PlayerData(SceneManager.GetActiveScene().buildIndex, player_tf);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevelPanelScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;

    public Text completeLevelText;
    public Text aliveScoreText;
    public Text completeScoreText;

    void Start()
    {
        // display current level
        int maxLevel = GameFlowManagerScript.maxLevel;
        int curLevel = SceneManager.GetActiveScene().buildIndex % maxLevel;
        if (curLevel == 0)
            curLevel = maxLevel;

        completeLevelText.text = "Complete Level " + curLevel.ToString();

        // display score
        completeScoreText.text = "Score " + aliveScoreText.text;
        aliveScoreText.enabled = false;

        // disable esc to pause
        PausePanelScript.isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ClickNextLevel()
    {
        gameManager.NextLevel();
    }

    public void ClickExitMenu()
    {
        gameManager.ExitMainMenu();
    }
}

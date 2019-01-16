using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelScript : MonoBehaviour
{
    public GameFlowManagerScript gameManager;

    public Text dieScoreText;
    public Text displayScoreText;

    void Start()
    {
        // display score
        displayScoreText.text = "Score " + dieScoreText.text;
        dieScoreText.enabled = false;

        // disable esc to pause
        PausePanelScript.isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ClickRestartLevel()
    {
        gameManager.RestartLevel();
    }

    public void ClickExitMenu()
    {
        gameManager.ExitMainMenu();
    }
}

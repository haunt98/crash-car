using UnityEngine;
using UnityEngine.UI;

public class CongraPanelScript : MonoBehaviour
{
    public GameFlowManagerScript gameManger;

    public Text aliveScoreText;
    public Text congraScoreText;

    void Start()
    {
        // display score
        congraScoreText.text = "Score " + aliveScoreText.text;
        aliveScoreText.enabled = false;

        // disable esc to pause
        PausePanelScript.isGamePaused = true;
        Time.timeScale = 0;
    }

    public void ClickExitMenu()
    {
        gameManger.ExitMainMenu();
    }
}

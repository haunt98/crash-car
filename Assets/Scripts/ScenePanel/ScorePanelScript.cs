using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorePanelScript : MonoBehaviour
{
    public Text levelText;
    public Text aliveScore;
    public Transform player;

    void Start()
    {
        // display current level
        int maxLevel = GameFlowManagerScript.maxLevel;
        int curLevel = SceneManager.GetActiveScene().buildIndex % maxLevel;
        if (curLevel == 0)
            curLevel = maxLevel;
        levelText.text = "Level " + curLevel.ToString();
    }

    void Update()
    {
        aliveScore.text = player.position.z.ToString("0");
    }
}

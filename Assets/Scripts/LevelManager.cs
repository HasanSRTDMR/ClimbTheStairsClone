using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] TMP_Text levelText;
    [SerializeField] UIManager uIManager;
    float nextLevelScore;
    int gameLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        nextLevelScore = score.score + 100;
        if (Data.HaveRecord("GameLevel"))
            gameLevel = Data.GetLevel();
        levelText.text = "Level " + gameLevel;
    }

    // Update is called once per frame
    void Update()
    {
        LevelUp();
    }
    void LevelUp()
    {
        if (score.score>=(nextLevelScore-0.1) && GameState.playGame)
        {
            
            gameLevel++;
            Data.SaveScore(nextLevelScore);
            nextLevelScore += 100;
            Data.SaveLevel(gameLevel);
            uIManager.OpenWinPanel();
            
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

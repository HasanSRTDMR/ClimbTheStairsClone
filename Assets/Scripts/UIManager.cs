using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject gamePanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] Player playerScript;



    
    void Start()
    {
        pausePanel.SetActive(false);
        startPanel.SetActive(true);
        gamePanel.SetActive(true);
    }

 

    public void PlayGame()
    {
        pausePanel.SetActive(false);
        gamePanel.SetActive(true);
        startPanel.SetActive(false);
        GameState.playGame = true;
    }
    public void PauseGame()
    {
        pausePanel.SetActive(true);
        GameState.playGame = false;
    } 
    public void ResumeGame()
    {
        startPanel.SetActive(false);
        losePanel.SetActive(false);
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        GameState.playGame = true;
    }
    public void ContinueGame()
    {
        //Add Ad
        playerScript.gameObject.SetActive(true);
        playerScript.Resume();
        startPanel.SetActive(false);
        losePanel.SetActive(false);
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        winPanel.SetActive(false);
        GameState.playGame = true;
    }
    public void OpenLosePanel()
    {
        startPanel.SetActive(false);
        pausePanel.SetActive(false);
        losePanel.SetActive(true);
        gamePanel.SetActive(false);
        winPanel.SetActive(false);
        GameState.playGame = false;

    }
    public void OpenWinPanel()
    {
        startPanel.SetActive(false);
        pausePanel.SetActive(false);
        losePanel.SetActive(false);
        gamePanel.SetActive(false);
        winPanel.SetActive(true);
        GameState.playGame = false;
    }
}

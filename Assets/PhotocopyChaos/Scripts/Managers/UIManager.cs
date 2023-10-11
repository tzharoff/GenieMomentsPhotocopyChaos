using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;
using System;

public class UIManager : MonoBehaviour
{

    #region Singleton
    public static UIManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        HidePrompt();
        PlayerAnimator.OnWorking += OnWorkingCallback;
        PlayerDetection.OnNewQuest += OnNewQuestCallback;
    }
    #endregion


    [Header("Text Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    [Header("Image Elements")]
    [SerializeField] private Image progressbar;

    [Header("Game Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("Interaction Elements")]
    [SerializeField] private GameObject actionZone;


    private void OnDestroy()
    {
        PlayerAnimator.OnWorking -= OnWorkingCallback;
        PlayerDetection.OnNewQuest -= OnNewQuestCallback;
    }


    public void SetScoreText(int score)
    {
        scoreText.text = $"{score}";
    }

    public void StartActionZone()
    {
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                ShowHammerPrompt();
                break;
            case Tasks.Ink:
                ShowInkPrompt();
                break;
            case Tasks.Printing:
                ShowPrintPrompt();
                break;
            case Tasks.Paper:
                ShowKickPrompt();
                break;
        }
    }

    private void OnNewQuestCallback()
    {
        ResetWorkBar();
    }

    private void OnWorkingCallback(float workPercentage)
    {
        progressbar.fillAmount = workPercentage;
    }

    private void ShowPrompt()
    {
        actionZone.SetActive(true);
    }

    public void HidePrompt()
    {
        actionZone.SetActive(false);
        Debug.Log("HidePrompt is called");
    }

    public void ResetWorkBar()
    {
        progressbar.fillAmount = 0f;
    }

    public void ShowHammerPrompt()
    {
        promptText.text = $"Hammer Printer";
        ShowPrompt();
    }

    public void ShowInkPrompt()
    {
        promptText.text = $"Ink Printer";
        ShowPrompt();
    }

    public void ShowKickPrompt()
    {
        promptText.text = "Paper Printer";
        ShowPrompt();
    }

    public void ShowPrintPrompt()
    {
        promptText.text = "Print";
        ShowPrompt();
    }


    public void ShowGameOver()
    {
        GameManager.instance.StopGame();
        gameOverPanel.SetActive(true);
    }

    public void SetTimerText(string timeLeft)
    {
        timerText.text = timeLeft;
    }

    public void SetYourScoreText(string yourScore)
    {
        yourScoreText.text = yourScore;
    }

    public void SetHighScoreText(string highScore)
    {
        highScoreText.text = highScore;
    }

    public void StartGameButton()
    {
        mainMenuPanel.SetActive(false);
        GameManager.instance.StartGame();
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

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
    }
    #endregion

    [SerializeField] private float timerTime = 30f;

    private float timeTracker;

    private int tasksCompleted = 0;


    private void Start()
    {
        Initiliaze();
    }

    private void Update()
    {
        timeTracker -= Time.deltaTime;
        if(timeTracker <= 0)
        {
            timeTracker = 0f;
            if(tasksCompleted > GetHighScore())
            {
                SetHighScore(tasksCompleted);
            }
            UIManager.instance.SetYourScoreText(tasksCompleted.ToString());
            UIManager.instance.SetHighScoreText(GetHighScore().ToString());
            UIManager.instance.ShowGameOver();
        }
        UIManager.instance.SetTimerText(System.Math.Round(timeTracker).ToString());
    }

    private void Initiliaze()
    {
        StopGame();
        timeTracker = timerTime;
        tasksCompleted = 0;
        RegionalManager.instance.ShowQuestRegion();
        Player.instance.SetTaskIncomplete();
    }

    public void AddCompletedTask()
    {
        tasksCompleted++;
        UIManager.instance.SetScoreText(tasksCompleted);
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("High Score", 0);
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("High Score", score);
    }
}

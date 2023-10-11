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

    private int tasksCompleted = 0;



    private void Start()
    {
        Initiliaze();
    }

    private void Initiliaze()
    {
        tasksCompleted = 0;
        RegionalManager.instance.ShowQuestRegion();
        Player.instance.SetTaskIncomplete();
    }

    public void AddCompletedTask()
    {
        tasksCompleted++;
        UIManager.instance.SetScoreText(tasksCompleted);
    }
}

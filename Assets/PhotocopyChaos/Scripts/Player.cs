using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tasks
{
    Hammering,
    Ink,
    Printing,
    Paper,
    Quest
}

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

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


    [Header("Elements")]
    public PlayerAnimator playerAnimator;

    private bool taskCompleted = false;    
    private Tasks playerTask = Tasks.Quest;


    public void SetTaskComplete()
    {
        taskCompleted = true;
        playerTask = Tasks.Quest;
    }

    public void SetTaskIncomplete()
    {
        taskCompleted = false;
    }

    public bool GetTaskComplete()
    {
        return taskCompleted;
    }

    public void SetTaskHammering()
    {
        playerTask = Tasks.Hammering;
    }

    public void SetTaskPrinting()
    {
        playerTask = Tasks.Printing;
    }

    public void SetTaskPaper()
    {
        playerTask = Tasks.Paper;
        playerAnimator.SetPaperAnimation();
    }

    public void SetTaskInk()
    {
        playerTask = Tasks.Ink;
    }

    public Tasks GetPlayerTask()
    {
        return playerTask;
    }

}

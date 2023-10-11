using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDetection : MonoBehaviour
{

    public static Action OnTaskComplete;
    public static Action OnNewQuest;

    private bool task1 = false;
    private bool task2 = false;
    private bool task3 = false;

    private void Awake()
    {
        PlayerAnimator.OnWorking += OnWorkingCallback;
    }



    private void OnDestroy()
    {
        PlayerAnimator.OnWorking -= OnWorkingCallback;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Hammer":
                if(Player.instance.GetPlayerTask() == Tasks.Hammering)
                {
                    Hammer();
                }
                break;
            case "Paper":
                if(Player.instance.GetPlayerTask() == Tasks.Paper)
                {
                    Paper();
                }
                break;
            case "Ink":
                if(Player.instance.GetPlayerTask() == Tasks.Ink)
                Ink();
                break;
            case "Quest":
                if(Player.instance.GetPlayerTask() == Tasks.Quest)
                {
                    Quest();
                }
                break;
            case "Print":
                if(Player.instance.GetPlayerTask() == Tasks.Printing)
                {
                    Print();
                }
                break;
        }
    }

    public void ExitTrigger()
    {
        UIManager.instance.HidePrompt();
    }

    private void Hammer()
    {
        SoundManager.instance.PlayHammerPickupSound();
        RegionalManager.instance.ShowPrintRegion();
    }

    private void Paper()
    {
        SoundManager.instance.PlayPaperPickupSound();
        RegionalManager.instance.ShowPrintRegion();
    }

    private void Ink()
    {
        SoundManager.instance.PlayInkPickupSound();
        RegionalManager.instance.ShowPrintRegion();
    }

    private void Quest()
    {
        if (Player.instance.GetTaskComplete())
        {
            SoundManager.instance.PlayQuestCompleteSound();
            GameManager.instance.AddCompletedTask();
        }
        Player.instance.SetTaskPrinting();
        RegionalManager.instance.ShowPrintRegion();
        OnNewQuest?.Invoke();
    }

    private void Print()
    {
        NewTask();
    }

    private void NewTask()
    {
        UIManager.instance.HidePrompt();
        int randomAssignment = UnityEngine.Random.Range(1, 4);
        switch (randomAssignment)
        {
            case 1:
                UIManager.instance.ShowPrintPrompt();
                break;
            case 2:
                RegionalManager.instance.ShowHammerRegion();
                Player.instance.playerAnimator.StopAction();
                SoundManager.instance.PlayHammerBreakSound();
                Player.instance.SetTaskHammering();
                break;
            case 3:
                RegionalManager.instance.ShowPaperRegion();
                Player.instance.playerAnimator.StopAction();
                SoundManager.instance.PlayPaperBreakSound();
                Player.instance.SetTaskPaper();
                break;
            case 4:
                RegionalManager.instance.ShowInkRegion();
                Player.instance.playerAnimator.StopAction();
                SoundManager.instance.PlayInkBreakSound();
                Player.instance.SetTaskInk();
                break;
        }
    }

    private void OnWorkingCallback(float taskPercentage)
    {
        if(taskPercentage >= 1f)
        {
            Debug.Log("task is complete");
            CompleteTask();
        }
        if(taskPercentage > 0.75f && taskPercentage < 1f)
        {
            CheckTask3();
        } else if(taskPercentage > 0.5f && taskPercentage < 0.75f)
        {
            CheckTask2();
        } else if(taskPercentage > 0.25f && taskPercentage < 0.5f)
        {
            CheckTask1();
        }
    }

    private void CheckTask1()
    {
        if (task1)
        {
            return;
        }
        NewTask();
        task1 = true;
    }

    private void CheckTask2()
    {
        if (task2)
        {
            return;
        }
        NewTask();
        task2 = true;
    }

    private void CheckTask3()
    {
        if (task3)
        {
            return;
        }
        NewTask();
        task3 = true;
    }

    private void CompleteTask()
    {
        RegionalManager.instance.HideAllRegions();
        RegionalManager.instance.ShowQuestRegion();
        Player.instance.SetTaskComplete();
        task1 = false;
        task2 = false;
        task3 = false;
        SoundManager.instance.PlayTaskCompleteSound();
        OnTaskComplete?.Invoke();
    }
}

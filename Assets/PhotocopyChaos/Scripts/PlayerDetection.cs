using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerDetection : MonoBehaviour
{

    private List<string> tasks = new List<string>() { "Hammer", "Paper", "Ink", "Quest" };

    // Start is called before the first frame update
    void Start()
    {
        PopulateTasks();
    }

    private void PopulateTasks()
    {
        tasks = new List<string>() { "Hammer", "Paper", "Ink", "Quest" };
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
                Hammer();
                break;
            case "Paper":
                Paper();
                break;
            case "Ink":
                Ink();
                break;
            case "Quest":
                Quest();
                break;
            case "Print":
                Print();
                break;
        }
    }

    public void ExitTrigger()
    {
        Debug.Log("Player is exiting the trigger");
        UIManager.instance.HidePrompt();
        Player.instance.playerAnimator.StopPaperAnimation();
    }

    private void Hammer()
    {
        RegionalManager.instance.ShowPrintRegion();
        Player.instance.SetTaskHammering();
    }

    private void Paper()
    {
        RegionalManager.instance.ShowPrintRegion();
        Player.instance.SetTaskPaper();
    }

    private void Ink()
    {
        RegionalManager.instance.ShowPrintRegion();
        Player.instance.SetTaskInk();
    }

    private void Quest()
    {
        if (Player.instance.GetTaskComplete())
        {
            GameManager.instance.AddCompletedTask();
        }
        RegionalManager.instance.ShowPrintRegion();
    }

    private void Print()
    {
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                UIManager.instance.ShowHammerPrompt();
                break;
            case Tasks.Paper:
                UIManager.instance.ShowKickPrompt();
                break;
            case Tasks.Ink:
                UIManager.instance.ShowInkPrompt();
                break;
        }
        NewTask();

    }

    private void NewTask()
    {
        
        int randomAssignment = Random.Range(0, tasks.Count - 1);
        Debug.Log($"randomAssignment is {randomAssignment}");
        switch (tasks[randomAssignment])
        {
            case "Quest":
                RegionalManager.instance.ShowQuestRegion();
                Player.instance.SetTaskComplete();
                PopulateTasks();
                break;
            case "Hammer":
                RegionalManager.instance.ShowHammerRegion();
                tasks.Remove(tasks[randomAssignment]);
                break;
            case "Paper":
                RegionalManager.instance.ShowPaperRegion();
                tasks.Remove(tasks[randomAssignment]);
                break;
            case "Ink":
                RegionalManager.instance.ShowInkRegion();
                tasks.Remove(tasks[randomAssignment]);
                break;
        }

    }

}

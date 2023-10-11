using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectionSimple : MonoBehaviour
{
    //enter the region
    //begin filling up the bar
    //stop filling when something hits

    private bool fillBar = false;

    private float fillTime = 3f;
    private float currentFillTime = 0f;

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
                HandleHammer();
                break;
            case "Paper":
                HandlePaper();
                break;
            case "Ink":
                HandleInk();
                break;
            case "Quest":
                HandleQuest();
                break;
            case "Print":
                HandlePrint();
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Print"))
        {
            fillBar = false;
        }
    }

    private void HandleHammer()
    {
        if(Player.instance.GetPlayerTask() == Tasks.Hammering)
        {
            RegionalManager.instance.ShowPrintRegion();
        }
    }

    private void HandlePaper()
    {
        if(Player.instance.GetPlayerTask() == Tasks.Paper)
        {
            RegionalManager.instance.ShowPrintRegion();
        }
    }

    private void HandleInk()
    {
        if(Player.instance.GetPlayerTask() == Tasks.Ink)
        {
            RegionalManager.instance.ShowPrintRegion();
        }
    }

    private void HandleQuest()
    {
        if(Player.instance.GetPlayerTask() == Tasks.Quest)
        {
            RegionalManager.instance.ShowPrintRegion();
        }
    }

    private void HandlePrint()
    {
        fillBar = true;
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                Player.instance.playerAnimator.SetHammerAnimation();
                break;
            case Tasks.Ink:
                Player.instance.playerAnimator.SetInkAnimation();
                break;
            case Tasks.Printing:
                Player.instance.playerAnimator.SetKickAnimation();
                break;
            case Tasks.Paper:
                Player.instance.playerAnimator.SetPaperAnimation();
                break;
            case Tasks.Quest:
                Player.instance.playerAnimator.StopAction();
                break;
        }
    }
}

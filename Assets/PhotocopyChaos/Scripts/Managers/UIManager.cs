using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    }
    #endregion


    [Header("Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private GameObject actionZone;

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
                //not sure what I was doing with this
                break;
            case Tasks.Paper:
                ShowKickPrompt();
                break;
        }
    }

    private void ShowPrompt()
    {
        actionZone.SetActive(true);
    }

    public void HidePrompt()
    {
        actionZone.SetActive(false);
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance;

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

    [Header("Pickup Sounds")]
    [SerializeField] private AudioSource hammerPickupSound;
    [SerializeField] private AudioSource paperPickupSound;
    [SerializeField] private AudioSource tonerPickupSound;

    [Header("Success Sounds")]
    [SerializeField] private AudioSource questCompleteSound;
    [SerializeField] private AudioSource questTurnedInSound;
    [SerializeField] private AudioSource taskCompleteSound;

    [Header("Interaction Sounds")]
    [SerializeField] private AudioSource printSound;
    [SerializeField] private AudioSource hammeringSound;
    [SerializeField] private AudioSource kickingSound;
    [SerializeField] private AudioSource tonerSound;


#region SuccessSounds
    public void PlayQuestCompleteSound()
    {
        questCompleteSound.Play();
    }

    public void PlayQuestionTurnedInSound()
    {
        questTurnedInSound.Play();
    }

    public void TaskCompleteSound()
    {
        taskCompleteSound.Play();
    }
    #endregion



    #region Pickup sounds
    public void PlayHammerPickupSound()
    {
        hammerPickupSound.Play();
    }

    public void PlayPaperPickupSound()
    {
        paperPickupSound.Play();
    }

    public void PlayTonerPickupSound()
    {
        tonerPickupSound.Play();
    }
    #endregion

    #region Interaction Sounds
    public void PlayPrintSound()
    {
        printSound.Play();
    }

    public void PlayHammeringSound()
    {
        hammeringSound.Play();
    }

    public void PlayKickingSound()
    {
        kickingSound.Play();
    }

    public void PlayTonerSound()
    {
        tonerSound.Play();
    }
    #endregion


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{

    //elements
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void StartAction()
    {
        Debug.Log($"Player is starting action && task is {Player.instance.GetPlayerTask()}");
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                SetHammerAnimation();
                break;
            case Tasks.Ink:
                SetInkAnimation();
                break;
            case Tasks.Printing:
                //not sure what I was doing with this
                break;
            case Tasks.Paper:
                SetKickAnimation();
                break;
        }
    }

    public void StopAction()
    {
        Debug.Log("Action is being stopped");
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                StopKickAnimation();
                break;
            case Tasks.Ink:
                StopInkAnimation();
                break;
            case Tasks.Printing:
                //not sure
                break;
            case Tasks.Paper:
                StopKickAnimation();
                break;
        }
    }

    public void SetPaperAnimation()
    {
        animator.SetLayerWeight(1, 1);
    }

    public void StopPaperAnimation()
    {
        animator.SetLayerWeight(1, 0);
    }
    
    public void SetInkAnimation()
    {
        animator.SetBool(Animator.StringToHash("Inking"), true);
    }

    public void StopInkAnimation()
    {
        animator.SetBool(Animator.StringToHash("Inking"), false);
    }

    public void SetHammerAnimation()
    {
        animator.SetBool(Animator.StringToHash("Hammering"), true);
    }

    public void StopHammerAnimation()
    {
        animator.SetBool(Animator.StringToHash("Hammering"), false);
    }

    public void SetKickAnimation()
    {
        animator.SetBool(Animator.StringToHash("Kicking"), true);
    }

    public void StopKickAnimation()
    {
        animator.SetBool(Animator.StringToHash("Kicking"), false);
    }
}

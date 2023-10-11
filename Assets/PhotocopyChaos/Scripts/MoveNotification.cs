using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNotification : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Transform icon;
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;

    [Header("Settings")]
    [SerializeField] private float spinTime;
    [SerializeField] private float moveTime;
    [SerializeField] private float scaleTime;
    [SerializeField] private Vector3 scaleAmount;

    private bool enableMovement;
    private bool goingDown;
    private bool enableSpin;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        Spin();
        MoveUp();
        ScaleUp();
    }

    private void Spin()
    {
        LeanTween.rotateLocal(icon.gameObject, new Vector3(0f, 90f,0f), spinTime)
            .setFrom(0)
            .setEase(LeanTweenType.linear)
            .setOnComplete(Spin2);
    }

    private void Spin2()
    {
        LeanTween.rotateLocal(icon.gameObject, new Vector3(0f, 180f, 0f), spinTime)
            .setEase(LeanTweenType.linear)
            .setOnComplete(Spin3);
    }

    private void Spin3()
    {
        LeanTween.rotateLocal(icon.gameObject, new Vector3(0f, 270f, 0f), spinTime)
            .setEase(LeanTweenType.linear)
            .setOnComplete(Spin4);
    }

    private void Spin4()
    {
        LeanTween.rotateLocal(icon.gameObject, new Vector3(0f, 360f, 0f), spinTime)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(Spin);
    }

    private void MoveUp()
    {
        LeanTween.move(icon.gameObject, topPoint.position, moveTime)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(MoveDown);
    }

    private void ScaleUp()
    {
        LeanTween.scale(icon.gameObject, scaleAmount, moveTime)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(ScaleDown);
    }

    private void ScaleDown()
    {
        LeanTween.scale(icon.gameObject, Vector3.one, moveTime)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(ScaleUp);
    }

    private void MoveDown()
    {
        LeanTween.move(icon.gameObject, bottomPoint.position, moveTime)
            .setEase(LeanTweenType.easeOutBack)
            .setOnComplete(MoveUp);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private RectTransform groundIcon;

    [Header("Settings")]
    [SerializeField] private float fadeTime;

    // Start is called before the first frame update
    void Start()
    {
        FadeOut();
    }

    private void FadeOut()
    {
        LeanTween.alpha(groundIcon, 0.1f, fadeTime)
            .setEaseLinear()
            .setOnComplete(FadeIn);
    }

    private void FadeIn()
    {
        LeanTween.alpha(groundIcon, 1f, fadeTime)
            .setEaseLinear()
            .setOnComplete(FadeOut);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

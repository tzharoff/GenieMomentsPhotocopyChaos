using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintRegion : MonoBehaviour
{
    private bool insideTriggerRegion = false;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetTask()
    {
        switch (Player.instance.GetPlayerTask())
        {
            case Tasks.Hammering:
                UIManager.instance.ShowHammerPrompt();
                break;
            case Tasks.Ink:
                UIManager.instance.ShowInkPrompt();
                break;
            case Tasks.Paper:
                UIManager.instance.ShowKickPrompt();
                break;
            case Tasks.Printing:
                UIManager.instance.ShowPrintPrompt();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        insideTriggerRegion = true;
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);
        SetTask();
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        if(other.TryGetComponent<PlayerDetection>(out PlayerDetection playerDetection))
        {
            insideTriggerRegion = false;
            UIManager.instance.HidePrompt();
        }
    }
}

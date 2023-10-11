using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintRegion : MonoBehaviour
{
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
        ReliableOnTriggerExit.NotifyTriggerEnter(other, gameObject, OnTriggerExit);

        Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        ReliableOnTriggerExit.NotifyTriggerExit(other, gameObject);

        Debug.Log($"OnTriggerExit {other.name}");
        if(other.TryGetComponent<PlayerDetection>(out PlayerDetection playerDetection))
        {
            playerDetection.ExitTrigger();
        }
    }
}

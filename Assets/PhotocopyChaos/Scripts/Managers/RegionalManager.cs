using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionalManager : MonoBehaviour
{
    #region Singleton
    public static RegionalManager instance;

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

    [Header("Elements")]
    [SerializeField] private GameObject questRegion;
    [SerializeField] private GameObject printRegion;
    [SerializeField] private GameObject inkRegion;
    [SerializeField] private GameObject hammerRegion;
    [SerializeField] private GameObject paperRegion;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowQuestRegion()
    {
        questRegion.SetActive(true);
        printRegion.SetActive(false);
        inkRegion.SetActive(false);
        hammerRegion.SetActive(false);
        paperRegion.SetActive(false);
    }

    public void ShowPrintRegion()
    {
        questRegion.SetActive(false);
        printRegion.SetActive(true);
        inkRegion.SetActive(false);
        hammerRegion.SetActive(false);
        paperRegion.SetActive(false);
    }

    public void ShowInkRegion()
    {
        questRegion.SetActive(false);
        printRegion.SetActive(false);
        inkRegion.SetActive(true);
        hammerRegion.SetActive(false);
        paperRegion.SetActive(false);
    }

    public void ShowHammerRegion()
    {
        questRegion.SetActive(false);
        printRegion.SetActive(false);
        inkRegion.SetActive(false);
        hammerRegion.SetActive(true);
        paperRegion.SetActive(false);
    }

    public void ShowPaperRegion()
    {
        questRegion.SetActive(false);
        printRegion.SetActive(false);
        inkRegion.SetActive(false);
        hammerRegion.SetActive(false);
        paperRegion.SetActive(true);
    }

    public void HideAllRegions()
    {
        questRegion.SetActive(false);
        printRegion.SetActive(false);
        inkRegion.SetActive(false);
        hammerRegion.SetActive(false);
        paperRegion.SetActive(false);
    }
}

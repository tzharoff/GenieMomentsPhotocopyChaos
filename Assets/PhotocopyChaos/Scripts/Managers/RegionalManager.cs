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
    [SerializeField] private QuestRegion questRegion;
    [SerializeField] private PrintRegion printRegion;
    [SerializeField] private InkRegion inkRegion;
    [SerializeField] private HammerRegion hammerRegion;
    [SerializeField] private PaperRegion paperRegion;



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
        questRegion.gameObject.SetActive(true);
        printRegion.gameObject.SetActive(false);
        inkRegion.gameObject.SetActive(false);
        hammerRegion.gameObject.SetActive(false);
        paperRegion.gameObject.SetActive(false);
    }

    public void ShowPrintRegion()
    {
        questRegion.gameObject.SetActive(false);
        printRegion.gameObject.SetActive(true);
        inkRegion.gameObject.SetActive(false);
        hammerRegion.gameObject.SetActive(false);
        paperRegion.gameObject.SetActive(false);
    }

    public void ShowInkRegion()
    {
        questRegion.gameObject.SetActive(false);
        printRegion.gameObject.SetActive(false);
        inkRegion.gameObject.SetActive(true);
        hammerRegion.gameObject.SetActive(false);
        paperRegion.gameObject.SetActive(false);
    }

    public void ShowHammerRegion()
    {
        questRegion.gameObject.SetActive(false);
        printRegion.gameObject.SetActive(false);
        inkRegion.gameObject.SetActive(false);
        hammerRegion.gameObject.SetActive(true);
        paperRegion.gameObject.SetActive(false);
    }

    public void ShowPaperRegion()
    {
        questRegion.gameObject.SetActive(false);
        printRegion.gameObject.SetActive(false);
        inkRegion.gameObject.SetActive(false);
        hammerRegion.gameObject.SetActive(false);
        paperRegion.gameObject.SetActive(true);
    }

    private void HideAllRegions()
    {
        questRegion.gameObject.SetActive(false);
        printRegion.gameObject.SetActive(false);
        inkRegion.gameObject.SetActive(false);
        hammerRegion.gameObject.SetActive(false);
        paperRegion.gameObject.SetActive(false);
    }
}

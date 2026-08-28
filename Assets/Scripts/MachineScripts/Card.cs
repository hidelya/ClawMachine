using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStatsScript;
    [SerializeField] private HaloManager haloScript;
    [SerializeField] private GameObject card;
    //[SerializeField] private List<GameObject> listObject = new List<GameObject>();
    [SerializeField] private List <GameObject> listCommunObjects = new List<GameObject>();
    [SerializeField] private List <GameObject> listRareObjects = new List<GameObject>();
    [SerializeField] private List <GameObject> listLegendObjects = new List<GameObject>();

    public bool cardIsActived = true;

    [SerializeField] private Vector3 localisationObject;
    private GameObject objectDrawn;

    public int tauxCommun =100;
    public int tauxRare=20;
    public int tauxLegend=5;
    public int nbrListCommun { get; set; }
    public int nbrListRare { get; set; }
    public int nbrListLegend { get; set; }


    public void SpawnCard()
    {
        Debug.Log("slt");
        card.SetActive(true);
        RandomObject();
        cardIsActived=true;
        
    }

    public void RandomObject()
    {
        RaretyObject();
        int rarety = Random.Range(0, 100);
        if (rarety < tauxLegend)
        {
            nbrListLegend = Random.Range(0, listLegendObjects.Count);
            objectDrawn = Instantiate(listLegendObjects[nbrListLegend]);

            objectDrawn.transform.position = localisationObject;
            nbrListCommun = 999;
            nbrListRare = 999;
        }
        
        else if (rarety < tauxRare)
        {
            nbrListRare = Random.Range(0, listRareObjects.Count);
            objectDrawn = Instantiate(listRareObjects[nbrListRare]);
            objectDrawn.transform.position = localisationObject;
            nbrListCommun = 999;
            nbrListLegend = 999;
        }
        else if (rarety < tauxCommun)
        {
            nbrListCommun = Random.Range(0, listCommunObjects.Count);
            objectDrawn = Instantiate(listCommunObjects[nbrListCommun]);
            objectDrawn.transform.position = localisationObject;
            nbrListLegend = 999;
            nbrListRare = 999;
        }


        //    if (listObject.Count > 0)
        //{
        //    nbrList = Random.Range(0, listObject.Count);
        //    objectDrawn = Instantiate(listObject[nbrList]);
        //    objectDrawn.transform.position = localisationObject;


        //}

    }

    public void RaretyObject()
    {
        
        switch (playerStatsScript.lvlLuck)
        {
            case 1:
                tauxCommun = 100;
                tauxRare = 20;
                tauxLegend = 5;
                break;
            case 2:
                tauxCommun = 100;
                tauxRare = 40;
                tauxLegend = 10;
                break;
            case 3:
                tauxCommun = 100;
                tauxRare = 60;
                tauxLegend = 40;
                break;
            case 4:
                tauxCommun = 100;
                tauxRare = 80;
                tauxLegend = 60;
                break;
            case 5:
                tauxCommun = 100;
                tauxRare = 90;
                tauxLegend = 80;
                break;
        }
        
    }
  



    public void PriceObject()
    {
        if (objectDrawn)
        {
             
            switch (nbrListCommun)
            {
                case 0:
                    playerStatsScript.AddCoins(10);
                    break;
                case 1:
                    playerStatsScript.AddCoins(15);
                    break;
                case 2:
                    playerStatsScript.AddCoins(18);
                    break;
                case 3:
                    playerStatsScript.AddCoins(12);
                    break;
                default:
                    Debug.Log("N'est pas dans la liste des objets"); 
                    break;
            }
            switch (nbrListRare)
            {
                case 0:
                    playerStatsScript.AddCoins(50);
                    break;
                case 1:
                    playerStatsScript.AddCoins(70);
                    break;
                case 2:
                    playerStatsScript.AddCoins(65);
                    break;
                case 3:
                    playerStatsScript.AddCoins(55);
                    break;
                default:
                    Debug.Log("N'est pas dans la liste des objets"); 
                    break;
            }
            switch (nbrListLegend)
            {
                case 0:
                    playerStatsScript.AddCoins(200);
                    break;
                case 1:
                    playerStatsScript.AddCoins(150);
                    break;
                case 2:
                    playerStatsScript.AddCoins(120);
                    break;
                case 3:
                    playerStatsScript.AddCoins(140);
                    break;
                default:
                    Debug.Log("N'est pas dans la liste des objets"); 
                    break;
            }
        }

        
    }

    public void DisableCard()
    {
        Destroy(objectDrawn);
        card.SetActive(false);
        cardIsActived = false;
        
    }


 




}

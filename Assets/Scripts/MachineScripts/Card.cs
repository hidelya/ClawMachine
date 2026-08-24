using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStatsScript;
    [SerializeField] private GameObject card;
    [SerializeField] private List<GameObject> listObject = new List<GameObject>();
    [SerializeField] private Vector3 localisationObject;
    private GameObject objectDrawn;
    public int nbrList { get; set; }

    public void SpawnCard()
    {
        Debug.Log("slt");
        card.SetActive(true);
        RandomObject();
    }

    public void RandomObject()
    {
        
        if (listObject.Count > 0)
        {
            nbrList = Random.Range(0, listObject.Count);
            objectDrawn = Instantiate(listObject[nbrList]);
             
            objectDrawn.transform.position = localisationObject;
            
        }

    }

    public GameObject ObjectDrawned()
    {
        return objectDrawn;
    }

    public void PriceObject()
    {
        if (objectDrawn)
        {
             
            switch (nbrList)
            {
                case 0:
                    playerStatsScript.AddCoins(10);
                    break;
                case 1:
                    playerStatsScript.AddCoins(15);
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
    }

    


}

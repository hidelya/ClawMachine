using UnityEngine;

public class BloquedObjects : MonoBehaviour
{
    [SerializeField] Card cardScript;

    [SerializeField] GameObject blackCatBloqued;
    [SerializeField] GameObject capybaraClassicBloqued;
    [SerializeField] GameObject capybaraOrangeBloqued;
    [SerializeField] GameObject capybaraGoldenBloqued;
    [SerializeField] GameObject racoonClassicBloqued;
    [SerializeField] GameObject racoonBananaBloqued;


    public void DebloquedObject()
    {
        int nbrCommun = cardScript.nbrListCommun;
        int nbrRare = cardScript.nbrListRare;
        int nbrLegend = cardScript.nbrListLegend;

        switch (nbrCommun)
        {
            case 0:
                blackCatBloqued.SetActive(false);
                break;
            case 1:
                capybaraClassicBloqued.SetActive(false);
                break;
            case 2:
                racoonClassicBloqued.SetActive(false); break;
                
        }
        switch (nbrRare)
        {
            case 0:
                capybaraOrangeBloqued.SetActive(false);
                break;
            case 1:
                racoonBananaBloqued.SetActive (false);
                break;
            

        }
        switch (nbrLegend)
        {
            case 0:
                capybaraGoldenBloqued.SetActive(false);
                break;


        }
    }
}

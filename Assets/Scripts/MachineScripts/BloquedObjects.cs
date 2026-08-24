using UnityEngine;

public class BloquedObjects : MonoBehaviour
{
    [SerializeField] Card cardScript;

    [SerializeField] GameObject blackCatBloqued;
    public void DebloquedObject()
    {
        int nbr = cardScript.nbrList;

        switch (nbr)
        {
            case 0:
                blackCatBloqued.SetActive(false);
                break;
        }
    }
}

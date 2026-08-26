using UnityEngine;

public class ObjectRarety : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStatsScript;
    
    public void RaretyObject()
    {
        float pourcentRarety = 0.95f;
        switch (playerStatsScript.lvlLuck)
        {
            case 1:
                pourcentRarety = 0.95f;
                break;
            case 2:
                pourcentRarety = 0.80f;
                break;
            case 3:
                pourcentRarety = 0.50f;
                break;
            case 4:
                pourcentRarety = 0.30f;
                break;
            case 5:
                pourcentRarety = 0.5f;
                break;
        }

        

        
        

    }

    
}


using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject buttonCoin;
    [SerializeField] private int playerCoins = 10; 
    public int lvlLuck { get; set; } = 1;
    private int luckPrice { get; set; } = 50;
    private int lvlSpeed { get; set; } = 1;
    private int speedPrice { get; set; } = 200;
     

    [SerializeField] MovementPince movementPinceScript;
    [SerializeField] StretchingPince stretchingPinceScript; 

    
    

    [SerializeField] private TextMeshProUGUI coinText;
    
    [SerializeField] private TextMeshProUGUI textLuck;

    [SerializeField] private TextMeshProUGUI textSpeed;
    [SerializeField] private TextMeshProUGUI priceSpeedText;
    [SerializeField] private TextMeshProUGUI priceLuckText;

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        coinText.text = playerCoins.ToString() + " Coins";
    }
    public void AddCoins(int amount, int multiplicator)
    {
        playerCoins += amount * multiplicator;
        coinText.text = playerCoins.ToString() + " Coins";
    }

    public void RemoveCoins(int amount)
    {
        if (playerCoins >= amount) 
        { 
            playerCoins = playerCoins - amount;
            Debug.Log("Removed " + amount + " coins. Remaining coins: " + playerCoins);
            coinText.text = playerCoins.ToString() + " Coins";

        }
        else
        {
            Debug.Log("Not enough coins to remove.");
        }
    }

    public void AddLuck()
    {
        if (playerCoins >= luckPrice)
        {

            switch (lvlLuck) 
            {
                case 1:
                    lvlLuck += 1;
                    RemoveCoins(luckPrice);
                    luckPrice *= 2;
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    priceLuckText.text = luckPrice.ToString() + "$" ;
                    
                    break;

                case 2:
                    lvlLuck += 1;
                    RemoveCoins(luckPrice);
                    luckPrice *= 3;
                    
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    priceLuckText.text = luckPrice.ToString() + "$";
                    
                    break;
                case 3:
                    lvlLuck += 1;
                    RemoveCoins(luckPrice);
                    luckPrice *= 4;
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    priceLuckText.text = luckPrice.ToString() + "$";
                    
                    break;
                case 4:
                    lvlLuck += 1;
                    RemoveCoins(luckPrice);
                    luckPrice *= 4;
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    priceLuckText.text = luckPrice.ToString() + "$";
                    
                    break;

                default:
                    Debug.Log("Aucun niveau trouvé");
                    break;
            }

        }
    }

    public void SpeedLvl()
    {
        if (playerCoins >= speedPrice)
        {

            switch (lvlSpeed)
            {
                case 1:
                    lvlSpeed += 1;
                    RemoveCoins(speedPrice);
                    speedPrice *= 3;
                    movementPinceScript.speed *= 1.5f;
                    stretchingPinceScript.descenteSpeed *= 1.5f;
                    
                    textSpeed.text = "Speed level " + lvlSpeed.ToString();
                    priceSpeedText.text = speedPrice.ToString() + "$";
                    break;

                case 2:
                    lvlSpeed += 1;
                    RemoveCoins(speedPrice);
                    speedPrice *= 3;
                    movementPinceScript.speed *= 1.5f;
                    stretchingPinceScript.descenteSpeed *= 1.5f;
                    
                    textSpeed.text = "Speed level " + lvlSpeed.ToString();
                    priceSpeedText.text = speedPrice.ToString() + "$";
                    break;

                case 3:
                    lvlSpeed += 1;
                    RemoveCoins(speedPrice);
                    speedPrice *= 4;
                    movementPinceScript.speed *= 1.5f;
                    stretchingPinceScript.descenteSpeed *= 1.5f;
                    
                    textSpeed.text = "Speed level " + lvlSpeed.ToString();
                    priceSpeedText.text = speedPrice.ToString() + "$";
                    break;

                case 4:
                    lvlSpeed += 1;
                    RemoveCoins(speedPrice);
                    speedPrice *= 5;
                    movementPinceScript.speed *= 1.5f;
                    stretchingPinceScript.descenteSpeed *= 1.5f;
                    
                    textSpeed.text = "Speed level " + lvlSpeed.ToString();
                    priceSpeedText.text = speedPrice.ToString() + "$";
                    break;

                case 5:
                    lvlSpeed += 1;
                    RemoveCoins(speedPrice);
                    speedPrice *= 6;
                    movementPinceScript.speed *= 1.5f;
                    stretchingPinceScript.descenteSpeed *= 1.5f;
                    
                    textSpeed.text = "Speed level " + lvlSpeed.ToString();
                    priceSpeedText.text = speedPrice.ToString() + "$";
                    break;

                default:
                    Debug.Log("Aucun niveau trouvé");
                    break;
            }

        }
        
    }
}

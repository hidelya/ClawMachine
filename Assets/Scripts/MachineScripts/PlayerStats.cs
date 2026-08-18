using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject buttonCoin;
    private int playerCoins { get; set; } = 500; 
    private int lvlLuck { get; set; } = 1;

    private int lvlPrice { get; set; } = 50;

    [SerializeField] private TextMeshProUGUI coinText;
    
    [SerializeField] TextMeshProUGUI textLuck;

    public void AddCoins(int amount)
    {
        playerCoins += amount;
        coinText.text = playerCoins.ToString() + " Coins";
    }

    public void RemoveCoins(int amount)
    {
        if (playerCoins >= amount) 
        { 
            playerCoins -= amount;
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
        if (playerCoins >= lvlPrice)
        {

            switch (lvlLuck) 
            {
                case 1:
                    lvlLuck += 1;
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    RemoveCoins(lvlPrice);
                    break;

                case 2:
                    lvlLuck += 1;
                    lvlPrice = 200;
                    textLuck.text = "Luck level " + lvlLuck.ToString();
                    RemoveCoins(lvlPrice);
                    break;

                default:
                    Debug.Log("Aucun niveau trouvé");
                    break;
            }

        }
    }
}

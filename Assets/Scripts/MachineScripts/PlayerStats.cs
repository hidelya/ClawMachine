using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject buttonCoin;
    [SerializeField] private int playerCoins = 100;

    [SerializeField] private TextMeshProUGUI coinText;
   
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

}

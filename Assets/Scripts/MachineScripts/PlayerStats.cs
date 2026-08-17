using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private GameObject buttonCoin;
    [SerializeField] private int playerCoins = 100;

   
    public void AddCoins(int amount)
    {
        playerCoins += amount;
    }

    public void RemoveCoins(int amount)
    {
        if (playerCoins >= amount) 
        { 
            playerCoins -= amount;
            Debug.Log("Removed " + amount + " coins. Remaining coins: " + playerCoins);
        }
        else
        {
            Debug.Log("Not enough coins to remove.");
        }
    }

}

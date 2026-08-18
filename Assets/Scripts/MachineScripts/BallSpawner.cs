using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    private List<GameObject> spawnedBalls = new List<GameObject>();
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector3 position;
    [SerializeField] private PlayerStats playerStatsScript;

    public void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        spawnedBalls.Add(newBall);
        RandomColor(newBall);
    }

    public void SpawnBall(Vector3 spawnPosition)
    {
        GameObject newBall = Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        spawnedBalls.Add(newBall);
        RandomColor(newBall);
    }

    public void RandomColor(GameObject ball)
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
        Color colorRarety = Random.value < pourcentRarety ? Color.blue : Color.red;
        ball.GetComponent<Renderer>().material.color = colorRarety;

    }

   

}

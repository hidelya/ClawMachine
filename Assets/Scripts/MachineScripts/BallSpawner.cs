using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour
{
    private List<GameObject> spawnedBalls = new List<GameObject>();
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector3 position;

    public void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, position, Quaternion.identity);
        spawnedBalls.Add(newBall);
    }
}

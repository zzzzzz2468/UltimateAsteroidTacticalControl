using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();

    public List<GameObject> Asteroids = new List<GameObject>();

    public GameObject asteroidHolder;
    public GameObject player;

    public int MaxAsteroids = 3;

    void Start()
    {
        for(int i = asteroidHolder.transform.childCount; i < MaxAsteroids; i++)
            CreateAsteroid();
    }

    void CreateAsteroid()
    {
        GameObject spawnLocation = spawnPoints[Random.Range(0,spawnPoints.Count - 1)];
        GameObject asteroid = Asteroids[Random.Range(0, Asteroids.Count - 1)];

        Instantiate(asteroid, spawnLocation.transform.position, Quaternion.LookRotation(player.transform.position), asteroidHolder.transform);
    }
}
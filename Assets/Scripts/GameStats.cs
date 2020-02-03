using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public GameObject asteroidMan;

    public int asteroidSpeed = 5;
    public int maxAsteroids = 3;
    public float spawnTime = 2.0f;
    public float bulletSpeed = 2.0f;

    void Start()
    {
        asteroidMan.GetComponent<AsteroidManager>().gameStatsVariable(maxAsteroids, spawnTime);
    }
}

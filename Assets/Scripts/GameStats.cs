using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    //Declares variables
    [Header("GameObject")]
    public GameObject asteroidMan;

    [Header("Asteroid")]
    public int asteroidSpeed = 5;
    public int maxAsteroids = 3;
    public float spawnTime = 2.0f;

    void Start()
    {
        //sends stats to the asteroidManager
        asteroidMan.GetComponent<AsteroidManager>().gameStatsVariable(maxAsteroids, spawnTime);
    }
}

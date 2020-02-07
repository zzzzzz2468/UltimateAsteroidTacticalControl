using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    //Gets the objects to spawn and where to spawn
    [Header("Lists")]
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> Asteroids = new List<GameObject>();

    //gets asteroidHolder, where asteroids spawn, and allows other scripts to access this script
    [Header("GameObjects")]
    public GameObject asteroidHolder;
    public static AsteroidManager asteroidManager;

    //Number of MaxAsteroid and timeInBetweenSpawn, changable in GameStats
    private int maxAsteroids = 3;
    private float timeInBetween = 2.0f;
    public float AstSpeed = 10.0f;

    //detects if the corotine is running
    private bool isRunning = false;

    private void Awake()
    {
        //destroys the gameobject if one already exists
        if (asteroidManager == null)
        {
            asteroidManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //spawns asteroids if there are less than the maxAsteroids
        if (!isRunning && asteroidHolder.transform.childCount < maxAsteroids)
        {
            isRunning = true;
            StartCoroutine(SpawnAsteroids());
        }
    }

    //Detects how many asteroids need to be created and then calls the void
    IEnumerator SpawnAsteroids()
    {
        for (int i = asteroidHolder.transform.childCount; i < maxAsteroids; i++)
        {
            yield return new WaitForSeconds(timeInBetween);
            CreateAsteroid();
        }
        isRunning = false;
    }

    //gets the stats from game stats
    public void gameStatsVariable(int totAst, float spnTime)
    {
        maxAsteroids = totAst;
        timeInBetween = spnTime;
    }

    //actually creates the asteroid
    void CreateAsteroid()
    {
        //random asteroid and random spawn
        GameObject spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject asteroid = Asteroids[Random.Range(0, Asteroids.Count)];

        //detects if player is alive or not, and stops spawning if they are dead
        if (!GameManager.gamemanager.player.activeInHierarchy)
            print("The Player is Dead");
        else
        {
            var enemy = Instantiate(asteroid, spawnLocation.transform.position, Quaternion.identity, asteroidHolder.transform);
            enemy.GetComponent<AsteroidController>().speed = AstSpeed;
        }
    }
}

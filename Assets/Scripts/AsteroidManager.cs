using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();

    public List<GameObject> Asteroids = new List<GameObject>();

    public GameObject asteroidHolder;

    private int maxAsteroids = 3;

    private float timeInBetween = 2.0f;

    public static AsteroidManager asteroidManager;

    private void Awake()
    {

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

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        for (int i = asteroidHolder.transform.childCount; i < maxAsteroids; i++)
        {
            yield return new WaitForSeconds(timeInBetween);
            CreateAsteroid();
            print(i);
        }
    }

    public void gameStatsVariable(int totAst, float spnTime)
    {
        maxAsteroids = totAst;
        timeInBetween = spnTime;
    }

    void CreateAsteroid()
    {
        GameObject spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
        GameObject asteroid = Asteroids[Random.Range(0, Asteroids.Count - 1)];

        //float angle = Mathf.Atan2((player.transform.position - spawnLocation.transform.position).y, (player.transform.position - spawnLocation.transform.position).x) * Mathf.Rad2Deg;
        Instantiate(asteroid, spawnLocation.transform.position, Quaternion.identity, asteroidHolder.transform);
    }
}

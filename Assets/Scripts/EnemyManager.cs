using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Lists")]
    public List<GameObject> spawnPoints = new List<GameObject>();
    public List<GameObject> EnemyShips = new List<GameObject>();

    [Header("GameObjects")]
    public GameObject enemyHolder;
    public static EnemyManager enemyManager;

    public int maxEnemies = 1;
    public float timeInBetween = 10.0f;

    private bool isRunning = false;

    void Start()
    {
        //destroys the gameobject if one already exists
        if (enemyManager == null)
        {
            enemyManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (!isRunning && enemyHolder.transform.childCount < maxEnemies)
        {
            isRunning = true;
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = enemyHolder.transform.childCount; i < maxEnemies; i++)
        {
            yield return new WaitForSeconds(timeInBetween);
            CreateEnemy();
        }
        isRunning = false;
    }

    void CreateEnemy()
    {
        //random asteroid and random spawn
        GameObject spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject asteroid = EnemyShips[Random.Range(0, EnemyShips.Count)];

        //detects if player is alive or not, and stops spawning if they are dead
        if (!GameManager.gamemanager.player.activeInHierarchy)
            print("The Player is Dead");
        else
            Instantiate(asteroid, spawnLocation.transform.position, Quaternion.identity, enemyHolder.transform);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //gets the player
    public GameObject player;

    //declares lives and appears in inspector
    public int lives = 3;

    public List<GameObject> spawnPoints = new List<GameObject>();

    public List<GameObject> Asteroids = new List<GameObject>();

    public GameObject asteroidHolder;

    private int maxAsteroids = 3;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        for (int i = asteroidHolder.transform.childCount; i < maxAsteroids; i++)
        {
            yield return new WaitForSeconds(2f);
            CreateAsteroid();
            print(i);
        }
    }

    public void totalAsteroids(int temp)
    {
        maxAsteroids = temp;
    }

    void Update()
    {
        //detects if the player goes out of bounds
        if (player.transform.position.x >= 11 || player.transform.position.x <= -11 || player.transform.position.y >= 5.2 || player.transform.position.y <= -5.2)
        {
            //stops player, moves to middle and deactivates the player
            player.GetComponent<PlayerMovement>().ChangeMove(false);
            player.transform.position = Vector2.zero;
            player.SetActive(false);

            if (lives >= 1)
                Invoke("Death", 3);
            else
                Application.Quit();
        }
    }

    //evertime player dies this function is called
    void Death()
    {
        //sets rotation to zero, allows player to move, reactivates player and subtracts a life.
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponent<PlayerMovement>().ChangeMove(true);
        player.SetActive(true);
        lives -= 1;
        print(lives);
    }

    void CreateAsteroid()
    {
        GameObject spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Count - 1)];
        GameObject asteroid = Asteroids[Random.Range(0, Asteroids.Count - 1)];

        Instantiate(asteroid, spawnLocation.transform.position, Quaternion.LookRotation(player.transform.position), asteroidHolder.transform);
    }
}
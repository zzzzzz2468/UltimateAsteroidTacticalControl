using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public int asteroidSpeed = 5;
    public int maxAsteroids = 3;

    void Start()
    {
        this.GetComponent<GameManager>().totalAsteroids(maxAsteroids);
    }
}

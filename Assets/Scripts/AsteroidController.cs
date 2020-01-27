using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public GameObject player;

    private Vector2 playerPos;
    private Vector2 asteroidPos;

    public float speed = 5.0f;

    void Start()
    {
        playerPos = player.transform.position;

        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void Update()
    {
        AsteroidMove();
    }

    void AsteroidMove()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, playerPos, step);
    }
}
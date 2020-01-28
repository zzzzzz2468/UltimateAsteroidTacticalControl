using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public Vector3 playerPos;
    Vector3 newPos;

    public float speed = 5.0f;

    void Start()
    {
        playerPos = GameManager.gamemanager.player.transform.position;

        newPos = playerPos - transform.position;

        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void Update()
    {
        AsteroidMove();

        if (this.transform.position.x >= 15 || this.transform.position.x <= -15 || this.transform.position.y >= 10 || this.transform.position.y <= -10)
            AsteroidDestroy();
    }

    void AsteroidMove()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, transform.position + newPos.normalized, step);
    }

    void AsteroidDestroy()
    {
        Destroy(gameObject);
    }
}
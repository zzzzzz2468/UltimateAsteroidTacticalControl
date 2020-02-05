using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //sets the player position and where the enemy is goiing
    public Vector3 playerPos;
    Vector3 newPos;

    //speed of the enemy
    public float speed = 3.0f;

    void Start()
    {
        //sets the enemy to be above the background
        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void Update()
    {
        //sets playerpos through gamemanager
        playerPos = GameManager.gamemanager.player.transform.position;

        //sets where the enemy is going
        newPos = playerPos - transform.position;

        //moves the enemy
        EnemyMove();

        //destroys the enemy if player dies
        if (!GameManager.gamemanager.player.activeInHierarchy)
            EnemyDestroy();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("AsteroidExit"))
        {
            Destroy(gameObject);
        }
    }

    //moves the enemy
    void EnemyMove()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, transform.position + newPos.normalized, step);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, playerPos);
    }

    //destroys the enemy
    void EnemyDestroy()
    {
        Destroy(gameObject);
    }
}

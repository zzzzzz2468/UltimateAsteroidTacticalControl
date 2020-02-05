using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    //sets the player position and where the asteroid is goiing
    public Vector3 playerPos;
    Vector3 newPos;

    //speed of the asteroid
    public float speed = 5.0f;

    void Start()
    {
        //sets playerpos through gamemanager
        playerPos = GameManager.gamemanager.player.transform.position;

        //sets where the asteroid is going
        newPos = playerPos - transform.position;

        //sets the asteroid to be above the background
        this.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void Update()
    {
        //moves the asteroid
        AsteroidMove();

        //destroys the asteroid if player dies
        if (!GameManager.gamemanager.player.activeInHierarchy)
            AsteroidDestroy();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("AsteroidExit"))
        {
            Destroy(gameObject);
        }
    }

    //moves the asteroid
    void AsteroidMove()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector2.MoveTowards(transform.position, transform.position + newPos.normalized, step);
    }

    //destroys the asteroid
    void AsteroidDestroy()
    {
        Destroy(gameObject);
    }
}
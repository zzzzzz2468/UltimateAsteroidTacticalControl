using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Declares bullet speed and bullet life span, changed in player movement
    public float bulletSpeed = 100.0f;
    public float bulletLifeSpan = 5.0f;


    void Update()
    {
        //gives the bullet speed
        GetComponent<Rigidbody2D>().velocity = transform.up * bulletSpeed;
        //starts to destroy the bullet
        StartCoroutine(Destroy());
    }

    //destroys the bullet after bulletLifeSpan
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(bulletLifeSpan);
        Destroy(gameObject);
    }

    //Detects if the bullet collides with layer 9(enemy) and destroys it and itself
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

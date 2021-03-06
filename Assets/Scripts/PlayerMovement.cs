﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //sets the rigidbody of the player
    public Rigidbody2D player;

    //speed to have the player move display in editor
    public float rotateSpeed = 20.0f;
    public float speed = 20.0f;

    //Bullet variables
    public float bulletLife = 0.5f;
    public float bulletSpeed = 10.0f;
    private float fireElapsedTime = 0;
    public float fireDelay = 0.2f;

    //creates inputs variables
    private float forwardInput;
    private float rotateInput;

    //getting the different thrusters
    public GameObject FireCenter;
    public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject FireBack;

    //getting the shield for powerup
    public GameObject Shield;
    
    //allows the player to move or not
    private bool canMove = true;

    public GameObject bulletHolder;
    public GameObject bullet;

    private bool invinceable = false;

    void Awake()
    {
        //sets the player to player
        GameManager.gamemanager.player = gameObject;

        //gets ths ridgidbody
        player.GetComponent<Rigidbody2D>();
    }

    //allows the coder to change canMove from other scripts
    public void ChangeMove(bool canMoveThing)
    {
        canMove = canMoveThing;
    }

    void Update()
    {
        //getting the vertical axis
        forwardInput = Input.GetAxis("Vertical");

        //getting the horizontal axis
        rotateInput = Input.GetAxis("Horizontal");

        //calling the movement function
        if(canMove)
            Movement();

        //the different lights behind the ship
        BackLights();

        //declaring power ups and what they do
        PowerUps();

        //allowing the player to attack
        fireElapsedTime += Time.deltaTime;
        Attack();
    }

    void Movement()
    {
        //adds the movement to allow the player to move forward and back
        player.AddForce(transform.up * forwardInput * speed * Time.deltaTime);

        //adds the players abilty to rotate left and right
        player.MoveRotation(player.rotation - rotateInput * rotateSpeed * Time.deltaTime);
    }

    void BackLights()
    {
        //FireCenter active
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow))
            FireCenter.SetActive(true);
        //FireCenter deactive
        else
            FireCenter.SetActive(false);

        //FireLeft active
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            FireLeft.SetActive(true);
        //FireLeft deactive
        else
            FireLeft.SetActive(false);

        //FireRight active
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            FireRight.SetActive(true);
        //FireRight deactive
        else
            FireRight.SetActive(false);

        //FireBack active
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            FireBack.SetActive(true);
        //FireBack deactive
        else
            FireBack.SetActive(false);
    }

    void Deactivate()
    {
        FireBack.SetActive(false);
        FireRight.SetActive(false);
        FireLeft.SetActive(false);
        FireCenter.SetActive(false);
        Shield.SetActive(false);
    }

    //the player can use powerups
    void PowerUps()
    {
        if (Input.GetMouseButton(1))
        {
            invinceable = true;
            Shield.SetActive(true);
        }
        else
        {
            invinceable = false;
            Shield.SetActive(false);
        }
    }

    //players attacking
    void Attack()
    {
        //checks if enough time inbetween shots
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0)) && fireElapsedTime >= fireDelay)
        {
            //creates bullet, sets variables in bullet script and resets delay
            var shot = Instantiate(bullet, player.transform.position, transform.rotation, bulletHolder.transform);
            shot.GetComponent<Bullet>().bulletLifeSpan = bulletLife;
            shot.GetComponent<Bullet>().bulletSpeed = bulletSpeed;
            fireElapsedTime = 0;
        }

    }

    //detects if an asteroid hits the player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 && !invinceable)
        {
            Deactivate();
            GameManager.gamemanager.GotHit();
        }
        else if(collision.gameObject.layer == 9 && invinceable)
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerExit"))
        {
            Deactivate();
            GameManager.gamemanager.GotHit();
        }

    }
}
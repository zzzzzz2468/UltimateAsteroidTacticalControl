using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //sets the rigidbody of the player
    public Rigidbody2D player;

    //speed to have the player move display in editor
    public float rotateSpeed = 2.0f;
    public float speed = 2.0f;

    //creates inputs variables
    private float forwardInput;
    private float rotateInput;

    void Start()
    {
        //gets ths ridgidbody
        player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //getting the vertical axis
        forwardInput = Input.GetAxis("Vertical");

        //getting the horizontal axis
        rotateInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        //calls the movement in fixedupdate to avoid unequal movement because I do not use time.deltatime
        Movement();
    }

    void Movement()
    {
        //adds the movement to allow the player to move forward and back
        player.AddForce(transform.up * forwardInput * speed);

        //adds the players abilty to rotate left and right
        player.MoveRotation(player.rotation - rotateInput * rotateSpeed);
    }
}

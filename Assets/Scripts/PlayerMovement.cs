using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //sets the rigidbody of the player
    public Rigidbody2D player;

    //speed to have the player move display in editor
    public float rotateSpeed = 20.0f;
    public float speed = 20.0f;

    //creates inputs variables
    private float forwardInput;
    private float rotateInput;

    public GameObject FireCenter;
    public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject FireBack;

    public GameObject Shield;
    
    private bool canMove = true;

    void Start()
    {
        //gets ths ridgidbody
        player.GetComponent<Rigidbody2D>();
    }

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

        BackLights();

        PowerUps();

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow))
            FireCenter.SetActive(true);
        else
            FireCenter.SetActive(false);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            FireLeft.SetActive(true);
        else
            FireLeft.SetActive(false);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            FireRight.SetActive(true);
        else
            FireRight.SetActive(false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            FireBack.SetActive(true);
        else
            FireBack.SetActive(false);
    }

    void PowerUps()
    {
        if (Input.GetMouseButton(1))
            Shield.SetActive(true);
        else
            Shield.SetActive(false);
    }

    void Attack()
    {
        //if(Input.GetKeyDown(KeyCode.Space))

    }
}

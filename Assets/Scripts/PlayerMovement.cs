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

    //getting the different thrusters
    public GameObject FireCenter;
    public GameObject FireLeft;
    public GameObject FireRight;
    public GameObject FireBack;

    //getting the shield for powerup
    public GameObject Shield;
    
    //allows the player to move or not
    private bool canMove = true;

    void Start()
    {
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
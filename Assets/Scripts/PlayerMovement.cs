using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D player;

    public float rotateSpeed = 2.0f;
    public float speed = 2.0f;

    private float forwardInput;
    private float rotateInput;

    void Start()
    {
        player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");

    }

    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        player.AddForce(transform.up * forwardInput * speed);

        player.MoveRotation(player.rotation - rotateInput * rotateSpeed);
    }
}

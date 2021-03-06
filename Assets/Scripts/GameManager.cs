﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gamemanager;

    //gets the player
    public GameObject player;

    //declares lives and appears in inspector
    public int lives = 3;

    public List<GameObject> liveUI = new List<GameObject>();

    private void Awake()
    {

        if (gamemanager == null)
        {
            gamemanager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GotHit()
    {
        Death();
    }

    //evertime player dies this function is called
    public void Respawn()
    {
        //sets rotation to zero, allows player to move, reactivates player and subtracts a life.
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponent<PlayerMovement>().ChangeMove(true);
        player.SetActive(true);
        lives -= 1;
        print(lives);
    }

    void Death()
    {
        //stops player, moves to middle and deactivates the player
        player.GetComponent<PlayerMovement>().ChangeMove(false);
        player.transform.position = Vector2.zero;
        player.SetActive(false);
        liveUI[lives - 1].SetActive(false);

        if (lives > 1)
            Invoke("Respawn", 3);
        else
            Application.Quit();
    }
}
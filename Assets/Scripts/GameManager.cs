using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private int lives = 3;

    void Start()
    {

    }

    void Update()
    {
        if (player.transform.position.x >= 11 || player.transform.position.x <= -11 || player.transform.position.y >= 5.2 || player.transform.position.y <= -5.2)
        {
            player.GetComponent<PlayerMovement>().ChangeMove(false);
            player.transform.position = Vector2.zero;
            player.SetActive(false);

            if (lives >= 1)
                Invoke("Death", 3);
            else
                Application.Quit();
        }
    }

    void Death()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, 0);
        player.GetComponent<PlayerMovement>().ChangeMove(true);
        player.SetActive(true);
        lives -= 1;
        print(lives);
    }
}

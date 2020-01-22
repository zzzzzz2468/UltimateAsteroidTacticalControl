using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player.GetComponent<PlayerMovement>().ChangeMove(false);
    }

    void Update()
    {
        if (player.transform.position.x >= 11 || player.transform.position.x <= -11 || player.transform.position.y >= 5.2 || player.transform.position.y <= -5.2)
        {
            Death();
        }
    }

    void Death()
    {

    }
}

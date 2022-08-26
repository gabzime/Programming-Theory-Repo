using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Obstacle
{
    public override void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        showAsProbablyTarget = false;
        isTarget = false;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.GameLose();
            base.Suicide();
        }
    }
}

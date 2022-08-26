using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Obstacle
{
    public float speedIncrement;

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.speedChange(speedIncrement);
            base.Suicide();
        }
    }
}
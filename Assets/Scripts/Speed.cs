using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Speed : Obstacle
{
    public float speedIncrement;

    // POLYMORPHISM
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.speedChange(speedIncrement);
            base.Suicide();
        }
    }
}
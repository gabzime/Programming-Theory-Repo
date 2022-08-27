using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Expand : Obstacle
{
    public float scaleFactor;

    // POLYMORPHISM
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.scaleChange(scaleFactor);
            base.Suicide();
        }
    }
}

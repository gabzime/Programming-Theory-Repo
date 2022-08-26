using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : Obstacle
{
    public float scaleFactor;

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.scaleChange(scaleFactor);
            base.Suicide();
        }
    }
}

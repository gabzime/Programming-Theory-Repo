using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Info : Obstacle
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            base.Suicide();
            gameManager.GiveInfo();
        }
    }
}

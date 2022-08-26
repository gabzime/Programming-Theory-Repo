using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Info : Obstacle
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameManager.GiveInfo();
            base.Suicide();
        }
    }
}

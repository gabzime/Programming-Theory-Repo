using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private protected PlayerController player;
    public MeshRenderer Renderer;
    private Material material;
    public bool isTarget;
    public bool showAsProbablyTarget;
    public Color probablyColor;
    public Color notProbablyColor;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        Debug.Log("Start obstacle Class");
        material = Renderer.material;
        showAsProbablyTarget = true;
        setColor();
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        int rand = Random.Range(0, 10);
        if (rand == 0)
        {
            Color color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.5f, 1.0f));
            colorChange(color);
        }
        */

    }
    
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="Player")
        {
            Suicide();
        }
    }

    public virtual void Suicide()
    {
        Destroy(this.gameObject);
    }
    
    public void setColor()
    {
        if (showAsProbablyTarget)
        {
            material.color = probablyColor;
        } else
        {
            material.color = notProbablyColor;
        }       
    }
    
}
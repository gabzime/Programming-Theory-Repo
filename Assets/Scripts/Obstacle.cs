using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private protected PlayerController player;
    private protected GameManager gameManager;
    public MeshRenderer Renderer;
    private Material material;
    public bool isTarget;
    public bool showAsProbablyTarget;
    [SerializeField] Color probablyColor;
    [SerializeField] Color notProbablyColor;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        material = Renderer.material;
        showAsProbablyTarget = true;
        setColor();
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
        if (isTarget)
        {
            gameManager.GameWin();
        }
        Destroy(this.gameObject);
        gameManager.DepureProbablyObstacles();
    }

    public void retireProbability()
    {
        showAsProbablyTarget = false;
        setColor();
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
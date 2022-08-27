using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float m_Speed = 10f;
    private Vector3 direction;
    public float sensibility;
    private GameManager gameManager;
    public float Speed
    {
        get { return m_Speed; }
        set { if (value > 0) m_Speed = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        direction = Vector3.back;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > sensibility && Mathf.Abs(vertical) < sensibility)
        {
            direction = Vector3.right;
        }
        if (horizontal < -sensibility && Mathf.Abs(vertical) < sensibility)
        {
            direction = Vector3.left;
        }
        if (vertical > sensibility && Mathf.Abs(horizontal) < sensibility)
        {
            direction = Vector3.forward;
        }
        if (vertical < -sensibility && Mathf.Abs(horizontal) < sensibility)
        {
            direction = Vector3.back;
        }
        if (!gameManager.gameOver)
        {
            playerRb.AddForce(direction * Speed, ForceMode.Force);
        } else
        {
            if (!IsInStage())
            {
                gameManager.GameLose();
            }
        }

    }

    bool IsInStage()
    {
        return this.transform.position.y > 0;
    }



    public void speedChange(float speedChange)
    {
        Speed += speedChange;
    }

    public void scaleChange(float scaleChange)
    {
        transform.localScale *= scaleChange;
    }
}

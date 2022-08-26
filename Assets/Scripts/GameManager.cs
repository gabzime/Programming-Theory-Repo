using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public int obstaclesCount;
    public List<GameObject> obstacles;
    private List<GameObject> probablyTargets;
    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles();
    }

    public void GiveInfo()
    {
        Debug.Log("GiveInfo");
    }

    public void GameLose()
    {
        GameOver();
        Debug.Log("You lose.");
    }

    public void GameWin()
    {
        GameOver();
        Debug.Log("You win.");
    }

    void GameOver()
    {
        gameOver = true;
    }

    private Vector3 spawnPosition()
    {
        Vector3 position = new Vector3(Random.Range(-10f, 10f), 5f, Random.Range(-10f, 10f));
        while (position.x*position.x+position.y*position.y*position.y>100f)
        {
            position = new Vector3(Random.Range(-10f, 10f), 5f, Random.Range(-10f, 10f));
        }
        return position;
    }

    private GameObject spawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstacles.Count);
        return Instantiate(obstacles[obstacleIndex], spawnPosition(), obstacles[obstacleIndex].transform.rotation);
   }
    private void spawnObstacles()
    {
        for (int index = 0; index < 30; index++)
        {
            spawnObstacle();
        }

    }
}

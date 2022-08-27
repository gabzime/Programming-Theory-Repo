using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public int obstaclesCount;
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> probablyTargets;
    public int countGiveInfo;
    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles();
    }

    public void GiveInfo()
    {
        for (var index = 0; index < countGiveInfo; index++)
        {
            GameObject obstacle = probablyTargets[probablyTargets.Count - 1];
            probablyTargets.RemoveAt(probablyTargets.Count - 1);
            obstacle.GetComponent<Obstacle>().retireProbability();
        }
    }

    public void DepureProbablyObstacles()
    {
        for (var index = probablyTargets.Count - 1; index > -1; index--)
        {
            if (probablyTargets[index] == null)
                probablyTargets.RemoveAt(index);
        }
        // otra forma:  probablyTargets = probablyTargets.Where(function(item) { return item != null }).ToList();
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
        while (position.x*position.x+position.z*position.z>81f)
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
        bool targetAssigned = false;
        for (int index = 0; index < obstaclesCount; index++)
        {
            GameObject obstacle = spawnObstacle();
            if (obstacle.name!="Skull(Clone)")   
            {
                if (!targetAssigned)
                {
                    obstacle.GetComponent<Obstacle>().isTarget = true;
                    targetAssigned = true;
                } else
                {
                    probablyTargets.Add(obstacle);
                }

            }
        }
    }
}

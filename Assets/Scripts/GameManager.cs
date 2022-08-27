using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public int obstaclesCount;
    public List<GameObject> obstacles = new List<GameObject>();
    public List<GameObject> probablyTargets;
    public int countGiveInfo;
    public TextMeshProUGUI endMessage;
    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles();
    }

    public void GiveInfo()
    {
        for (var index = 0; index < countGiveInfo; index++)
        {
            if (probablyTargets.Count>0)
            {
                GameObject obstacle = probablyTargets[probablyTargets.Count - 1];
                probablyTargets.RemoveAt(probablyTargets.Count - 1);
                obstacle.GetComponent<Obstacle>().retireProbability();
            }
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
        // Only once endMessage can be assigned.
        if (!gameOver)
        {
            endMessage.text = "You lose";
        }
        GameOver();
    }

    public void GameWin()
    {
        if (!gameOver)
        {
            endMessage.text = "You win!";
        }
        GameOver();
    }

    void GameOver()
    {
        endMessage.gameObject.SetActive(true);
        gameOver = true;
    }

    // ABSTRACTION
    private Vector3 spawnPosition()
    {
        Vector3 position = new Vector3(Random.Range(-9f, 9f), 3f, Random.Range(-9f, 9f));
        while (position.x*position.x+position.z*position.z>64f)
        {
            position = new Vector3(Random.Range(-9f, 9f), 3f, Random.Range(-9f, 9f));
        }
        return position;
    }

    // ABSTRACTION
    private GameObject spawnObstacle()
    {
        int obstacleIndex = Random.Range(0, obstacles.Count);
        return Instantiate(obstacles[obstacleIndex], spawnPosition(), obstacles[obstacleIndex].transform.rotation);
    }

    private void spawnSkull()
    {
        Instantiate(obstacles[0], spawnPosition(), obstacles[0].transform.rotation);
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
        // At least spawn one Skull:
        spawnSkull();
    }
}

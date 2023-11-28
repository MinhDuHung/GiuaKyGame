using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject enermy;
    float spawnTime;
    public float rootSpawnTime;
    bool isGameOver;
    public float score;



    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0;
        score = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene("Main");
    }
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            if (isGameOver)
            {
                return;
            }
            SpawnObstacle();
            spawnTime = rootSpawnTime;
        }
    }

    public void SpawnObstacle()
    {
        
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-1f, 4f);
        Vector2 pos = new Vector2(randomX, randomY);
        if (enermy)
        {
            Instantiate(enermy, pos, Quaternion.identity);
        }

    }

    public void increaseScore()
    {
        score++;
    }
    public void setIsGameOver(bool val)
    {
        isGameOver = val;
    }
    public bool getIsGameOver()
    {
        return isGameOver;
    }
    public float getScore()
    {
        return score;
    }
}

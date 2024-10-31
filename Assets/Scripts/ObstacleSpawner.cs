using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;
    public float spawnRate;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnObstacle();
            timer = 0;
        }

    }
    void SpawnObstacle()
    {
        float lowestPointX = transform.position.x - 2;
        float highestPointX = transform.position.x + 1;

        float Xoffset = Random.Range(lowestPointX - 5, highestPointX);
        Instantiate(Obstacle, new Vector3(Xoffset, transform.position.y, 0), transform.rotation);
    }
}

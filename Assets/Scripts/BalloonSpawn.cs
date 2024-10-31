using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawn : MonoBehaviour
{
    public GameObject Balloon;
    public float spawnRate;
    public float timer;
    float heightoffset=5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBalloon();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer<spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnBalloon();
            timer = 0;
        }
        
    }
    void SpawnBalloon()
    {
        float lowestPointY = transform.position.y - heightoffset;
        float highestPointY = transform.position.y + heightoffset;
        float lowestPointX = transform.position.x - 2;
        float highestPointX = transform.position.x +1;

        float Yoffset = Random.Range(lowestPointY, highestPointY);
        float Xoffset = Random.Range(lowestPointX-5, highestPointX);
        Instantiate(Balloon, new Vector3(Xoffset, Yoffset,0), transform.rotation);
    }
}

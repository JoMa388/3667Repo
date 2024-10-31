using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        body.name = "Obstacle";
        body.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (body.transform.position.y >6)
        {
            Destroy(gameObject);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float speed;
    public float delay;
    public float repeatRate;
    public Score score;
    public Vector3 TargetSize = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        body = gameObject.GetComponent<Rigidbody2D>();
        body.name = "Balloon";
        body.velocity = new Vector2(0, speed);
        InvokeRepeating("ScaleUp", delay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (body.transform.position.y > 5.75)
        {
            body.velocity = new Vector2(0, -speed);


        }
        else if (body.transform.position.y < -5.4)
        {
            body.velocity = new Vector2(0, speed);
        }
        if(transform.localScale == TargetSize)
        {
            score.Reset();
            Destroy(gameObject);
      


        }
    }

    void ScaleUp()
    {
        transform.localScale += new Vector3(.1f, .1f, 0);
    }
}

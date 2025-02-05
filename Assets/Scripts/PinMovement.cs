using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinMovement : MonoBehaviour
{
    Rigidbody2D body;
    public float speed = 5;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        body = gameObject.GetComponent<Rigidbody2D>();
        body.name = "Pin";
    }   

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed, 0);

        if(body.transform.position.x>8.5)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Balloon")
        {

            audioManager.PlaySFX(audioManager.pop);
            score.IncrementScore();
            Destroy(collision.gameObject);
            Destroy(gameObject,.4f);
        }
        if (collision.gameObject.name == "Obstacle")
        {
            score.DecrementScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

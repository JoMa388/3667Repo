using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject pin;
    public float speed;
    public float timer;
    public float delay;
    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if(xInput >0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        if (xInput < 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        Vector2 direction = new Vector2(xInput,yInput).normalized;
        body.velocity = direction * speed;

        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timer >= delay)
        {
            Fire();
        }
    }

    void Fire()
    {

        Instantiate(pin, body.transform.position, Quaternion.identity);
        timer = 0;
    }
} 
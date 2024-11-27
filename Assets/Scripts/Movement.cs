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
    [SerializeField] public SpriteRenderer mySprite;
    // Start is called before the first frame update
    void Start()
    {
        SetSpriteColor();  
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

    Color StringToColor(string colorString)
    {
        // Split the string by commas
        string[] colorComponents = colorString.Split(',');
        if (colorComponents.Length == 4)
        {
            // Parse each component to a float and create the Color object
            float r = float.Parse(colorComponents[0]);
            float g = float.Parse(colorComponents[1]);
            float b = float.Parse(colorComponents[2]);
            float a = float.Parse(colorComponents[3]);

            // Return the color created from the parsed components
            return new Color(r, g, b, a);
        }
        return Color.white;
    }
    private void SetSpriteColor()
    {
        if (PlayerPrefs.HasKey("spriteColor")) {
            Color color = StringToColor(PlayerPrefs.GetString("spriteColor"));
            mySprite.color = color;
        }
        else
        {
             mySprite.color= Color.white;
        }
    }
} 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public KeyCode upKey;
    public KeyCode downKey;
    public float topWall;
    public float bottomWall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //if any change happens with paddle input
        if (Input.GetKeyDown(upKey) || Input.GetKeyUp(upKey) || Input.GetKeyDown(downKey) || Input.GetKeyUp(downKey))
        {
            //if both keys are down, dont move paddle
            if (Input.GetKey(upKey) && Input.GetKey(downKey))
            {
                rb.velocity = new Vector2(0, 0);
            }
            //if only up key is down, move the paddle up
            else if (Input.GetKey(upKey))
            {
                rb.velocity = new Vector2(0, speed);
            }
            //if only down key is down, move paddle down
            else if (Input.GetKey(downKey))
            {
                rb.velocity = new Vector2(0, -speed);
            }
            //if neither key is down, dont move paddle
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        //if paddle is at the bottom wall, stop it from going farther down
        if(rb.position.y < bottomWall && Input.GetKey(downKey))
        {
            rb.velocity = new Vector2(0, 0);
        }
        //if paddle is at the top wall, stop it from going farther up
        if(rb.position.y > topWall && Input.GetKey(upKey))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}

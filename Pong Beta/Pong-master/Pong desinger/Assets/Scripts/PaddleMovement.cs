using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public float rightWall;
    public float leftWall;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        //if any change happens with paddle input
        if (Input.GetKeyDown(rightKey) || Input.GetKeyUp(rightKey) || Input.GetKeyDown(leftKey) || Input.GetKeyUp(leftKey))
        {
            //if both keys are down, dont move paddle
            if (Input.GetKey(rightKey) && Input.GetKey(leftKey))
            {
                rb.velocity = new Vector2(0, 0);
            }
            //if only up key is down, move the paddle up
            else if (Input.GetKey(rightKey))
            {
                rb.velocity = new Vector2(speed, 0);
            }
            //if only down key is down, move paddle down
            else if (Input.GetKey(leftKey))
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            //if neither key is down, dont move paddle
            else
            {
                rb.velocity = new Vector2(0, 0);
            }
        }
        //if paddle is at the bottom wall, stop it from going farther down
        if(rb.position.x < leftWall && Input.GetKey(leftKey))
        {
            rb.velocity = new Vector2(0, 0);
        }
        //if paddle is at the top wall, stop it from going farther up
        if(rb.position.x > rightWall && Input.GetKey(rightKey))
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
}

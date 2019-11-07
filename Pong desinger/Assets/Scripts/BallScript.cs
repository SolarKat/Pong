using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    Vector2 direction = new Vector2(1,1);
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //get a random direction and set the ball to that direction at the start of the game
        int rand1 = Random.Range(-100, 100);
        int rand2 = Random.Range(-100, 100);
        direction = new Vector2(rand1, rand2);
        direction.Normalize();
        rb.velocity = new Vector2(direction.x*speed, direction.y*speed);
    }

    // Update is called once per frame
    void Update()
    {
        //each update. keep the ball the same speed in the direction its going
        direction = rb.velocity;
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}

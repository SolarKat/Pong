using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed = 5;
    Vector2 direction = new Vector2(1,1);
    public GameObject goal1;
    public GameObject goal2;
    int score1;
    int score2;
    public Text txt1;
    public Text txt2;
    bool reset;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        resetPosition();
        resetScores();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && reset)
        {
            resetPosition();
            reset = false;
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
        //each update. keep the ball the same speed in the direction its going
        direction = rb.velocity;
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }

    public void resetPosition()
    {
        reset = true;
        rb.velocity = new Vector2(0, 0);
        rb = GetComponent<Rigidbody2D>();
        rb.transform.position = new Vector2(0, 0);   
        //get a random direction and set the ball to that direction at the start of the game
        int rand1 = Random.Range(-100, 100);
        int rand2 = Random.Range(-100, 100);
        direction = new Vector2(rand1, rand2);
        direction.Normalize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == goal1)
        {
            score2++;
            resetPosition();
        }
        else if(collision.gameObject == goal2)
        {
            score1++;
            resetPosition();
        }
    }

    void resetScores()
    {
        score1 = 0;
        score2 = 0;
    }
}

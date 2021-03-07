using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    Rigidbody2D rb;
    public float bounceForce;
    bool firstBounce = false;
    float startingVel;
    Vector3 startingVelVec;
    Vector3 ballVec;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 

        if (!firstBounce)
        {

            if (Input.anyKeyDown)
            {

                StartBounce();
                firstBounce = true;
                GameManager.instance.GameStart();
            }
        }
        else
        {
             ballVec = rb.velocity;

        }
        if (startingVel > ballVec.magnitude)
        {
            rb.velocity = startingVelVec;
        }


    }

    void StartBounce()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1,1),1);
        Vector2 straight = new Vector2(0, 1);
        while (randomDirection == straight)//if ball is going to be going straight up 
        {
            randomDirection = new Vector2(Random.Range(-1, 1), 1);//keep going till not straight up
        }
        rb.AddForce(randomDirection * bounceForce, ForceMode2D.Impulse);//add veloicty 
         startingVel = rb.velocity.magnitude;
        startingVelVec = rb.velocity;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FallCheck")
        {

            GameManager.instance.Death();
        }else if(collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreUpdater();

        
            if (GameManager.instance.score % 15 == 0)
            {
                rb.AddForce(rb.velocity.normalized * 2, ForceMode2D.Impulse);//add velocity at intevals of 15
                startingVel = rb.velocity.magnitude;
                startingVelVec = rb.velocity;
            }

        }

    }
}

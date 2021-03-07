using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    int speedIncreaseCount = 0;

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
        Move();

        if (GameManager.instance.score % 15 == 0 && GameManager.instance.score <=60)
        {
            if (speedIncreaseCount == 0)
            {
                moveSpeed++;
                speedIncreaseCount = 1;
            }
        }
        else
        {
            speedIncreaseCount = 0;

        }

    }

    private void FixedUpdate()
    {
    }

    void Move()
    {
        if (Input.GetMouseButton(0))//check if screen is being clicked
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//get position of touch

            if (touchPos.x < 0)//move left
            {
                rb.velocity = Vector2.left * moveSpeed;

            }else if(touchPos.x > 0)//move right
            {
                rb.velocity = Vector2.right * moveSpeed;

            }
        }
        else
        {
            rb.velocity = Vector2.zero;//stop moving when not touching
        }
    }

}

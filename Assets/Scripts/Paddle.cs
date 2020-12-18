using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private Vector3 targetPos;
    private float height;
    private string input;
    
    public bool isRight;
    private GameObject ball;  
    
    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        //speed = 5f;
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            // place paddle right of the screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale;

            input = "PaddleRight";
        }
        else
        {
            // place paddle left of the screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale;

            input = "PaddleLeft";
        }

        // Update this paddle's position
        transform.position = pos;
        transform.name = input;
    }
    
    // Update is called once per frame
    void Update()
    {
        // GetAxis is a number between -1 to 1 (-1 for down, 1 for up)
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        
        // Restrict paddle movement
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        
        transform.Translate(move * Vector2.up);
        
        targetPos = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);

        if (isRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }
    }
}

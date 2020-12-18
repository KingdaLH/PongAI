using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Start is called before the first frame update
    void Start()
    {
        // Convert screen's pixel coordinate into game's coordinate
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        // Convert screen's pixel coordinate into game's coordinate
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //create ball
        Instantiate(ball);

        Paddle paddle1 = Instantiate(paddle);
        Paddle paddle2 = Instantiate(paddle);

        paddle1.Init(true); //right paddle
        paddle2.Init(false); // left paddle
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    private float radius;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // direction is (1,1) normalized
        radius = transform.localScale.x / 2; // half the width
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        // Handles collision with the ball
        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        // Game Over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.y < 0)
        {
            Debug.Log("Right player wins!!!");
            SceneManager.LoadScene(0);
        }

        if (transform.position.x > GameManager.topRight.x - radius && direction.y > 0)
        {
            Debug.Log("Left player wins!!!");
            SceneManager.LoadScene(0);
        }
    }

    // Handles collision with the paddle
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Paddle")
        {
            bool isRight = other.gameObject.GetComponent<Paddle>();
            if (isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}

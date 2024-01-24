using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed = 8f;
    private Vector2 direction;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction = Vector2.one.normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }
        if (collision.gameObject.CompareTag("LeftGoalWall")||collision.gameObject.CompareTag("RightGoalWall"))
        {
            if (collision.gameObject.CompareTag("RightGoalWall"))
            {
                GameManager.instance.AddScore(true);
                RespawnBall(true);
            }
            else
            {
                GameManager.instance.AddScore(false);
                RespawnBall(false);
            }
        }
    }

    void RespawnBall(bool isLeftWin)
    {
        transform.position = new Vector2(-0.5f, -0.5f);
        if (isLeftWin)
            direction = new Vector2(1, 1);
        else
            direction = new Vector2(-1, 1);
    }
    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = direction * speed;
    }
}

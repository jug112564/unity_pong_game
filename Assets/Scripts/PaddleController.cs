using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private Rigidbody2D rigidbody; 
    public float speed = 8f;
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yInput;
        if (isPlayer1) 
            yInput = Input.GetAxis("Player1Vertical");
        else
            yInput = Input.GetAxis("Player2Vertical");

        float ySpeed = yInput * speed;

        Vector3 newVelocity = new Vector3(0f, ySpeed, 0f);

        rigidbody.velocity = newVelocity;
    }
}

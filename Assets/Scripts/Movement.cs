using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D fish;
    public float speed;
    public Transform boundryLeft;
    public Transform boundryRight;

    private Vector2 right;
    private Vector2 left;
    private Vector2 direction;

    private void Start()
    {
        speed = 1.0f;
        right = new Vector2(1, 0);
        left = new Vector2(-1, 0);
        direction = right;
    }

    private void FixedUpdate()
    {
        fish.AddForce(direction * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "LeftBoundry")
        {
            direction = right;
        }
        else if (collision.collider.tag == "RightBoundry")
        {

        }
        {
            direction = left;
        }
    }


}

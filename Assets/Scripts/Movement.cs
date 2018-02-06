using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[HideInInspector]public new Rigidbody2D rigidbody2D;
    public float speed = 1;

    private Vector2 direction;

	private void Awake ()
	{
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

    private void Start()
    {
		direction = Random.onUnitSphere.normalized;
    }

    private void FixedUpdate()
    {
        rigidbody2D.AddForce(direction * speed);
        transform.right = rigidbody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
		direction = -direction;
    }
}

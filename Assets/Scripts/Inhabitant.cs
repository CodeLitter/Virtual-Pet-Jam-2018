using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Inhabitant : MonoBehaviour
{
    private int _idSpeed = Animator.StringToHash("Speed");
    private int _idDeath = Animator.StringToHash("Death");
    [HideInInspector] public Animator animator;
    [HideInInspector] public new SpriteRenderer renderer;
    [HideInInspector] public new Rigidbody2D rigidbody2D;
    public Attributes attributes;
    public bool alive
    {
        get
        {
            return rigidbody2D.gravityScale == 0;
        }
    }


    private void OnValidate ()
    {
        if (attributes)
        {
            animator = GetComponent<Animator>();
            if (animator)
            {
                animator.runtimeAnimatorController = attributes.controller;
            }
            renderer = GetComponent<SpriteRenderer>();
            if (renderer)
            {
                renderer.material = attributes.material;
            }
        }
    }

    private void Awake ()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update ()
    {
        animator.SetFloat(_idSpeed, rigidbody2D.velocity.magnitude);
        renderer.flipY = rigidbody2D.velocity.x < 0;
    }

    public void Kill ()
    {
        animator.SetTrigger(_idDeath);
        rigidbody2D.gravityScale = 1;
    }
}

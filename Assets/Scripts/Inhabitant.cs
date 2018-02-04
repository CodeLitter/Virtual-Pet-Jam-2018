using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class Configure : MonoBehaviour
{
    private int _idSpeed = Animator.StringToHash("Speed");
    private int _idDeath = Animator.StringToHash("Death");
    [HideInInspector]public Animator animator;
    [HideInInspector]public new Renderer renderer;
    [HideInInspector]public new Rigidbody2D rigidbody2D;
    public Attributes attributes;

    private void OnValidate ()
    {
        if (attributes)
        {
            animator = GetComponent<Animator>();
            if (animator)
            {
                animator.runtimeAnimatorController = attributes.controller;
            }
            renderer = GetComponent<Renderer>();
            if (renderer)
            {
                renderer.material = attributes.material;
            }
        }
    }

    private void Awake ()
    {
        animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update ()
    {
        animator.SetFloat(_idSpeed, rigidbody2D.velocity.magnitude);
        //TODO conditions to kill the fish
        //animator.SetTrigger(idDeath, )
    }
}

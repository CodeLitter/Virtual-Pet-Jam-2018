using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Renderer))]
public class Life : MonoBehaviour
{
    [HideInInspector]
    public Animator animator;
    [HideInInspector]
    public new Renderer renderer;
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

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = attributes.controller;
    }
}

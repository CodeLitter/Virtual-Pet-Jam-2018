using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inhabitant))]
public class Age : MonoBehaviour
{
    [HideInInspector] public Inhabitant inhabitant;

    private void Awake()
    {
        inhabitant = GetComponent<Inhabitant>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (inhabitant.attributes.lifespan <= inhabitant.attributes.age)
        {
            transform.localScale = Vector3.one;
            enabled = false;
        }
        else if (transform.localScale != Vector3.one / 2)
        {
            transform.localScale = Vector3.one / 2;
        }
    }
}

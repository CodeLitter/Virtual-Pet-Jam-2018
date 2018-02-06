using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inhabitant))]
public class Hunger : MonoBehaviour
{
    [HideInInspector] public Inhabitant inhabitant;
    private int time;

    private void Awake()
    {
        inhabitant = GetComponent<Inhabitant>();
    }
    private void Start()
    {
        time = inhabitant.attributes.age;
    }

    private void Update()
    {
        if (time != inhabitant.attributes.age)
        {
            inhabitant.attributes.hunger -= 0.1f;
            time = inhabitant.attributes.age;
        }

        Color color = inhabitant.renderer.color;
        inhabitant.renderer.color = new Color(color.r,
                                                color.g,
                                                color.b, 
                                                inhabitant.attributes.hunger);
        if (inhabitant.attributes.hunger <= 0)
        {
            inhabitant.Kill();
        }
    }

}

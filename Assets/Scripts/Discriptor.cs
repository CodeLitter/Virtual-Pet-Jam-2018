using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Marine/Discriptor")]
public class Discriptor : ScriptableObject
{
    public int minLifeSpan;
    public int maxLifeSpan;
    public AnimatorOverrideController controller;
    public Material[] materials;

    public Attributes Create ()
    {
        Attributes attributes = ScriptableObject.CreateInstance<Attributes>();
        attributes.controller = controller;
        attributes.lifespan = Random.Range(minLifeSpan, maxLifeSpan);
        attributes.material = materials[Random.Range(0, materials.Length)];
        attributes.age = 0;

        return attributes;
    }
}

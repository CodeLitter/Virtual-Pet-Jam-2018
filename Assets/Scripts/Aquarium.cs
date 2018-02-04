using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    public readonly List<GameObject> marineLife = new List<GameObject>();

    private void Awake()
    {
    }

    public void Spawn (Discriptor discriptor)
    {
        Attributes attributes = discriptor.Create();
        GameObject game_object = new GameObject();
        game_object.AddComponent<SpriteRenderer>();
        game_object.AddComponent<Animator>();
        game_object.AddComponent<Rigidbody2D>().gravityScale = 0;
        var configure = game_object.AddComponent<Configure>();
        configure.attributes = attributes;
        configure.SendMessage("OnValidate");
        marineLife.Add(game_object);
    }   
}

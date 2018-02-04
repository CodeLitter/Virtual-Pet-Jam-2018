using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    public List<Attributes> marineLife;

    private void Spawn ()
    {
        foreach (var marine_life in marineLife)
        {
            GameObject game_object = new GameObject(marine_life.name);
            game_object.AddComponent<SpriteRenderer>();
            game_object.AddComponent<Animator>();
            game_object.AddComponent<Rigidbody2D>().gravityScale = 0;
            var configure = game_object.AddComponent<Configure>();
            configure.attributes = marine_life;
            configure.SendMessage("OnValidate");
        }
    }

    private void Start()
    {
        Spawn();
    }
}

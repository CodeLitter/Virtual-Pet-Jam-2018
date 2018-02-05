using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    //public readonly List<GameObject> marineLife = new List<GameObject>();
    public Inhabitant prefab;

    private void OnEnable ()
    {
        //TODO Assignment of certain inhabitants to each aquarium
        foreach (var item in LifeTracker.instance.attributes)
        {
            Spawn(item, Vector3.zero);
        }
    }

    public void Spawn (Attributes attributes, Vector3 position)
    {
        Inhabitant inhabitant = Instantiate<Inhabitant>(prefab, position, Quaternion.identity, transform);
        inhabitant.attributes = attributes;
        inhabitant.SendMessage("OnValidate");
    }   
}

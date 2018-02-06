using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    public Inhabitant prefab;

    public void Spawn (Attributes attributes)
    {
        Vector3 position = Random.insideUnitCircle * Camera.main.fieldOfView;
        Inhabitant inhabitant = Instantiate<Inhabitant>(prefab, position, Quaternion.identity, transform);
        inhabitant.attributes = attributes;
        inhabitant.SendMessage("OnValidate");
    }   
}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    public Inhabitant prefab;

    private void OnEnable ()
    {
        //TODO Assignment of certain inhabitants to each aquarium
        foreach (var item in Tracker.instance.attributes)
        {
            Spawn(item, Vector3.zero);
        }
    }

    public void Spawn (Descriptor descriptor)
    {
        Attributes attributes = descriptor.Create();
        Vector3 position = Random.insideUnitCircle * Camera.main.fieldOfView;
    }

    public void Spawn (Attributes attributes, Vector3 position)
    {
        Inhabitant inhabitant = Instantiate<Inhabitant>(prefab, position, Quaternion.identity, transform);
        inhabitant.attributes = attributes;
        inhabitant.SendMessage("OnValidate");
    }   
}

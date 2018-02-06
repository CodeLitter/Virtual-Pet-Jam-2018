using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour
{
    public int max = 5;
    public Inhabitant prefab;

    private void OnEnable ()
    {
        foreach (var attributes in Tracker.instance.attributes.Take(max))
        {
            Spawn(attributes);
        }
        Tracker.instance.attributes = Tracker.instance.attributes.Skip(max).ToList();
    }

    public void Spawn (Attributes attributes)
    {
        Vector3 position = Random.insideUnitCircle * Camera.main.orthographicSize;
        Inhabitant inhabitant = Instantiate<Inhabitant>(prefab, position, Quaternion.identity, transform);
        inhabitant.attributes = attributes;
        inhabitant.SendMessage("OnValidate");
    }   
}

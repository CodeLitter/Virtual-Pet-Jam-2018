using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inhabitant))]
[RequireComponent(typeof(Collider2D))]
public class Selector : MonoBehaviour
{
    private void OnMouseDown ()
    {
        Tracker.instance.selected = GetComponent<Inhabitant>();
    }
}

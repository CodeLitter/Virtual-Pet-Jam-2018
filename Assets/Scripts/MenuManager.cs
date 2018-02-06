using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene (int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Buy (Descriptor descriptor)
    {
        Attributes attributes = descriptor.Create();
        Tracker.instance.attributes.Add(attributes);
    }

    public void Sell (Attributes attributes)
    {
        //valuate
        //add to cash
        //remove from list
    }

    public void AddFood()
    {
        Tracker.instance.food++;
    }

    public void Feed ()
    {
        if (Tracker.instance.selected != null)
        {
            if (Tracker.instance.selected.alive)
            {
                float additive = 0.2f;
                float value = Tracker.instance.selected.attributes.hunger;
                Tracker.instance.selected.attributes.hunger = Mathf.Clamp01(value + additive);
            }
        }
    }

    public void Take ()
    {
        if (Tracker.instance.selected != null)
        {
            if (Tracker.instance.selected.alive)
            {
                Tracker.instance.attributes.Add(Tracker.instance.selected.attributes);
            }
            Destroy(Tracker.instance.selected.gameObject);
            Tracker.instance.selected = null;
        }
    }
}

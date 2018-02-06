using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEngine.UI.Text cashText;
    public UnityEngine.UI.Text foodText;

    public void LoadScene (int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Buy (Descriptor descriptor)
    {
        Attributes attributes = descriptor.Create();
        Tracker.instance.attributes.Add(attributes);
    }

    public void AddFood()
    {
        Tracker.instance.food++;
    }

    private void Update()
    {
        cashText.text = string.Format("${0}", Tracker.instance.cash);
        foodText.text = string.Format("Food: {0}", Tracker.instance.food);
    }
}

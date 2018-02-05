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
        LifeTracker.instance.Create(descriptor);
    }
}

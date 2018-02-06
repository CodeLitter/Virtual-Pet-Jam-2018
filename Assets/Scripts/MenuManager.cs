using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public UnityEngine.UI.Text cashText;
    public UnityEngine.UI.Text foodText;
    public UnityEngine.UI.RawImage inhabitantImage;
    public Camera inhabitantCamera;

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

    public void Take ()
    {
        if (Tracker.instance.selected != null)
        {
            Tracker.instance.attributes.Add(Tracker.instance.selected.attributes);
            Destroy(Tracker.instance.selected.gameObject);
            Tracker.instance.selected = null;
        }
    }

    private void Update()
    {
        cashText.text = string.Format("${0}", Tracker.instance.cash);
        foodText.text = string.Format("Food: {0}", Tracker.instance.food);
        if (Tracker.instance.selected != null)
        {
            var selected = Tracker.instance.selected;
            inhabitantCamera.gameObject.SetActive(true);
            inhabitantCamera.transform.position = new Vector3(selected.transform.position.x, 
                                                              selected.transform.position.y, 
                                                              inhabitantCamera.transform.position.z);
            inhabitantImage.color = Color.white;
        }
        else
        {
            inhabitantCamera.gameObject.SetActive(false);
            inhabitantImage.color = Color.clear;
        }
    }
}

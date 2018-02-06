using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerGUI : MonoBehaviour
{
    public UnityEngine.UI.Text cashText;
    public UnityEngine.UI.Text foodText;
    public UnityEngine.UI.RawImage inhabitantImage;
    public Camera inhabitantCamera;

    // Use this for initialization
    void Start()
    {

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

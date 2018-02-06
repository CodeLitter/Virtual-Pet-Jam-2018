using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollContent : MonoBehaviour
{
    public MenuManager manager;
    public GameObject prefab;

    private void OnEnable()
    {
        foreach (var item in Tracker.instance.attributes)
        {
            var game_object = Instantiate(prefab, transform);
            game_object.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0}, {1}", item.name, item.value);
            //game_object.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {  });
        }
        //populate with prefab
    }
}

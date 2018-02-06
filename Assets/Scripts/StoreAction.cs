using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreAction : MonoBehaviour
{
    public int price;
    public UnityEngine.Events.UnityEvent onClick;


    public void Action ()
    {
        if (Tracker.instance.cash >= price)
        {
            onClick.Invoke();
            Tracker.instance.cash -= price;
        }
    }
}

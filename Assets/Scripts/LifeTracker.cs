using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTracker : ScriptableObject
{
    private static LifeTracker lifeTracker;
    public static LifeTracker instance
    {
        get
        {
            if (!lifeTracker)
            {
                lifeTracker = ScriptableObject.CreateInstance<LifeTracker>();
            }
            return lifeTracker;
        }
    }

    public List<Attributes> attributes = new List<Attributes>();
}

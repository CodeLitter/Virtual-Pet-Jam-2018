using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : ScriptableObject
{
    private static Tracker tracker;
    public static Tracker instance
    {
        get
        {
            if (!tracker)
            {
                tracker = ScriptableObject.CreateInstance<Tracker>();
            }
            return tracker;
        }
    }

    public List<Attributes> attributes = new List<Attributes>();
    public int cash;
    public int food;
}

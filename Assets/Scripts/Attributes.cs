using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName="Marine/Attributes")]
public class Attributes : ScriptableObject
{
    private System.DateTime _creation;
    public AnimatorOverrideController controller;
    public Material material;
    public int lifespan = 2;
    public int age
    {
        set
        {
            DateTime now = System.DateTime.Now;
            _creation = new DateTime(
                now.Year,
                now.Month,
                now.Day,
                now.Hour,
                now.Minute + value,
                now.Second
            );
        }
        get
        {
            return (System.DateTime.Now - _creation).Minutes;
        }
    }
}

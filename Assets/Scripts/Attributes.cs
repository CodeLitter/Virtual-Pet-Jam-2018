using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName="Marine/Attributes")]
public class Attributes : ScriptableObject
{
    private System.DateTime creation;
    public AnimatorOverrideController controller;
    public Material material;
    public int health = 10;
    public int age
    {
        set
        {
            DateTime now = System.DateTime.Now;
            creation = new DateTime(
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
            return (System.DateTime.Now - creation).Minutes;
        }
    }
}

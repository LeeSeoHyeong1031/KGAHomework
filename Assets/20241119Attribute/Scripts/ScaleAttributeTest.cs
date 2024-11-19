using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAttributeTest : MonoBehaviour
{
    [Scale(1f, 2f, 3f)]
    public Transform gameObj;

    [Scale(2f, 2f, 2f)]
    public RectTransform uiObj;
}

[AttributeUsage(AttributeTargets.Field)]
public class ScaleAttribute : Attribute
{
    public float x, y, z;

    public ScaleAttribute()
    {
        x = 1f;
        y = 1f;
        z = 1f;
    }

    public ScaleAttribute(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}

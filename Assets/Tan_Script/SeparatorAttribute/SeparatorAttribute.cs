using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparatorAttribute : PropertyAttribute
{
    public readonly float Height;
    public readonly float Spacing;

    public SeparatorAttribute(float height, float spacing)
    {
        Height = height;
        Spacing = spacing;
    }
}

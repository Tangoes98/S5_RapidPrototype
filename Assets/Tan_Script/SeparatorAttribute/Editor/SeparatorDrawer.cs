using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        // Reference to attribute
        SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;

        // define line to draw
        Rect sepearatorRect = new Rect(
            position.xMin,
            position.yMin + separatorAttribute.Spacing,
            position.width,
            separatorAttribute.Height);

        // Draw
        EditorGUI.DrawRect(sepearatorRect, Color.white);

    }

    // Double the space above and under the separator
    public override float GetHeight()
    {
        SeparatorAttribute separatorAttribute = attribute as SeparatorAttribute;
        float totalSpacing =
            separatorAttribute.Spacing
            + separatorAttribute.Height
            + separatorAttribute.Spacing;
        return totalSpacing;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(PlayerAbility))]
public class PlayerAbilityDrawer : PropertyDrawer
{
    SerializedProperty _playerAttributes;
    SerializedProperty _abilityLevel;

    // how to draw to the Inspector window
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        //base.OnGUI(position, property, label);

        EditorGUI.BeginProperty(position, label, property);

        // drawing instruction
        Rect foldOutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);


        // Start to draw properties

        EditorGUI.EndProperty();
    }


    // request more vertical spacing, return it
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 2;


        // increase the height if expand arrow
        if (property.isExpanded)
        {
            totalLines += 3;
        }



        return (EditorGUIUtility.singleLineHeight * totalLines);


    }




}

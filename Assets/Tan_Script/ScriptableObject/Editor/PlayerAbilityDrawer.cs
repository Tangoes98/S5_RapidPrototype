using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;


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

        _playerAttributes = property.FindPropertyRelative("_playerAttributes");

        // drawing instruction
        Rect foldOutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        property.isExpanded = EditorGUI.Foldout(foldOutBox, property.isExpanded, label);


        if (property.isExpanded)
        {
            // Start to draw properties
            DrawAbilityProperty(position);




        }

        EditorGUI.EndProperty();
    }


    // request more vertical spacing, return it
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        int totalLines = 1;


        // increase the height if expand arrow
        if (property.isExpanded)
        {
            totalLines += 2;
        }

        return (EditorGUIUtility.singleLineHeight * totalLines);

    }


    void DrawAbilityProperty(Rect position)
    {
        float xPos = position.min.x;
        float yPos = position.min.y + EditorGUIUtility.singleLineHeight;
        float width = position.size.x;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawRect = new Rect(xPos, yPos, width, height);
        EditorGUI.PropertyField(drawRect, _playerAttributes, new GUIContent("PlayerAttributes"));
    }




}

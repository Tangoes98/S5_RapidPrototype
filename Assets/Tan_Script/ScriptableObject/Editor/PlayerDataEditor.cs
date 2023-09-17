using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerData))]
public class PlayerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        PlayerData data = (PlayerData)target;

        EditorGUILayout.LabelField(data.Name.ToUpper(), EditorStyles.boldLabel);

        EditorGUILayout.Space(10);
        float playerAverageStrength =
            data.Strength
            + data.Dexterity
            + data.Constitution
            + data.Intelligence
            + data.Wisdom
            + data.Charisma;

        ProgressBar(playerAverageStrength / 120, "AVERAGE STRENGTH");
        // Add before
        base.OnInspectorGUI();
        // Add after

        EditorGUILayout.LabelField("LABELFIELD HERE");

    }
    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
    }



}

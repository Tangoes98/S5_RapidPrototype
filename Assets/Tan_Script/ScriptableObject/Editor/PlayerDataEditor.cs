using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Rendering;
using System.Drawing;

[CustomEditor(typeof(PlayerData))]
public class PlayerDataEditor : Editor
{
    SerializedProperty _name;
    SerializedProperty _level;
    SerializedProperty _exp;
    SerializedProperty _strength;
    SerializedProperty _dexterity;
    SerializedProperty _constitution;
    SerializedProperty _intelligence;
    SerializedProperty _wisdom;
    SerializedProperty _charisma;
    SerializedProperty _showSkills;
    SerializedProperty _skills;

    SerializedProperty _playerAbilities;

    private void OnEnable()
    {
        _name = serializedObject.FindProperty("_name");
        _level = serializedObject.FindProperty("_level");
        _exp = serializedObject.FindProperty("_exp");
        _strength = serializedObject.FindProperty("_strength");
        _dexterity = serializedObject.FindProperty("_dexterity");
        _constitution = serializedObject.FindProperty("_constitution");
        _intelligence = serializedObject.FindProperty("_intelligence");
        _wisdom = serializedObject.FindProperty("_wisdom");
        _charisma = serializedObject.FindProperty("_charisma");
        _showSkills = serializedObject.FindProperty("_showSkills");
        _skills = serializedObject.FindProperty("_skills");

        _playerAbilities = serializedObject.FindProperty("_playerAbilities");


    }

    public override void OnInspectorGUI()
    {

        float playerAverageStrength =
            _strength.intValue
            + _dexterity.intValue
            + _constitution.intValue
            + _intelligence.intValue
            + _wisdom.intValue
            + _charisma.intValue;


        // Add before
        //base.OnInspectorGUI();




        // Redraw inspector

        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField(_name.stringValue.ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.LabelField("player data".ToUpper(), EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_name);

        if (_name.stringValue == string.Empty)
            EditorGUILayout.HelpBox("Caution: No name specified", MessageType.Warning);

        EditorGUIUtility.labelWidth = 70;
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.PropertyField(_level);
        EditorGUILayout.PropertyField(_exp);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(20);
        EditorGUIUtility.labelWidth = 150;

        EditorGUILayout.PropertyField(_strength);
        EditorGUILayout.PropertyField(_dexterity);
        EditorGUILayout.PropertyField(_constitution);
        EditorGUILayout.PropertyField(_intelligence);
        EditorGUILayout.PropertyField(_wisdom);
        EditorGUILayout.PropertyField(_charisma);







        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        ProgressBar(playerAverageStrength / 120, "TOTAL");


        if (GUILayout.Button("Random Stats".ToUpper(), GUILayout.Width(150), GUILayout.Height(25))) RandomStats();

        GUILayout.FlexibleSpace();
        EditorGUILayout.EndHorizontal();







        if (playerAverageStrength <= 8 * 6)
            EditorGUILayout.HelpBox("Caution: Strength is too low", MessageType.Warning);

        EditorGUILayout.Space(15);
        EditorGUILayout.PropertyField(_showSkills);
        if (_showSkills.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(_skills);
            EditorGUI.indentLevel--;
        }


        EditorGUILayout.PropertyField(_playerAbilities, new GUIContent("Player Abilities"));






        if (GUILayout.Button("Save Editing".ToUpper(), GUILayout.Width(200), GUILayout.Height(30)))
        {
            SaveEditing();
        }


    }

    void SaveEditing()
    {
        serializedObject.ApplyModifiedProperties();
    }
    
    // void DataSavingCheckBox(bool isSaved)
    // {
    //     if (isSaved) return;
    //     if (!isSaved) EditorGUILayout.HelpBox("Data Saved", MessageType.Info);
    // }

    void ProgressBar(float value, string label)
    {
        Rect rect = GUILayoutUtility.GetRect(300, 25, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space(10);
    }

    void RandomStats()
    {
        _strength.intValue = Random.Range(2, 20);
        _dexterity.intValue = Random.Range(2, 20);
        _constitution.intValue = Random.Range(2, 20);
        _intelligence.intValue = Random.Range(2, 20);
        _wisdom.intValue = Random.Range(2, 20);
        _charisma.intValue = Random.Range(2, 20);
    }



}

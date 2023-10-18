using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSelectWindow : EditorWindow
{

    PlayerAttributes _playerAttributes;

    [MenuItem("Window / _PlayerAttributeSelector")]
    public static void ShowWindow()
    {
        GetWindow<PlayerSelectWindow>("PlayerAttributeSelector");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(5);
        GUILayout.Label("PlayerAttributeSelector");

        _playerAttributes = (PlayerAttributes)EditorGUILayout.EnumPopup("PlayerAttributeSelector", _playerAttributes);
    }
}

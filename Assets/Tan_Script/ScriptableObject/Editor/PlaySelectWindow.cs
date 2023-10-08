using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerSelectWindow : EditorWindow
{

    PlayerAttributes _playerAttributes;

    [MenuItem("Window / _Player Selector")]
    public static void ShowWindow()
    {
        GetWindow<PlayerSelectWindow>("Player Selector");
    }

    private void OnGUI()
    {
        EditorGUILayout.Space(5);
        GUILayout.Label("Player Selector");

        _playerAttributes = (PlayerAttributes)EditorGUILayout.EnumPopup("Player Selector", _playerAttributes);
    }
}

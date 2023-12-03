using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class Proto_LevelEditor : Editor
{
    private static Proto_LevelGenerator generator;



    public static string SelectedObjectId
    {
        get
        {
            return EditorPrefs.GetString("SelectedObjectId", "delault");
        }
        set
        {
            EditorPrefs.SetString("SelectedObjectId", value);
        }
    }








    [MenuItem("Editor/OpenLevelEditor")]
    public static void OpenLevelEditor()
    {
        generator = FindObjectOfType<Proto_LevelGenerator>();
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        GUI.color = Color.white;
        DrawLeftPanel(sceneView);
        HandleMouseEvents();
    }

    static void DrawLeftPanel(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUI.Box(new Rect(0, 0, 180, sceneView.position.height), GUIContent.none, EditorStyles.textArea);

        DrawObjectButtons(sceneView);

        Handles.EndGUI();
    }

    private static void DrawObjectButtons(SceneView sceneView)
    {
        GUI.Label(new Rect(sceneView.position.width - 280 * 2.5f, 20, 100, 20), "OBJECTS");
        for (int i = 0; i < generator.AvaliableObjects.Length; i++)
        {
            DrawObjectButton(i, sceneView.position);
        }
    }

    private static void DrawObjectButton(int index, Rect sceneView)
    {
        string objectName = generator.AvaliableObjects[index].name;
        bool isActive = false;
        if (objectName == SelectedObjectId)
        {
            isActive = true;
        }

        var assetTexture = AssetPreview.GetAssetPreview(generator.AvaliableObjects[index].gameObject);
        GUIContent buttonContent = new GUIContent(assetTexture, objectName);

        Color defaultColor = GUI.color;
        float xOffset = 0;
        int tempIndex = index;

        if (index >= generator.AvaliableObjects.Length / 2)
        {
            xOffset = 60;
            tempIndex = index - Mathf.FloorToInt(generator.AvaliableObjects.Length / 2);
        }

        bool isToggleDown = GUI.Toggle(new Rect(sceneView.width - 310 * 2.5f + xOffset + 5, 50 + tempIndex * 72 + 5, 50, 50), isActive, buttonContent, GUI.skin.button);
        GUI.color = Color.white;
        GUI.Label(new Rect(sceneView.width - 310 * 2.5f + xOffset + 5, 50 + tempIndex * 72 + 55, 50, 20), objectName);
        GUI.color = defaultColor;

        if (isToggleDown == true && isActive == false)
        {
            SelectedObjectId = objectName;
        }
    }


    static void HandleMouseEvents()
    {
        if (IsSceneClicked()) AddObject();
    }



    private static bool IsSceneClicked()
    {
        return Event.current.type == EventType.MouseDown &&
                    Event.current.button == 0 &&
                    Event.current.alt == false &&
                    Event.current.shift == false &&
                    Event.current.control == false;
    }

    private static void AddObject()
    {
        Ray ray = Camera.current.ScreenPointToRay(
                        new Vector3(Event.current.mousePosition.x,
                        -Event.current.mousePosition.y + Camera.current.pixelHeight));

        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 30);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000, generator.GroundLayer))
        {
            if (hit.collider.gameObject)
            {
                LevelObjectData data = new LevelObjectData(hit.point, Quaternion.identity, Vector3.one, SelectedObjectId);
                generator.CreateNewObject(data);

            }
        }

    }








}

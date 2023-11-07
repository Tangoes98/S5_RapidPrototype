using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace Proto.Windows
{
    public class ProtoNodeGraphWindow : EditorWindow
    {
        [MenuItem("Window/Custom_NodeGraphWindow/Custom_ProtoNodeGraphWindow")]
        public static void ShowExample()
        {
            ProtoNodeGraphWindow wnd = GetWindow<ProtoNodeGraphWindow>();
            wnd.titleContent = new GUIContent("ProtoNodeGraphWindow");
        }

        // public void CreateGUI()
        // {
        //     // Each editor window contains a root VisualElement object
        //     VisualElement root = rootVisualElement;

        //     // VisualElements objects can contain other VisualElement following a tree hierarchy.
        //     VisualElement label = new Label("Hello World! From C#");
        //     root.Add(label);
        // }

        private void OnEnable()
        {
            AddGraphView();
        }
        void AddGraphView()
        {
            ProtoGraphView graphView = new();
            graphView.StretchToParentSize();
            rootVisualElement.Add(graphView);
        }


    }
}
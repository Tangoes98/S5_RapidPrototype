using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Proto.Windows
{
    using Elements;
    public class ProtoGraphView : GraphView
    {
        public ProtoGraphView()
        {
            AddManipulators();
            AddGridBackgorund();
            CreateNode();
            AddStyles();
        }

        void AddManipulators()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());
        }

        void AddGridBackgorund()
        {
            GridBackground gb = new GridBackground();
            gb.StretchToParentSize();
            Insert(0, gb);
        }

        void CreateNode()
        {
            ProtoNode node = new();
            node.Initialize();
            node.Draw();
            AddElement(node);
        }

        void AddStyles()
        {
            StyleSheet ss = (StyleSheet)EditorGUIUtility.Load("Assets/Tan_UIGraphview/EditorDefaultResources/ProtoGraphViewWindow/ProtoGraphViewStyles.uss");
            styleSheets.Add(ss);
        }
    }
}

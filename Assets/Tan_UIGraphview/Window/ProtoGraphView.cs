using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Proto.Windows
{
    using Elements;
    using UnityEngine;

    public class ProtoGraphView : GraphView
    {
        public ProtoGraphView()
        {
            AddManipulators();
            AddGridBackgorund();
            //CreateNode();
            AddStyles();
        }

        void AddManipulators()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());

            this.AddManipulator(CreateNodeContextualMenu());

            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());



        }

        IManipulator CreateNodeContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(

                menuEvent => menuEvent.menu.AppendAction("Add Node", actionEvent => AddElement(CreateNode(actionEvent.eventInfo.localMousePosition)))
            );
            
            return contextualMenuManipulator;
        }






        void AddGridBackgorund()
        {
            GridBackground gb = new GridBackground();
            gb.StretchToParentSize();
            Insert(0, gb);
        }

        GraphElement CreateNode(Vector2 position)
        {
            ProtoNode node = new();
            node.Initialize(position);
            node.Draw();

            return node;
            //AddElement(node);
        }

        void AddStyles()
        {
            StyleSheet ss = (StyleSheet)EditorGUIUtility.Load("Assets/Tan_UIGraphview/EditorDefaultResources/ProtoGraphViewWindow/ProtoGraphViewStyles.uss");
            styleSheets.Add(ss);
        }
    }
}

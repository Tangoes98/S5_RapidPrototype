using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace Proto.Windows
{
    using System;
    using System.Collections.Generic;
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

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new List<Port>();

            ports.ForEach(port =>
            {
                if (startPort == port) return;
                if (startPort.node == port.node) return;
                if (startPort.direction == port.direction) return;
                compatiblePorts.Add(port);

            });

            return compatiblePorts;
        }





        void AddManipulators()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());

            this.AddManipulator(CreateNodeContextualMenu("Add Node (Single Choice)", GraphViewNodeType.SingleChoice));
            this.AddManipulator(CreateNodeContextualMenu("Add Node (Multiple Choice)", GraphViewNodeType.MultiChoice));

            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());



        }

        IManipulator CreateNodeContextualMenu(string actionTitle, GraphViewNodeType nodeType)
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(

                menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(CreateNode(nodeType, actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }






        void AddGridBackgorund()
        {
            GridBackground gb = new GridBackground();
            gb.StretchToParentSize();
            Insert(0, gb);
        }

        GraphElement CreateNode(GraphViewNodeType nodeType, Vector2 position)
        {
            Type type = Type.GetType($"Proto.Elements.Proto{nodeType}Node");
            ProtoNode node = (ProtoNode)Activator.CreateInstance(type);
            node.Initialize(position);
            node.Draw();

            return node;
            //AddElement(node);
        }

        void AddStyles()
        {
            StyleSheet ss = (StyleSheet)EditorGUIUtility.Load("Assets/Tan_UIGraphview/EditorDefaultResources/ProtoGraphViewWindow/ProtoGraphViewStyles.uss");
            //StyleSheet nodess = (StyleSheet)EditorGUIUtility.Load("Assets/Tan_UIGraphview/EditorDefaultResources/ProtoGraphViewWindow/ProtoNodeStyles.uss");

            styleSheets.Add(ss);
            //styleSheets.Add(nodess);
        }
    }
}

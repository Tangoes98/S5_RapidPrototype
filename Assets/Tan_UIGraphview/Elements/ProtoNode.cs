using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Proto.Elements
{
    public enum GraphViewType
    {
        SingleChoice,
        MultiChoice
    }

    public class ProtoNode : Node
    {
        public string ProtoName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }
        public GraphViewType ProtoType { get; set; }

        public virtual void Initialize(Vector2 position)
        {
            ProtoName = "ProtoName";
            Choices = new();
            Text = "Proto Content text.";

            SetPosition(new Rect(position, Vector2.zero));
        }

        public virtual void Draw()
        {
            TextField protoNameTextField = new()
            {
                value = ProtoName
            };
            titleContainer.Insert(0, protoNameTextField);



            Port inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            inputPort.portName = "InputPort";
            inputContainer.Add(inputPort);



            VisualElement customDataContainer = new();

            Foldout textFoldout = new()
            {
                text = "Proto Text"
            };
            TextField textFoldoutField = new()
            {
                value = Text
            };
            textFoldout.Add(textFoldoutField);
            customDataContainer.Add(textFoldout);

            extensionContainer.Add(customDataContainer);

        }


    }
}

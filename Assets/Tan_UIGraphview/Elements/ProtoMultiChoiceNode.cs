using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


namespace Proto.Elements
{
    public class ProtoMultiChoiceNode : ProtoNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            ProtoNodeType = GraphViewNodeType.MultiChoice;

            Choices.Add("New Node");
        }

        public override void Draw()
        {
            base.Draw();


            Button addChoiceButton = new Button()
            {
                text = "Add Choice"
            };
            mainContainer.Insert(1,addChoiceButton);

            foreach (string choice in Choices)
            {
                Port choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));

                //choicePort.portName = choice;
                choicePort.portName = "";

                Button deleteChoiceButton = new Button()
                {
                    text = "Delete"
                };

                TextField choiceTextField = new TextField()
                {
                    value = choice
                };

                choicePort.Add(choiceTextField);
                choicePort.Add(deleteChoiceButton);

                outputContainer.Add(choicePort);

            }
            RefreshExpandedState();
        }
    }
}

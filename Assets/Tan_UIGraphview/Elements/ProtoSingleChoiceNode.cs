using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Proto.Elements
{
    public class ProtoSingleChoiceNode : ProtoNode
    {
        public override void Initialize(Vector2 position)
        {
            base.Initialize(position);

            ProtoType = GraphViewType.SingleChoice;

            Choices.Add("Next Node");
        }

        public override void Draw()
        {
            base.Draw();
            foreach (string choice in Choices)
            {
                Port choicePort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));

                choicePort.portName = choice;

                outputContainer.Add(choicePort);

            }
            RefreshExpandedState();
        }
    }
}

using Godot;
using System;

namespace VacksterClassic.Components {
    public partial class TurnHandler : Node
    {
        public const string groupName = "turnHandlers";

        [Export]
        public TurnProgressBar turnProgressBar;

        [Signal]
        public delegate void TurnStartedEventHandler();

        [Signal]
        public delegate void TurnEndedEventHandler();

        public override void _Ready()
        {
            AddToGroup(groupName);

            turnProgressBar.timer.Timeout += StartTurn;
        }

        public void StartTurn() {
            var turnHandlers = GetTree().GetNodesInGroup(groupName);
            foreach (Node node in turnHandlers) {
                if (node is TurnHandler turnHandler) {
                    turnHandler.turnProgressBar.timer.Paused = true;
                }
            }

            EmitSignal(SignalName.TurnStarted); // Turn is done setting up; Run custom logic
            // GetTree().CreateTimer(1d).Timeout += EndTurn;
        }

        public void EndTurn() {
            EmitSignal(SignalName.TurnEnded);

            var turnHandlers = GetTree().GetNodesInGroup(groupName);
            foreach (Node node in turnHandlers) {
                if (node is TurnHandler turnHandler) {
                    turnHandler.turnProgressBar.timer.Paused = false;
                }
            }
        }
    }
}
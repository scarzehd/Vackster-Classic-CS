using Godot;
using System;

namespace VacksterClassic.Components {
    public partial class TurnProgressBar : Node2D
    {
        public ValueHolder valueHolder;
        public ValueBar valueBar;
        public Timer timer;

        public override void _Ready()
        {
            valueHolder = GetNode<ValueHolder>("TurnProgressHolder");
            valueBar = GetNode<ValueBar>("TurnProgressBar");
            timer = GetNode<Timer>("Timer");
            
            timer.Start(valueHolder.MaxValue);
        }

        public override void _Process(double delta)
        {
            valueHolder.Value = (float)timer.TimeLeft;
        }
    }
}

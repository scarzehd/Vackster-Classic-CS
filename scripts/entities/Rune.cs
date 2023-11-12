using Godot;
using System;
using VacksterClassic.Components;

namespace VacksterClassic.Entities {
	public partial class Rune : Node2D
	{
		public override void _Ready()
		{
			Node node = GetNode("HealthHolder");
			if (node is ValueHolder healthHolder) {
				healthHolder.Value = healthHolder.MaxValue;
			}
		}
	}
}
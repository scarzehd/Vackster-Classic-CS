using Godot;
using System;

namespace VacksterClassic.Components {
	public partial class ValueBar : ProgressBar
	{
		[Export]
		public ValueHolder valueHolder;

		public override void _Ready()
		{
			MaxValue = valueHolder.MaxValue;
			Value = valueHolder.Value;

			valueHolder.OnMaxValueChanged += (float oldValue, float newValue) => {
				MaxValue = newValue;
			};
			valueHolder.OnValueChanged += (float oldValue, float newValue) => {
				Value = newValue;
			};
		}
	}
}

using Godot;
using System;

namespace VacksterClassic.Components {
	public partial class ValueHolder : Node
	{
		[Signal]
		public delegate void OnValueChangedEventHandler(float oldValue, float newValue);

		[Signal]
		public delegate void OnMaxValueChangedEventHandler(float oldValue, float newValue);

		[Export]
		public float Value {
			get {
				return value;
			}
			set {
				float oldValue = this.value;
				this.value = ClampValue(value, maxValue);
				EmitSignal(SignalName.OnValueChanged, oldValue, value);
			}
		}
		private float value;

		[Export]
		public float MaxValue { // If MaxValue is set to a number less than 0, it will be ignored.
			get {
				return maxValue;
			}
			set {
				float oldValue = maxValue;
				maxValue = value;
				Value = ClampValue(Value, maxValue);
				EmitSignal(SignalName.OnMaxValueChanged, oldValue, value);
			}
		}
		private float maxValue;

		private float ClampValue(float value, float maxValue) {
			if (maxValue < 0) return value;
			if (value > maxValue) return maxValue;
			return value;
		}
	}

}
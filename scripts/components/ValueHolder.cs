using Godot;
using System;

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
			this.value = ClampValue(value, maxValue);
			EmitSignal(SignalName.OnValueChanged);
		}
	}
	private float value;

	[Export]
	public float MaxValue { // If MaxValue is set to a number less than 0, it will be ignored.
		get {
			return maxValue;
		}
		set {
			maxValue = value;
			Value = ClampValue(Value, maxValue);
			EmitSignal(SignalName.OnMaxValueChanged);
		}
	}
	private float maxValue;

	private float ClampValue(float value, float maxValue) {
		if (maxValue < 0) return value;
		if (value > maxValue) return maxValue;
		return value;
	}
}

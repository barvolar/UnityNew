using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent _changeValue;

    private float _healingPower = 7f;
    private float _damagePower = 10f;
    private float _maxValue = 100f;

    public float Value { get; private set; }

    private void ControlValue()
    {
        Value = Mathf.Clamp(Value, 0, _maxValue);
    }

    public void TakeDamage()
    {
        if (Value > 0)
        {
            Value -= _damagePower;
            ControlValue();
            _changeValue.Invoke();
        }
    }

    public void Healing()
    {
        if (Value < _maxValue)
        {
            Value += _healingPower;
            ControlValue();
            _changeValue.Invoke();
        }
    }
}

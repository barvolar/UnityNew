using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{  
    private float _healingPower = 7f;
    private float _damagePower = 10f;
    private float _maxValue = 100f;

    public event UnityAction Changed;
    public float Value { get; private set; }

    private void Clamp()
    {
        Value = Mathf.Clamp(Value, 0, _maxValue);
    }

    public void TakeDamage()
    {
        if (Value > 0)
        {
            Value -= _damagePower;
            Clamp();          
            Changed?.Invoke();
        }
    }

    public void Heal()
    {
        if (Value < _maxValue)
        {
            Value += _healingPower;
            Clamp();
            Changed?.Invoke();
        }
    }
}

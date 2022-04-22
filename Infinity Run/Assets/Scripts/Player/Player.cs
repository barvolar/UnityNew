using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    private Animator _animator;
    private string _trigerName = "ApplayDamage";

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;
  
    private void Start()
    {
        _animator = GetComponent<Animator>();
        HealthChanged?.Invoke(_health);
    }

    private void Die()
    {
        Died?.Invoke();
    }

    private void RedFlash()
    {
        _animator.SetTrigger(_trigerName);     
    }

    public void AplleDamage(int damage)
    {
        _health -= damage;
        RedFlash();
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    
}

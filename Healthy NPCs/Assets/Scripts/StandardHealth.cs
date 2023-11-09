using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StandardHealth : MonoBehaviour, IHealth
{
    [SerializeField] private int _startingHealth = 100;
    private int _currentHealth;

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnDied = delegate { };

    private void Start()
    {
        _currentHealth = _startingHealth;
    }

    public float CurrentHPPct { get { return _currentHealth / (float)_startingHealth; } }

    public void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        _currentHealth -= amount;

        OnHPPctChanged(CurrentHPPct);

        if (CurrentHPPct <= 0)
            Die();
    }

    private void Die()
    {
        OnDied();
        Destroy(gameObject);
    }
}

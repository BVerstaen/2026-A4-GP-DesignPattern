using System;
using UnityEngine;

public interface IHealth
{
    public float GetStartingHealth();
    public float GetCurrentHealth();

    public void TakeDamage(float amount);

    event Action<float> OnUpdateHealth;
}

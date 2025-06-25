using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public event Action OnDamaged;
    public event Action OnDied;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0);

        OnDamaged?.Invoke();

        if (currentHealth == 0)
        {
            OnDied?.Invoke();
        }
    }
public int GetHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}


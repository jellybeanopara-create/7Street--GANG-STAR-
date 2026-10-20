

using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    public float CurrentHealth { get; private set; }

    public bool IsDead { get; private set; }

    void Start()
    {
        CurrentHealth = maxHealth;
        IsDead = false;
    }

    public void TakeDamage(float damage)
    {
        if (IsDead || damage <= 0f)
            return;

        CurrentHealth = Mathf.Max(
            0f,
            CurrentHealth - damage
        );

        Debug.Log(
            "Player health: " + CurrentHealth
        );

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        IsDead = true;
        Debug.Log("Player defeated!");
    }

    public void Heal(float amount)
    {
        if (IsDead || amount <= 0f)
            return;

        CurrentHealth = Mathf.Min(
            maxHealth,
            CurrentHealth + amount
        );
    }

    public void Respawn()
    {
        CurrentHealth = maxHealth;
        IsDead = false;
        Debug.Log("Player respawned!");
    }
}

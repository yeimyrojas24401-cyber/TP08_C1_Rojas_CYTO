using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyDataSo enemyData;
    private int currentHealth;
    public int CurrentHealth => currentHealth;
    public int MaxHealth => enemyData.MaxHealth;
    private bool isDead;

    public event UnityAction<int> OnHealthChanged;
    public event UnityAction OnDied;

    private void Start()
    {
        currentHealth = enemyData.MaxHealth;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    public bool TakeDamage(int amount)
    {
        if (isDead)
            return false;

        currentHealth -= amount;
        OnHealthChanged?.Invoke(CurrentHealth);

        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
            return true;
        }
        return false;
    }
    private void Die()
    {
        OnDied?.Invoke();
        if (enemyData.DeathVfx != null)
        {
            Instantiate(enemyData.DeathVfx, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}

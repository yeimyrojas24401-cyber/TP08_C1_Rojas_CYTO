using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerPowerUps playerPowerUps;

    private int currentHealth;
    public int CurrentHealth => currentHealth;
    private float invulnerabilityTimer;
    public bool IsInvulnerable => invulnerabilityTimer > 0; //responde a la necesidad de que no todo baje de un solo bajon
    private bool isDead;
    public bool IsFullHealth => currentHealth >= playerData.MaxHealth;

    public event UnityAction<int> OnHealthChanged;
    public event UnityAction<float> OnTakeDamage;
    public event UnityAction OnDied;

    private void Start()
    {
        currentHealth = playerData.MaxHealth;
        OnHealthChanged?.Invoke(CurrentHealth);
    }
    private void Update()
    {
        if (invulnerabilityTimer > 0)
        {
            invulnerabilityTimer -= Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleContact(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        HandleContact(collision);
    }

    private void HandleContact(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent<EnemyMarker>(out _))
            return;

        float direction = Mathf.Sign(transform.position.x - collision.transform.position.x);
        TakeHit(direction);
    }

    public void TakeHit(float direction)
    {
        if (isDead || IsInvulnerable || playerPowerUps.IsShielded)
            return;
        currentHealth--;
        OnHealthChanged?.Invoke(CurrentHealth);
        OnTakeDamage?.Invoke(direction);

        if (currentHealth <= 0)
        {
            isDead = true;
            OnDied?.Invoke();
            return;
        }

        invulnerabilityTimer = playerData.InvulnerabilityDuration;
    }

    public void AddLife(int amount)
    {
        if (isDead)
            return;
        currentHealth = Mathf.Min(currentHealth + amount, playerData.MaxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }
}

using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealth playerHealth;

    [Header("Attack Points")]
    [SerializeField] private Transform attackPointSide;
    [SerializeField] private Transform attackPointUp;
    [SerializeField] private Transform attackPointDown;
    [SerializeField] private LayerMask enemyLayer;

    private float attackTimer;

    private void OnEnable()
    {
        playerHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        playerHealth.OnDied -= HandleDied;
    }

    private void Update()
    {
        attackTimer -= Time.deltaTime;
        if (AnyKeyDown(playerData.AttackKeys) && attackTimer <= 0)
        {
            Attack();
            attackTimer = playerData.AttackCoolDown;
        }
    }

    private void Attack()
    {
        Vector2 center;
        Vector2 size = playerData.AttackSize;
        if (AnyKeyHeld(playerData.UpKeys))
        {
            center = attackPointUp.position;
            size = new Vector2(size.y, size.x);
        }
        else if (AnyKeyHeld(playerData.DownKeys) && !playerMovement.IsGrounded)
        {
            center = attackPointDown.position;
            size = new Vector2(size.y, size.x);
        }
        else
        {
            Vector2 side = attackPointSide.localPosition;
            center = (Vector2)transform.position + new Vector2(side.x * playerMovement.FacingDirection, side.y);
        }
        Collider2D[] hits = Physics2D.OverlapBoxAll(center, size, 0f, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            if(hit.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(playerData.AttackDamage);
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (playerData == null || attackPointSide == null || attackPointUp == null || attackPointDown == null) return;
        Vector2 s = playerData.AttackSize;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPointSide.position, s);
        Gizmos.DrawWireCube(attackPointUp.position, new Vector2(s.y, s.x));
        Gizmos.DrawWireCube(attackPointDown.position, new Vector2(s.y, s.x));
    }

    private void HandleDied()
    {
        enabled = false;
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }

    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach(KeyCode key in keys)
            if(Input.GetKey(key)) return true;
        return false;
    }
}

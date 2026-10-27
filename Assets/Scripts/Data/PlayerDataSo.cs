using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Data/Player Data")]
public class PlayerDataSo : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    public float MoveSpeed => moveSpeed;

    [SerializeField] private float jumpForce = 12f;
    public float JumpForce => jumpForce;

    [Range(0f, 1f)]
    [SerializeField] private float jumpCutMultiplier = 0.5f;
    public float JumpCutMultiplier => jumpCutMultiplier;

    [SerializeField] private int maxJumps = 2;
    public int MaxJumps => maxJumps;

    [SerializeField] private float groundCheckRadius = 0.15f;
    public float GroundCheckRadius => groundCheckRadius;

    [Header("Keys")]
    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.LeftArrow };
    public KeyCode[] LeftKeys => leftKeys;
    [SerializeField] private KeyCode[] rightKeys = { KeyCode.D, KeyCode.RightArrow }; 
    public KeyCode[] RightKeys => rightKeys;
    [SerializeField] private KeyCode[] jumpKeys = { KeyCode.Space};
    public KeyCode[] JumpKeys => jumpKeys;

    [Header("Attack")]
    [SerializeField] private KeyCode[] attackKeys = { KeyCode.J, KeyCode.Mouse0 };
    public KeyCode[] AttackKeys => attackKeys;

    [SerializeField] private KeyCode[] upKeys = {KeyCode.W, KeyCode.UpArrow };
    public KeyCode[] UpKeys => upKeys;

    [SerializeField] private KeyCode[] downKeys = { KeyCode.S, KeyCode.DownArrow };
    public KeyCode[] DownKeys => downKeys;

    [SerializeField] private int attackDamage = 1;
    public int AttackDamage => attackDamage;

    [SerializeField] private Vector2 attackSize = new Vector2(1.6f, 0.6f);
    public Vector2 AttackSize => attackSize;

    [SerializeField] private float attackCoolDown = 0.35f;
    public float AttackCoolDown => attackCoolDown;

    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth => maxHealth;

    [SerializeField] private float invulnerabilityDuration = 1f;
    public float InvulnerabilityDuration => invulnerabilityDuration;

    [SerializeField] private float blinkInterval = 0.1f;
    public float BlinkInterval => blinkInterval;

    [SerializeField] private Vector2 knockBackForce = new Vector2(6f, 4f);
    public Vector2 KnockBackForce => knockBackForce;

    [SerializeField] private float knockBackDuration = 0.2f;
    public float KnockBackDuration => knockBackDuration;

}

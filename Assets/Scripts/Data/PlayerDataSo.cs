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
    [SerializeField] private KeyCode[] jumpKeys = { KeyCode.Space, KeyCode.W, KeyCode.UpArrow };
    public KeyCode[] JumpKeys => jumpKeys;

}

using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyDataSo : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth => maxHealth;

    [SerializeField] private GameObject deathVfx;
    public GameObject DeathVfx => deathVfx;

    [Header("Rewards")]

    [SerializeField] private int score = 100;
    public int Score => score;

    [SerializeField] private int lootMin = 1;
    public int LootMin => lootMin;

    [SerializeField] private int lootMax = 3;
    public int LootMax => lootMax;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1.0f;
    public float MoveSpeed => moveSpeed;

}

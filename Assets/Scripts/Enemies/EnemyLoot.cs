using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private EnemyDataSo enemyData;

    private void OnEnable()
    {
        enemyHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        enemyHealth.OnDied -= HandleDied;
    }

    private void HandleDied()
    {
        int lootCount = Random.Range(enemyData.LootMin, enemyData.LootMax+1);
        for (int i = 0; i < lootCount; i++)
        {
            Vector2 offset = Random.insideUnitCircle * enemyData.LootSpread;
            offset.y = Mathf.Abs(offset.y);
            Vector3 spawnPosition = transform.position + (Vector3) offset;
            Instantiate(enemyData.LootPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

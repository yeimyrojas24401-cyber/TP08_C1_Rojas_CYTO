using UnityEngine;
using System.Collections;

public class ToxicCocci : MonoBehaviour
{
    [SerializeField] private EnemyDataSo toxicCocciData;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform visual;
    [SerializeField] private Transform firePoint;

    private bool isShooting;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = visual.localScale;
    }
    private void Update()
    {
        if (isShooting)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, toxicCocciData.DangerRange, playerLayer);
        if (hit == null)
            return;
        StartCoroutine(ShootRoutine(hit.transform));
    }
    private IEnumerator ShootRoutine(Transform target)
    {
        isShooting = true;
        visual.localScale = originalScale * toxicCocciData.InflateSize;
        yield return new WaitForSeconds(toxicCocciData.WindUpTime);
        Vector2 direction = ((Vector2)target.position - (Vector2)firePoint.position).normalized;
        Debug.Log("Disparo hacia " + direction);
        visual.localScale = originalScale;
        yield return new WaitForSeconds(toxicCocciData.TimeBetweenShoots);
        isShooting =false;
    }
    private void OnDrawGizmosSelected()
    {
        if (toxicCocciData == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, toxicCocciData.DangerRange);
    }
}

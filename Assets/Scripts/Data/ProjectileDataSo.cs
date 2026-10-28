using UnityEngine;
[CreateAssetMenu(fileName = "ProjectileData", menuName = "Data/ProjectileData")]
public class ProjectileDataSo : ScriptableObject
{
    [SerializeField] private float speed = 8f;
    public float Speed => speed;
    [SerializeField] private float lifeTime = 2f;
    public float LifeTime => lifeTime;
    [SerializeField] private int damage = 1;
    public int Damage => damage;
    [SerializeField] private LayerMask hitLayer;
    public LayerMask HitLayer => hitLayer;
    [SerializeField] private GameObject hitVfx;
    public GameObject HitVfx => hitVfx;

}

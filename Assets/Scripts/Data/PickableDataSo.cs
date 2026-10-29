using UnityEngine;
[CreateAssetMenu(fileName = "PickableData", menuName = "Data/PickableData")]
public class PickableDataSo : ScriptableObject
{
    [SerializeField] private int amount = 1;
    public int Amount => amount;

    [SerializeField] private GameObject pickupParticles;
    public GameObject PickupParticles => pickupParticles;
    [SerializeField] private AudioClip pickupClip;
    public AudioClip PickupClip => pickupClip;
}

using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "RunProgressData", menuName = "Data/RunProgressData")]
public class RunProgressSo : ScriptableObject
{
    [SerializeField] private int currentAminoacid;
    public int CurrentAminoacid => currentAminoacid;

    public event UnityAction<int> OnAminoacidChanged;
    public void AddAminoacid(int aminoacid)
    {
        currentAminoacid += aminoacid;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);

    }

    public void ResetAminoacid()
    {
        currentAminoacid = 0;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);
    }

    //M15 mover al GameManager
}

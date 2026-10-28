using UnityEngine;
using UnityEngine.UI;

public class UIAtpOrb : MonoBehaviour
{
    [SerializeField] private PlayerEnergy playerEnergy;
    [SerializeField] private Image imageOrb;

    private void OnEnable()
    {
        playerEnergy.OnAtpChanged += HandleFillOrb;
    }
    private void OnDisable()
    {
        playerEnergy.OnAtpChanged -= HandleFillOrb;
    }
    
    private void HandleFillOrb(float currentAtp, float maxAtp)
    {
        imageOrb.fillAmount = currentAtp/maxAtp;
    }
}

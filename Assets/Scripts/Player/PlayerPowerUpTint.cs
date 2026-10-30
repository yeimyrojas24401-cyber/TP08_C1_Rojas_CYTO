using UnityEngine;

public class PlayerPowerUpTint : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerPowerUps playerPowerUps;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Update()
    {
        if (playerPowerUps.IsShielded)
        {
            spriteRenderer.color = playerData.ShieldColor;
            return;
        }
        if(playerPowerUps.IsDamageBoosted)
        {
            spriteRenderer.color = playerData.DamageBoostColor;
            return;
        }
        if(playerPowerUps.HasExtraJump)
        {
            spriteRenderer.color = playerData.ExtraJumpColor;
            return;
        }
        spriteRenderer.color = Color.white;

    }
}

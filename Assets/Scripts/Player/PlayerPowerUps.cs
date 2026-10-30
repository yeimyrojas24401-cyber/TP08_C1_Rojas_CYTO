using UnityEngine;

public class PlayerPowerUps : MonoBehaviour
{
    private TimedEffect damageBoost = new TimedEffect();
    public TimedEffect DamageBoost => damageBoost;
    private TimedEffect shield = new TimedEffect();
    public TimedEffect Shield => shield;
    private TimedEffect extraJump = new TimedEffect();
    public TimedEffect ExtraJump => extraJump;

    public bool IsDamageBoosted => damageBoost.IsActive;
    public bool IsShielded => shield.IsActive;
    public bool HasExtraJump => extraJump.IsActive;

    private void Start()
    {
        Activate(PowerUpType.DamageBoost, 3);
    }
    private void Update()
    {
        damageBoost.Tick(Time.deltaTime);
        shield.Tick(Time.deltaTime);
        extraJump.Tick(Time.deltaTime);
        Debug.Log(damageBoost.TimeRemain);
    }

    public void Activate(PowerUpType type, float duration)
    {
        switch (type)
        {
            case PowerUpType.DamageBoost:
                damageBoost.Activate(duration);
                break;
            case PowerUpType.Shield:
                shield.Activate(duration);
                break;
            case PowerUpType.ExtraJump:
                extraJump.Activate(duration);
                break;
        }

    }
}

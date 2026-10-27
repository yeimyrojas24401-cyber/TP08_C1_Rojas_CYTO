using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Image fill;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += HandleHealthChanged;
    }
    
    private void OnDisable()
    {
        if(enemyHealth != null)
        {
        enemyHealth.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void HandleHealthChanged(int amount)
    {
        fill.fillAmount = (float)amount / enemyHealth.MaxHealth;
    }
}

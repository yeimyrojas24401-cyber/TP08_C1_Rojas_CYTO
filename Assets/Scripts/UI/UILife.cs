using UnityEngine;

public class UILife : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private GameObject[] lifeIcons;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += HandleActiveIcons;
    }
    
    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= HandleActiveIcons;
    }

    private void HandleActiveIcons(int currentHealth)
    {
        for(int i = 0; i < lifeIcons.Length; i++)
        {
            lifeIcons[i].SetActive(i < currentHealth);
        }
    }
}

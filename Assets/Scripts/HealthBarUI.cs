using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image fillImage;
    [SerializeField] private Image healthFill;

    public void SetHealth(float percent) {
        healthFill.fillAmount = percent; 
    }

    private void Start()
    {
        UpdateBar();

        healthSystem.OnDamaged += UpdateBar;
        healthSystem.OnDied += UpdateBar;
    }

    private void UpdateBar()
    {
        float normalizedHealth = (float)healthSystem.CurrentHealth / healthSystem.MaxHealth;
        fillImage.fillAmount = normalizedHealth;
    }
}

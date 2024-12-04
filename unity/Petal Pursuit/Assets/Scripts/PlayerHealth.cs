using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth = 100f;
    public LoadSceneByIndex sceneman;
    public Image healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        healthBar.fillAmount = currentHealth / maxHealth;

        // You can add hit effects or animations here

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // You can add death effects or animations here
        Debug.Log("Player died!");
        sceneman.LoadScene(7);

        // Instead of destroying, you might want to handle player death differently
        // like restarting the level or showing a game over screen
    }
}

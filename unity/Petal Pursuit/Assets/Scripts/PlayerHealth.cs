using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        // Instead of destroying, you might want to handle player death differently
        // like restarting the level or showing a game over screen
    }
}

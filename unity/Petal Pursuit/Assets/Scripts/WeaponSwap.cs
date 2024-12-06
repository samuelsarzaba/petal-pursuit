using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    [Header("Weapon Settings")]
    [SerializeField] private GameObject weaponIndicator; // Box indicator for current weapon
    [SerializeField] private SpriteRenderer weaponSpriteRenderer;
    [SerializeField] private Sprite shovelSprite;
    [SerializeField] private Sprite swordSprite;
    [SerializeField] private float attackRange = 1f; // Range for weapon attacks
    [SerializeField] private float attackCooldown = 0.5f; // Cooldown duration between attacks

    private bool isShovelActive = false;
    private bool isSwordActive = false;
    private float weaponDamage = 20f;
    private FlowerManager flowerManager;
    private float lastAttackTime = 0f; // Track the last attack time

    void Start()
    {
        // Initialize weapon sprite
        if (weaponSpriteRenderer == null)
            weaponSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        // Get reference to FlowerManager
        flowerManager = FindObjectOfType<FlowerManager>();

        UpdateWeaponVisuals();
    }

    void Update()
    {
        // Check for weapon activation input
        if (Input.GetKey(KeyCode.C)) // C to toggle weapons
        {
            ToggleWeapon();
        }

        // Check for attack input and handle range-based attacks
        if (Input.GetMouseButton(0)) // Left click to attack with weapon
        {
            // Check if enough time has passed since last attack
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                if (isSwordActive)
                {
                    CheckForEnemiesInRange();
                    lastAttackTime = Time.time; // Update last attack time
                }
                else if (isShovelActive)
                {
                    CheckForFlowersInRange();
                    lastAttackTime = Time.time; // Update last attack time
                }
            }
        }
    }

    private void CheckForEnemiesInRange()
    {
        // Get all colliders within the attack range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        // Create a list to store valid enemy targets
        List<Enemy> validEnemies = new List<Enemy>();

        // Collect all valid enemies within range
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    validEnemies.Add(enemy);
                }
            }
        }

        // If we found any valid enemies, randomly select and damage one
        if (validEnemies.Count > 0)
        {
            int randomIndex = Random.Range(0, validEnemies.Count);
            Enemy selectedEnemy = validEnemies[randomIndex];
            selectedEnemy.TakeDamage((int)GetWeaponDamage());
        }
    }

    private void CheckForFlowersInRange()
    {
        // Get all colliders within the attack range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D collider in hitColliders)
        {
            // Check if the collider has one of the flower tags
            if (collider.CompareTag("Rare") || collider.CompareTag("Common") || collider.CompareTag("Uncommon"))
            {
                // Log the collection
                Debug.Log($"Harvesting {collider.tag} flower!");

                // Call FlowerManager to collect the flower
                if (flowerManager != null)
                {
                    flowerManager.CollectFlower(collider.gameObject);
                }

                // Destroy the flower object
                Destroy(collider.gameObject);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the attack range in the editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void ToggleWeapon()
    {
        if (!isShovelActive && !isSwordActive)
        {
            isShovelActive = true;
        }
        else if (isShovelActive)
        {
            isShovelActive = false;
            isSwordActive = true;
        }
        else if (isSwordActive)
        {
            isSwordActive = false;
        }
        UpdateWeaponVisuals();
    }

    private void UpdateWeaponVisuals()
    {
        if (weaponSpriteRenderer != null)
        {
            if (isShovelActive && shovelSprite != null)
            {
                weaponSpriteRenderer.sprite = shovelSprite;
            }
            else if (isSwordActive && swordSprite != null)
            {
                weaponSpriteRenderer.sprite = swordSprite;
            }
            else
            {
                weaponSpriteRenderer.sprite = null;
            }
        }

        if (weaponIndicator != null)
        {
            weaponIndicator.SetActive(isShovelActive || isSwordActive);
        }
    }

    public float GetWeaponDamage()
    {
        return (isShovelActive || isSwordActive) ? weaponDamage : 0f;
    }

    public bool IsShovelActive()
    {
        return isShovelActive;
    }

    public bool IsSwordActive()
    {
        return isSwordActive;
    }
}

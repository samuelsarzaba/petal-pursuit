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
    
    private bool isShovelActive = false;
    private bool isSwordActive = false;
    private float weaponDamage = 20f;

    void Start()
    {
        // Initialize weapon sprite
        if (weaponSpriteRenderer == null)
            weaponSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
            
        UpdateWeaponVisuals();
    }

    void Update()
    {
        // Check for weapon activation input
        if (Input.GetMouseButtonDown(1)) // Right click to toggle weapons
        {
            ToggleWeapon();
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && Input.GetMouseButton(0) && (isShovelActive || isSwordActive)) // Left click to attack with weapon
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage((int)GetWeaponDamage());
            }
        }
    }
}

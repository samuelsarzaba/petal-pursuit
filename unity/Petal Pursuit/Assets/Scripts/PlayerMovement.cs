using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private WeaponSwap weaponSwap;
    
    float vertical;
    float horizontal;

    public float speedLimit;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        weaponSwap = GetComponent<WeaponSwap>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        UpdateAnimator();
    }

    void HandleMovementInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void UpdateAnimator()
    {
        // Update movement parameters
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

        // Update tool/sword parameters based on WeaponSwap state
        animator.SetBool("IsHoldingTool", weaponSwap.IsShovelActive());
        animator.SetBool("IsHoldingSword", weaponSwap.IsSwordActive());
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= speedLimit;
            vertical *= speedLimit;
        }

        // Move the character
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

 /*   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            Destroy(other.gameObject);
            cm.collectibleCount++;
        }
    } */
}

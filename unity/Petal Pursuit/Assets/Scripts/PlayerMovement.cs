using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    
    float vertical;
    float horizontal;

    public float speedLimit;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Update animator parameters
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
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

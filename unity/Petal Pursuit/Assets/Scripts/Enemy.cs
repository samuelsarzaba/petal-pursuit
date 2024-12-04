using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float wanderSpeed = 2f;
    [SerializeField] private float chaseSpeed = 4f;
    [SerializeField] private float randomMovementInterval = 2f;

    [Header("Combat")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float attackCooldown = 1f;

    private int currentHealth;
    private float lastAttackTime;
    private Vector2 randomDirection;
    private float nextDirectionChange;
    private Transform player;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
        SetNewRandomDirection();
    }

    private void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            ChasePlayer();
        }
        else
        {
            Wander();
        }
    }

    private void Wander()
    {
        if (Time.time >= nextDirectionChange)
        {
            SetNewRandomDirection();
        }

        rb.velocity = randomDirection * wanderSpeed;
    }

    private void SetNewRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        randomDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), 
                                    Mathf.Sin(randomAngle * Mathf.Deg2Rad));
        nextDirectionChange = Time.time + randomMovementInterval;
    }

    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * chaseSpeed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TryDamagePlayer(collision.gameObject);
        }
    }

    private void TryDamagePlayer(GameObject player)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastAttackTime = Time.time;
                Debug.Log("damage");
            }
        }
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
        Destroy(gameObject);
    }

    // Optional: Visualize the detection range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}

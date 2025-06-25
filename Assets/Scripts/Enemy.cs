using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Transform[] patrolPoints;
    public float detectionRadius = 5f;
    
    private int currentPatrolIndex = 0;
    private Transform target;
    private Transform player;
    private bool chasingPlayer = false;
    
    public int damage = 10;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player с тегом 'Player' не найден в сцене!");
        }

        if (patrolPoints.Length > 0)
        {
            target = patrolPoints[currentPatrolIndex];
        }
        else
        {
            Debug.LogError("Не заданы patrolPoints для врага.");
        }
    }


    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            chasingPlayer = true;
        }
        else
        {
            chasingPlayer = false;
        }

        if (chasingPlayer)
        {
            MoveTo(player.position);

            // Атака, якщо достатньо близько
            if (distanceToPlayer < 1f) // Радіус атаки (можеш змінити)
            {
                TryAttackPlayer();
            }
        }
        else
        {
            Patrol();
        }
    }
    
    private void TryAttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            // Знайди компонент HealthSystem у гравця
            HealthSystem playerHealth = player.GetComponent<HealthSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }

            // Анімація атаки (якщо скелет має аніматор)
            GetComponent<SkeletonVisual>()?.PlayAttack();
        }
    }

    private void MoveTo(Vector3 destination)
    {
        Vector3 direction = (destination - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void Patrol()
    {
        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            target = patrolPoints[currentPatrolIndex];
        }

        MoveTo(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        // Визуализация радиуса обнаружения
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}


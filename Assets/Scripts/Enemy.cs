using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    [Header("Ranges")]
    public float seeRange = 10f;
    public float attackRange = 1.5f;

    [Header("Combat")]
    public float attackCooldown = 1f;
    public int damage = 30;

    private float lastAttackTime;

    void Awake()
    {
        // Get player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found!");
        }

        // Get NavMeshAgent
        agent = GetComponent<NavMeshAgent>();

        // Stop before colliding with player
        agent.stoppingDistance = attackRange;

        // Let NavMesh handle rotation
        agent.updateRotation = true;
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Player too far away = idle
        if (distance > seeRange)
        {
            agent.ResetPath();
            return;
        }

        // Chase player until attack range
        if (distance > attackRange)
        {
            if (!agent.pathPending)
            {
                agent.SetDestination(player.position);
            }
        }
        // Attack when close enough
        else
        {
            agent.ResetPath();

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
    }

    void Attack()
    {
        Health health = player.GetComponent<Health>();

        if (health != null)
        {
            health.HurtPlayer(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
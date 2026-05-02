using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public float seeRange = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1f;

    private float lastAttackTime = 0f;

    void Awake()
    {
        GameObject playerob = GameObject.FindGameObjectWithTag("Player");
        player = playerob.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= seeRange)
        {
            //Debug.Log("Distance & Set Dest Player");
            agent.SetDestination(player.position);

            if (distance <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                Attack();
                //Debug.Log("Attack");
                lastAttackTime = Time.time;
            }
        }
        else
        {
            //Debug.Log("Idle");
            agent.SetDestination(transform.position); // idle
        }
    }

    void Attack()
    {
        player.GetComponent<Health>().HurtPlayer(30);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, seeRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

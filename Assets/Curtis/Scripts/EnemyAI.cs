using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;
    public Transform PatrollingA;
    public Transform PatrollingB;
    public float health;

    //Patrolling
    private Vector3 walkPoint1;
    private Vector3 walkPoint2;
    public float walkPointRange = 5f;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }


    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }

        else
        {
            Patrolling();
        }

        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        SearchWalkPoint();
        //if (!walkPointSet)
        //{
        //    SearchWalkPoint();
        //}

        //if (walkPointSet)
        //{
        //    agent.SetDestination(walkPoint1);
        //}
        
        //Point Reached
        if (Vector3.Distance(transform.position, walkPoint1) < 1f)
        {
            agent.SetDestination(walkPoint2);

        }
        if (Vector3.Distance(transform.position,walkPoint2) < 1f)
        {
            agent.SetDestination(walkPoint1);
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint1 = new Vector3(PatrollingA.transform.position.x, PatrollingA.transform.position.y, PatrollingA.transform.position.z);
        walkPoint2 = new Vector3(PatrollingB.transform.position.x, PatrollingB.transform.position.y, PatrollingB.transform.position.z);
        //if (Physics.Raycast(walkPoint1, -transform.up, 2f, whatIsGround))
        //{
        //    walkPointSet = true;
        //}
        //if (Physics.Raycast(walkPoint2, -transform.up, 2f, whatIsGround))
        //{
        //    walkPointSet = false;
        //}
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(PatrollingA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PatrollingB.transform.position, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(walkPoint1, 0.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(walkPoint2, 0.5f);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
            rb.AddForce(transform.up * 2f, ForceMode.Impulse);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestoryEnemy), 0.5f);
        }
    }

    private void DestoryEnemy()
    {
        Destroy(gameObject);
    }
}

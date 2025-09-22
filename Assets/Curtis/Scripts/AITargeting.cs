using UnityEngine;
using UnityEngine.AI;

public class AITargeting : MonoBehaviour
{
    public Transform Target;
    public Transform patrolA;
    public Transform patrolB;
    public float AttackDistance;

    private NavMeshAgent m_agent;
    private float patrolDistanceA;
    private float patrolDistanceB;
    private Animator m_animator;
    private float m_Distance;
    public Transform PatrolPoint;
    void Start()
    {
        m_agent.SetDestination(patrolA.position);
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
    }

    void Update()
    {
        m_Distance = Vector3.Distance(m_agent.transform.position, Target.position);
        patrolDistanceA = Vector3.Distance(m_agent.transform.position, patrolA.position);
        patrolDistanceB = Vector3.Distance(m_agent.transform.position, patrolB.position);
        //if (m_Distance < AttackDistance )
        //{
        //    m_agent.isStopped = true;
        //    m_animator.SetBool("Attack", true);
        //}

        //else
        //{
            m_agent.isStopped = false;
            m_animator.SetBool("attack", false) ;
            if(m_Distance > 5 ) 
            {
                if (patrolDistanceB < 1)
                m_agent.SetDestination(patrolA.position);
                if (patrolDistanceA < 1)
                    m_agent.SetDestination(patrolB.position);
            }
            if (m_Distance < 5) 
            {
                m_agent.SetDestination(Target.position);

            }
            //if (m_Distance < AttackDistance)
            //{
            //    m_agent.destination = Target.position;
            //}
        //}
    }

    private void OnAnimatorMove()
    {
        if(m_animator.GetBool("Attack") == false)
        {
            m_agent.speed = (m_animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }
}

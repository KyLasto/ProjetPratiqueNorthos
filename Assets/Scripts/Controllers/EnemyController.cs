using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    
    public float m_LookRadius = 10f;

    Transform m_Target;
    NavMeshAgent m_Agent;
    CharacterCombat m_Combat;

    // Start is called before the first frame update
    void Start()
    {
        m_Target = PlayerManager.m_Instance.m_Player.transform;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Combat = GetComponent<CharacterCombat>();
    }

    void Update()
    {
        float m_Distance = Vector3.Distance(m_Target.position, transform.position);

        if (m_Distance <= m_LookRadius)
        {
            m_Agent.SetDestination(m_Target.position);

            if (m_Distance <= m_Agent.stoppingDistance)
            {
                CharacterStats m_TargetStats = m_Target.GetComponent<CharacterStats>();
                if (m_TargetStats != null)
                {
                    m_Combat.Attack(m_TargetStats);
                }
                
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 m_Direction = (m_Target.position - transform.position).normalized;
        Quaternion m_LookRotation = Quaternion.LookRotation(new Vector3(m_Direction.x, 0, m_Direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, m_LookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_LookRadius);
    }
}

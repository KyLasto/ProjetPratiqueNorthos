using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class EnemyAi : MonoBehaviour
{
   public float m_Health;
   
   public NavMeshAgent m_Agent;
   public Transform m_Player;
   public LayerMask m_WhatIsGround, m_WhatIsPlayer;
   
   
   //Patrolling
   public Vector3 m_WalkPoint;
   bool m_WalkPointSet;
   public float m_WalkPointRange;
   
   //Attacking
   public float m_TimeBetweenAttacks;
   bool m_AlreadyAttacked;
   
   //States
   public float m_SightRange, m_AttackRange;
   public bool m_InSightRange, m_InAttackRange;

   private void Update()
   {
      m_InSightRange = Physics.CheckSphere(transform.position, m_SightRange, m_WhatIsPlayer);
      m_InAttackRange = Physics.CheckSphere(transform.position, m_AttackRange, m_WhatIsPlayer);

      if (!m_InSightRange && !m_InAttackRange)
      {
         Patroling();
      }

      if (m_InSightRange && !m_InAttackRange)
      {
         ChasingPlayer();
      }
      
      if (m_InSightRange && m_InAttackRange)
      {
         Attacking();
      }
   }

   private void Awake()
   {
      m_Player = GameObject.Find("Player").transform;
      m_Agent = GetComponent<NavMeshAgent>();
   }

   private void Patroling()
   {
      if (!m_WalkPointSet) 
         SearchWalkPoint();

      if (m_WalkPointSet) 
         m_Agent.SetDestination(m_WalkPoint);
      
      Vector3 m_DistanceToWalkPoint = transform.position - m_WalkPoint;

      if (m_DistanceToWalkPoint.magnitude < 1f)
      {
         m_WalkPointSet = false;
      }
   }

   private void SearchWalkPoint()
   {
      float randomZ = Random.Range(-m_WalkPointRange, m_WalkPointRange);
      float randomX = Random.Range(-m_WalkPointRange, m_WalkPointRange);

      m_WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

      if (Physics.Raycast(m_WalkPoint, -transform.up, 2f, m_WhatIsGround))
      {
         m_WalkPointSet = true;
      }

   }

   private void ChasingPlayer()
   {
      m_Agent.SetDestination(m_Player.position);
   }
   
   private void Attacking()
   {
      m_Agent.SetDestination(transform.position);
      
      transform.LookAt(m_Player);

      if (!m_AlreadyAttacked)
      {
         //Attack code
         
         m_AlreadyAttacked = true;
         Invoke(nameof(ResetAttack), m_TimeBetweenAttacks);
      }
   }

   private void ResetAttack()
   {
      m_AlreadyAttacked = false;
   }

   public void TakeDamage(int m_Damage)
   {
      m_Health -= m_Damage;

      if (m_Health <= 0)
      {
         Invoke(nameof(DestroyEnemy), .5f);
      }
   }

   private void DestroyEnemy()
   {
      Destroy(gameObject);
   }
}

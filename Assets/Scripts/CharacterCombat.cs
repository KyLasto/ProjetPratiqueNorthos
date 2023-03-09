using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    public float m_AttackSpeed = 1f;
    private float m_AttackCooldown = 0f;

    public float m_AttackDelay = .6f;

    public event System.Action m_OnAttack;

    CharacterStats m_MyStats;

    public void Start()
    {
        m_MyStats = GetComponent<CharacterStats>();
    }

    void Update()
    {
        m_AttackCooldown -= Time.deltaTime;
    }

    public void Attack(CharacterStats m_TargetStats)
    {
        if (m_AttackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(m_TargetStats, m_AttackDelay));

            m_OnAttack?.Invoke();

            m_AttackCooldown = 1f / m_AttackSpeed;
        }
    }

    IEnumerator DoDamage(CharacterStats m_Stats, float m_Delay)
    {
        yield return new WaitForSeconds(m_Delay);

        m_Stats.TakeDamage(m_MyStats.m_Damage.GetValue());
    }
}

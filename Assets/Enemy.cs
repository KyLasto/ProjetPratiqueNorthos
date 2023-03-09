using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager m_PlayerManager;
    CharacterStats m_MyStats;

    void Start()
    {
        m_PlayerManager = PlayerManager.m_Instance;
        m_MyStats = GetComponent<CharacterStats>();
    }
    public override void Interact()
    {
        base.Interact();
        CharacterCombat m_PlayerCombat = m_PlayerManager.m_Player.GetComponent<CharacterCombat>();
        if (m_PlayerCombat != null)
        {
            m_PlayerCombat.Attack(m_MyStats);
        }
    }
}

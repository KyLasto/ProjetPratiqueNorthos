using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentManager.m_Instance.m_OnEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment m_NewItem, Equipment m_OldItem)
    {
        if (m_NewItem != null)
        {
            m_Armour.AddModifier(m_NewItem.m_ArmourModifier);
            m_Damage.AddModifier(m_NewItem.m_DamageModifier);
        }

        if (m_OldItem != null)
        {
            m_Armour.RemoveModifier(m_OldItem.m_ArmourModifier);
            m_Damage.RemoveModifier(m_OldItem.m_DamageModifier);
        }
    }

    public override void Die()
    {
        base.Die();
        PlayerManager.m_Instance.KillPlayer();
    }
}

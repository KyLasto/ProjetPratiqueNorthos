using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item
{
    public EquipmentSlot m_EquipSlot;

    public int m_ArmourModifier;
    public int m_DamageModifier;

    public override void Use()
    {
        base.Use();
        EquipmentManager.m_Instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EquipmentSlot 
{
    Head,
    Chest,
    Legs,
    Weapon,
    Shield,
    Boots
}

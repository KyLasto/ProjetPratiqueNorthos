using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton
    public static EquipmentManager m_Instance;

    private void Awake()
    {
        m_Instance = this;
    }

    #endregion

    Equipment[] m_CurrentEquipment;

    public delegate void OnEquipmentChanged(Equipment m_NewItem, Equipment m_OldItem);
    public OnEquipmentChanged m_OnEquipmentChanged;

    Inventory m_Inventory;

    void Start()
    {
        m_Inventory = Inventory.m_Instance;
        
        int m_NumSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length; // Nombre d'elements dans l'enum
        m_CurrentEquipment = new Equipment[m_NumSlots];


    }

    public void Equip(Equipment newItem)
    {
        int m_SlotIndex = (int)newItem.m_EquipSlot;

        Equipment m_OldItem = null;

        if (m_CurrentEquipment[m_SlotIndex] != null)
        {
            m_OldItem = m_CurrentEquipment[m_SlotIndex];
            m_Inventory.Add(m_OldItem);
        }

        if (m_OnEquipmentChanged != null)
        {
            m_OnEquipmentChanged.Invoke(newItem, m_OldItem);
        }

        m_CurrentEquipment[m_SlotIndex] = newItem;
    }

    public void Unequip(int m_SlotIndex)
    {
        if (m_CurrentEquipment[m_SlotIndex] != null)
        {
            Equipment m_OldItem = m_CurrentEquipment[m_SlotIndex];
            m_Inventory.Add(m_OldItem);

            m_CurrentEquipment[m_SlotIndex] = null;

            if (m_OnEquipmentChanged != null)
            {
                m_OnEquipmentChanged.Invoke(null, m_OldItem);
            }
        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < m_CurrentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            UnequipAll();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private int m_BaseValue; // Starting value for the given stat

    private List<int> m_Modifiers = new List<int>();

    public int GetValue()
    {
        int m_FinalValue = m_BaseValue;
        m_Modifiers.ForEach(x => m_FinalValue += x);
        return m_FinalValue;
    }

    public void AddModifier (int m_Modifier)
    {
        if (m_Modifier != 0)
        {
            m_Modifiers.Add(m_Modifier);
        }
    }

    public void RemoveModifier(int m_Modifier)
    {
        if (m_Modifier != 0)
        {
            m_Modifiers.Remove(m_Modifier);
        }
    }
}

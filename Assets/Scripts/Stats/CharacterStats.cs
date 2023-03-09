using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    public int m_MaxHealth = 100;
    public int m_CurrentHealth { get; private set; }

    public Stat m_Damage;
    public Stat m_Armour;

    void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int m_Damage)
    {
        m_Damage -= m_Armour.GetValue(); // -5 damage every hit instead of -10
        m_Damage = Mathf.Clamp(m_Damage, 0, int.MaxValue);

        m_CurrentHealth -= m_Damage;
        Debug.Log(transform.name + " takes " + m_Damage + " damage.");

        if (m_CurrentHealth <= 0)
        { 
            //Die(); 
        }
    }

    public virtual void Die()
    {
        //Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }


}

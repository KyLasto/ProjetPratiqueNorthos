using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Inventory : MonoBehaviour
{

    #region Singleton


    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
            instance = this;
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void IsStarterAxe()
    {
        Item StarterAxe = items.Find(x => x.name == "Starter Axe"); 
        
        if (StarterAxe != null)
        {
            StarterAxe.Use();
        }
    }

    public void IsStarterPickaxe()
    {
        Item StarterPickaxe = items.Find(x => x.name == "Starter Pickaxe");

        if (StarterPickaxe != null)
        {
            StarterPickaxe.Use();
        }
    }

    public void IsStarterDagger()
    {
        Item StarterDagger = items.Find(x => x.name == "Starter Dagger");

        if (StarterDagger != null)
        {
            StarterDagger.Use();
        }
    }
}

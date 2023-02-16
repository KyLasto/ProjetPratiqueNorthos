using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

[System.Serializable]
public class Level
{
    public int experience;
    public int currentLevel;
    public Action onLevelUp;

    public int MAX_EXP;
    public int MAX_LEVEL = 130;
    
    public Level(int level, Action levelUp)
    {
        MAX_EXP = GetXpForLevel(MAX_LEVEL);
        currentLevel = level;
        experience = GetXpForLevel(level);
        onLevelUp = levelUp;
    }

    public int GetXpForLevel(int level)
    {
        if (level > MAX_LEVEL) 
            return 0;
        
        int firstPass = 0;
        int secondPass = 0;
        for (int levelCycle = 1; levelCycle < level; levelCycle++)
        {
            firstPass += (int) Math.Floor(levelCycle + (300.0f * Math.Pow(2.0f, levelCycle / 7.0f)));
            secondPass = firstPass / 4;
        }

        if (secondPass > MAX_EXP && MAX_EXP != 0) 
            return MAX_EXP;

        if (secondPass < 0) 
            return MAX_EXP;
        
        return secondPass;
    }

    public int GetLevelForXp(int exp)
    {
        if (exp > MAX_EXP)
            return MAX_EXP;
        
        int firstPass = 0;
        int secondPass = 0;
        for (int levelCycle = 1; levelCycle <= MAX_EXP; levelCycle++)
        {
            firstPass += (int) Math.Floor(levelCycle + (300.0f * Math.Pow(2.0f, levelCycle / 7.0f)));
            secondPass = firstPass / 4;
            if (secondPass > exp)
                return levelCycle;
        }

        if (exp > secondPass)
            return MAX_LEVEL;
        return 0; // Todo : Throw an exception dependant of game design
    }

    public bool AddExp(int amount)
    {
        if (amount + experience < 0 || experience > MAX_EXP)
        {
            if (experience > MAX_EXP)
                experience = MAX_EXP;
            return false;
        }

        int oldLevel = GetLevelForXp(experience);
        experience += amount;
        if (oldLevel < GetLevelForXp(experience))
        {
            if (currentLevel < GetLevelForXp(experience))
            {
                currentLevel = GetLevelForXp(experience);
                if (onLevelUp != null)
                    onLevelUp.Invoke();
                return true;

            }
        }
        return false;
    }
}

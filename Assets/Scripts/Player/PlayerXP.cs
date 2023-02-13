using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public Level level;
    void Start()
    {
        level = new Level(1, OnLevelUp);
    }

    public void OnLevelUp()
    {
        print("levelUp");
        int oldEXP = level.experience;
        int newexp = level.GetXpForLevel(level.currentLevel);
        level.experience = 0;
        level.experience = (oldEXP - newexp);
    }
    void Update()
    {
        //level.AddExp()
    }
}

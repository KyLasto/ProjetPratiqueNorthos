using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerXP : MonoBehaviour
{
    public Level combat_level;
    public Level attack;
    public Level strength;
    public Level defence;
    public Level woodcutting;
    public Level mining;
    public Level fishing;
    void Start()
    {
        combat_level = new Level(1, OnLevelUp);
        attack = new Level(1, OnLevelUp);
        strength = new Level(1, OnLevelUp);
        defence = new Level(1, OnLevelUp);
        woodcutting = new Level(1, OnLevelUp);
        mining = new Level(1, OnLevelUp);
        fishing = new Level(1, OnLevelUp);
    }

    public void OnLevelUp()
    {
        print("levelUp");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            combat_level.AddExp(100);
        }

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToolsScript : MonoBehaviour {
    public static EnemyToolsScript tools;

    public int TRASH_EXP = 15;
    public int MODERATE_EXP = 50;
    public int THICC_EXP = 100;

    
    public GameObject ShadowAssassin_Prefab;
    public GameObject Skitter_Prefab;
    public GameObject DragonLord_Prefab;

    // Use this for initialization
    void Awake()
    {
        if (tools == null)
        {
            tools = this;
        }
        else if (tools != this)
        {
            Destroy(gameObject);
        }
    }

    public EnemyInfo LookUpEnemy(string name)
    {
        EnemyInfo enemyInfo = new EnemyInfo();

        switch (name)
        {
            case "Shadow Assassin":
                enemyInfo.enemyImageSource = "Animations\\NPCs\\zed_idle01";
                enemyInfo.enemyPrefab = ShadowAssassin_Prefab;
                enemyInfo.enemyLevel = 1;
                enemyInfo.expReward = MODERATE_EXP;
                enemyInfo.ability_1 = "Outrage";
                enemyInfo.ability_2 = "Shadow Clone";
                enemyInfo.ability_3 = "Reap";
                enemyInfo.ability_4 = "Final Cut";

                enemyInfo.enemyName = "Shadow Assassin";
                enemyInfo.enemyAttack = 5;
                enemyInfo.enemyDefense = 2;
                enemyInfo.enemySpeed = 2;
                enemyInfo.enemyMaxHealthBase = 60;
                break;
            case "Skitter":
                enemyInfo.enemyImageSource = "Animations\\NPCs\\Skitter_Image";
                enemyInfo.enemyPrefab = Skitter_Prefab;
                enemyInfo.enemyLevel = 2;
                enemyInfo.expReward = TRASH_EXP;
                enemyInfo.ability_1 = "Reap";
                enemyInfo.ability_2 = "";
                enemyInfo.ability_3 = "";
                enemyInfo.ability_4 = "";

                enemyInfo.enemyName = "Skitter";
                enemyInfo.enemyAttack = 3;
                enemyInfo.enemyDefense = 4;
                enemyInfo.enemySpeed = 1;
                enemyInfo.enemyMaxHealthBase = 80;
                break;
            case "Dragon Lord":
                enemyInfo.enemyImageSource = "Animations\\NPCs\\dragonLord_0004_dragonlord-3";
                enemyInfo.enemyPrefab = DragonLord_Prefab;
                enemyInfo.enemyLevel = 5;
                enemyInfo.expReward = THICC_EXP;
                enemyInfo.ability_1 = "Solar Flare";
                enemyInfo.ability_2 = "Shadow Clone";
                enemyInfo.ability_3 = "Final Cut";
                enemyInfo.ability_4 = "Reap";

                enemyInfo.enemyName = "Dragon Lord";
                enemyInfo.enemyAttack = 3;
                enemyInfo.enemyDefense = 3;
                enemyInfo.enemySpeed = 1;
                enemyInfo.enemyMaxHealthBase = 110;
                break;
            default:
                break;
        }

        return enemyInfo;
    }
}

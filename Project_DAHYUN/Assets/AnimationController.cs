﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public void Start()
    {
        LoadCharacter();
    }

    public void FlipFlop()
    {
        foreach (SpriteRenderer sprite in this.GetComponentsInChildren<SpriteRenderer>())
        {
            sprite.flipX = !sprite.flipX;
        }
    }

    public void PlayIdleAnim()
    {
        this.transform.GetChild(6).GetComponent<SpriteRenderer>().sortingOrder = -1;

        foreach (Animator child in this.GetComponentsInChildren<Animator>())
        {
            child.SetInteger("AnimState", 0);
        }
    }

    public void PlayAttackAnim()
    {
        this.transform.GetChild(6).GetComponent<SpriteRenderer>().sortingOrder = -1;

        foreach (Animator child in this.GetComponentsInChildren<Animator>())
        {
            child.SetInteger("AnimState", 5);
        }
    }

    public void PlayWalkAnim()
    {
        this.transform.GetChild(6).GetComponent<SpriteRenderer>().sortingOrder = -5;

        foreach (Animator child in this.GetComponentsInChildren<Animator>())
        {
            child.SetInteger("AnimState", 1);
        }
    }

    public void LoadCharacter()
    {
        //head
        EquipmentInfo info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[0], GameController.controller.playerEquippedIDs[1]);
        this.transform.GetChild(0).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        if (!info.hideUnderLayer)
            this.transform.GetChild(8).GetComponent<SpriteRenderer>().enabled = true;

        //torso
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[2], GameController.controller.playerEquippedIDs[3]);
        this.transform.GetChild(1).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        if (!info.hideUnderLayer)
        {
            this.transform.GetChild(9).GetComponent<SpriteRenderer>().enabled = true;
            this.transform.GetChild(11).GetComponent<SpriteRenderer>().enabled = true;
        }

        string newStr = info.imgSourceName;
        string match = "Torso";
        string replace = "Arms";
        int mSize = 0;
        int tracker = 0;
        //Alters the form of the string to include the Arms animator with the Torso
        foreach (char c in info.imgSourceName)
        {
            if (c == match[mSize])
            {
                ++mSize;

                if (mSize == 5)
                {
                    newStr = newStr.Remove(tracker - 4, mSize);
                    newStr = newStr.Insert(tracker - 4, replace);
                    mSize = 0;
                    --tracker;
                }
            }
            else
                mSize = 0;

            ++tracker;
        }

        //sleeve
        this.transform.GetChild(7).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(newStr, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //legs
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[4], GameController.controller.playerEquippedIDs[5]);
        this.transform.GetChild(2).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //back
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[6], GameController.controller.playerEquippedIDs[7]);
        this.transform.GetChild(3).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //gloves
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[8], GameController.controller.playerEquippedIDs[9]);
        this.transform.GetChild(4).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        if (!info.hideUnderLayer)
            this.transform.GetChild(10).GetComponent<SpriteRenderer>().enabled = true;
        //shoes
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[10], GameController.controller.playerEquippedIDs[11]);
        this.transform.GetChild(5).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //weapon
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[12], GameController.controller.playerEquippedIDs[13]);
        this.transform.GetChild(6).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
        //Aura
        info = GameController.controller.GetComponent<EquipmentInfoManager>().LookUpEquipment(GameController.controller.playerEquippedIDs[14], GameController.controller.playerEquippedIDs[15]);
        this.transform.GetChild(12).GetComponent<Animator>().runtimeAnimatorController = Resources.Load(info.imgSourceName, typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
    }
}
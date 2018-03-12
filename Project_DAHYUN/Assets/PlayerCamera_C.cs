﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCamera_C : MonoBehaviour
{
    public GameObject test;
    GameObject player;
    public float xBuffer = 0.0f;
    public float yBuffer = 0.0f;
    public Vector3 playerPoint;
    public GameObject playerSpawnPoint;

    public void TakeSnapshot()
    {
        player = GameController.controller.playerObject;
        player.GetComponent<AnimationController>().FlipFlop();
        player.transform.position = playerPoint;
        Texture2D snapshot = RTImage(this.GetComponent<Camera>());
        Rect rec = new Rect(0, 0, snapshot.width, snapshot.height);
        //encode to png
        byte[] bytes = snapshot.EncodeToPNG();
        string FilePath = Application.dataPath + "/Resources/CloseUps/Character_CloseUp_Player.png";
        if (File.Exists(FilePath))
            File.WriteAllBytes(FilePath, bytes);
        player.GetComponent<AnimationController>().FlipFlop();
        player.transform.position = playerSpawnPoint.transform.position;
        //Sprite.Create(snapshot, rec, new Vector2(0.5f, 0.85f), 100)
        //Invoke("LoadNewSprite", 0.25f);
    }

    void LoadNewSprite()
    {
        test.GetComponent<SpriteRenderer>().sprite = Resources.Load("CloseUps\\Character_CloseUp_Player", typeof(Sprite)) as Sprite;
    }

    Texture2D RTImage(Camera cam)
    {
        RenderTexture currentRT = RenderTexture.active;
        RenderTexture.active = cam.targetTexture;
        cam.Render();
        Texture2D image = new Texture2D(cam.targetTexture.width, cam.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, cam.targetTexture.width, cam.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = currentRT;
        return image;
    }
}
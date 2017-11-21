﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TutorialManager01_C : MonoBehaviour
{
    public GameObject panel01;
    public GameObject panel02;
    public GameObject panel03;

    public GameObject gameCamera;
    public GameObject blackSq;
    public GameObject enemyMannequinn;
    public GameObject Steve;
    public GameObject shroudParticles;
    public GameObject playerHealth;
    public GameObject enemyHealth;
    public GameObject reap_FX;

    private GameObject textBox;
    private CombatManager combatController;
    private int tutorialState = 0;
    private int inputNumber = 0;
    // Use this for initialization
    void Start()
    {
        combatController = this.GetComponent<CombatManager>();
    }

    public void StrikeUsed()
    {
        if (tutorialState != 0)
            return;

        ++tutorialState;

        combatController.DisableMainButtons();
        combatController.HideMainButtons();
        Destroy(panel01);
        StartCoroutine(FakeStrike());
    }

    IEnumerator FakeStrike()
    {
        this.GetComponent<StrikeManager_C>().StrikeUsed("Tutorial Strike", 100);
        yield return new WaitForSeconds(1);
        enemyHealth.GetComponent<HealthScript>().LerpHealth(1, 0.75f);
        yield return new WaitForSeconds(1);
        combatController.ShowMainButtons();
        combatController.EnableMainButtons();
        yield return new WaitForSeconds(0.5f);
        panel02.GetComponent<Image>().enabled = true;
        panel02.GetComponentInChildren<Text>().enabled = true;
    }

    public void AbilityUsed()
    {
        if (tutorialState != 1)
            return;

        ++tutorialState;

        combatController.DisableMainButtons();
        combatController.HideMainButtons();
        Destroy(panel02);
        combatController.ShowAbilityButtons();
        combatController.EnableAbilityButtons();
        combatController.DisableBackButton();
    }

    public void AbilitySelected()
    {
        if (tutorialState != 2)
            return;

        ++tutorialState;

        combatController.DisableMainButtons();
        combatController.HideMainButtons();
        combatController.ShowAbilityButtons();
        combatController.DisableAbilityButtons();
        combatController.HideAbilityButtons();

        StartCoroutine(FakeAbility());
    }

    IEnumerator FakeAbility()
    {
        yield return new WaitForSeconds(2f);
        textBox = panel03.transform.GetChild(0).gameObject;
        this.GetComponent<AbilityManager_C>().UseTutorialAbility();
        yield return new WaitForSeconds(1.5f);
        enemyHealth.GetComponent<HealthScript>().LerpHealth(0.75f, 0.5f);
        yield return new WaitForSeconds(1f);
        panel03.GetComponent<Image>().enabled = true;
        textBox.GetComponent<Text>().enabled = true;
        StartCoroutine(explanationScene01());
    }

    IEnumerator explanationScene01()
    {
        string line = "Good, good!";
        textBox.GetComponent<Text>().text = "";

        for (int i = 0; i < line.Length; ++i)
        {
            yield return new WaitForSeconds(0.02f);
            //typewriter effect
            textBox.GetComponent<Text>().text = textBox.GetComponent<Text>().text + line[i].ToString();
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(explanationScene02());
    }

    IEnumerator explanationScene02()
    {
        string line = "Yesss, good... Now-";
        textBox.GetComponent<Text>().text = "";
        for (int i = 0; i < line.Length; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            //typewriter effect
            textBox.GetComponent<Text>().text = textBox.GetComponent<Text>().text + line[i].ToString();
        }
        yield return new WaitForSeconds(2f);
        line = "Let's see how you hold up, against a REAL KILLER!!";
        textBox.GetComponent<Text>().text = "";
        for (int i = 0; i < line.Length; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            //typewriter effect
            textBox.GetComponent<Text>().text = textBox.GetComponent<Text>().text + line[i].ToString();
        }
        yield return new WaitForSeconds(2f);
        gameCamera.GetComponent<CameraController>().ShakeCamera(5, true, 5);
        yield return new WaitForSeconds(1f);
        textBox.GetComponent<Text>().enabled = false;
        panel03.GetComponent<Image>().enabled = false;
        StartCoroutine(revealShadowAssassin());
    }

    IEnumerator revealShadowAssassin()
    {
        GameObject slade = Steve.transform.GetChild(1).gameObject;
        Color color1 = new Color(0.1f, 0.1f, 0.1f, 0.8f);
        Color color2 = new Color(0.1f, 0.1f, 0.1f, 0.3f);
        Color color3 = new Color(0.2f, 0.2f, 0.2f, 1f);
        slade.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        Steve.transform.GetChild(0).GetComponent<LerpScript>().LerpToColor(Color.white, color1);
        yield return new WaitForSeconds(0.75f);
        Steve.transform.GetChild(0).GetComponent<LerpScript>().LerpToColor(color1, color2);
        yield return new WaitForSeconds(0.5f);
        Steve.transform.GetChild(0).GetComponent<LerpScript>().LerpToColor(color2, color1);
        yield return new WaitForSeconds(0.5f);
        Steve.transform.GetChild(0).GetComponent<LerpScript>().LerpToColor(color1, color2);
        yield return new WaitForSeconds(0.5f);
        enemyHealth.transform.GetChild(4).GetComponent<Text>().text = "Not Steve";
        Steve.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        slade.GetComponent<SpriteRenderer>().enabled = true;
        slade.GetComponent<LerpScript>().LerpToColor(color2, color3);
        shroudParticles.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        slade.GetComponent<LerpScript>().LerpToColor(color3, Color.white, 0.5f);
        yield return new WaitForSeconds(1f);
        enemyHealth.GetComponent<HealthScript>().LerpHealth(0.5f, 1);
        yield return new WaitForSeconds(1f);
        StartCoroutine(explanationScene03());
    }

    IEnumerator explanationScene03()
    {
        textBox.GetComponent<Text>().text = "";
        textBox.GetComponent<Text>().enabled = true;
        panel03.GetComponent<Image>().enabled = true;

        string line = "...";
        for (int i = 0; i < line.Length; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            //typewriter effect
            textBox.GetComponent<Text>().text = textBox.GetComponent<Text>().text + line[i].ToString();
        }
        yield return new WaitForSeconds(3f);
        line = "Don't squirm, it will only make things... messy.";
        textBox.GetComponent<Text>().text = "";
        for (int i = 0; i < line.Length; ++i)
        {
            yield return new WaitForSeconds(0.01f);
            //typewriter effect
            textBox.GetComponent<Text>().text = textBox.GetComponent<Text>().text + line[i].ToString();
        }
        yield return new WaitForSeconds(4f);
        textBox.GetComponent<Text>().enabled = false;
        panel03.GetComponent<Image>().enabled = false;
        StartCoroutine(knockOutPlayer());
    }

    IEnumerator knockOutPlayer()
    {
        GameObject slade = Steve.transform.GetChild(1).gameObject;
        slade.GetComponent<Animator>().SetInteger("AnimState", 1);
        GameController.controller.GetComponent<MenuUIAudio>().PlaySwordSound();
        yield return new WaitForSeconds(2f);
        Vector3 initEnemyPos = enemyMannequinn.transform.position;
        enemyMannequinn.GetComponent<LerpScript>().LerpToPos(initEnemyPos, enemyMannequinn.transform.position + new Vector3(100, 0, 0), 3);
        yield return new WaitForSeconds(0.25f);
        Vector3 spawnPos = initEnemyPos + new Vector3(0, 0, 0);
        GameObject effectClone = (GameObject)Instantiate(reap_FX, spawnPos, transform.rotation);
        effectClone.transform.parent = enemyMannequinn.transform;
        effectClone.GetComponent<SpriteRenderer>().flipX = false;
        effectClone.transform.position -= new Vector3(80, -30, 0);
        enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos - new Vector3(200, 0, 0), 5);
        yield return new WaitForSeconds(0.25f);
        yield return new WaitForSeconds(0.7f);
        enemyMannequinn.GetComponent<LerpScript>().LerpToPos(enemyMannequinn.transform.position, initEnemyPos, 3);
        yield return new WaitForSeconds(0.85f);
        playerHealth.GetComponent<HealthScript>().LerpHealth(1, 0.1f);
        yield return new WaitForSeconds(1f);
        blackSq.GetComponent<FadeScript>().FadeIn();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Exposition_Scene05");
    }
}
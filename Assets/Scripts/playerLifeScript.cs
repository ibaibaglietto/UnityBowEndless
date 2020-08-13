﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerLifeScript : MonoBehaviour
{
    //The healthbar
    private GameObject healthBar;
    //The end menu
    private GameObject endMenu;
    //The endless controller
    private GameObject endelessController;
    //The max health
    public float maxHealth;
    //The health
    private float health;
    //The canvas
    private GameObject canvas;
    //The bow
    private GameObject bow;
    //The top10 window
    public GameObject top10;
    //The score
    private GameObject score;

    private void Start()
    {
        //We find the gameobjects
        canvas = GameObject.Find("Canvas");
        healthBar = GameObject.Find("playerHealth");
        endMenu = GameObject.Find("EndMenu");
        bow = GameObject.Find("bow");
        endelessController = GameObject.Find("EndlessController");
        top10 = GameObject.Find("Top10Menu");
        endMenu.SetActive(false);
        score = GameObject.Find("Score");
        //We set the max health and the health
        maxHealth = 10.0f;
        health = maxHealth;
        //We deactivate the top10 menu
        top10.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If a mob enters the collider the player loses 1 of health
        if (collision.gameObject.tag == "mob")
        {
            if (collision.gameObject.GetComponent<mobScript>().type != 0)
            {
                health -= 1.0f;
                healthBar.GetComponent<Image>().fillAmount = health / maxHealth;
                Destroy(collision.gameObject);
                //IF players health is 0 them die and the end menu activates.
                //We save all the coins, score and number of bombs and instant kill arrows.
                if (health <= 0.0f)
                {
                    bow.GetComponent<bowScript>().dead = true;
                    Time.timeScale = 0f;
                    endMenu.SetActive(true);
                    PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + (int)endelessController.GetComponent<endlessControllerScript>().coinsGained);
                    endMenu.transform.Find("EndScore").GetComponent<Text>().text = score.GetComponent<Text>().text;
                    endMenu.transform.Find("EndCoins").GetComponent<Text>().text = ((int)endelessController.GetComponent<endlessControllerScript>().coinsGained).ToString();
                    endMenu.transform.Find("EndTotalCoins").GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
                    PlayerPrefs.SetInt("Bombs", canvas.GetComponent<UIScript>().bombNumb);
                    PlayerPrefs.SetInt("InstantKills", canvas.GetComponent<UIScript>().instantNumb);
                    if (PlayerPrefs.GetInt("lastScore") < int.Parse(score.GetComponent<Text>().text) && PlayerPrefs.GetInt("highscoreUnlocked") == 1) top10.SetActive(true);
                }                
            }
        }

    }
}
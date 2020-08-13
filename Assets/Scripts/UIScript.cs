﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    //A bool to check if the game is paused
    private bool Paused;
    //The pause menu
    private GameObject pauseMenu;
    //The end menu
    private GameObject endMenu;
    //The bow
    private GameObject bow;
    //The endless controller
    private GameObject endelessController;
    //The arrows
    private GameObject arrow1;
    private GameObject arrow2;
    private GameObject arrow3;
    private GameObject arrow4;
    private GameObject arrow5;
    private GameObject arrow6;
    private GameObject arrow7;
    private GameObject arrow8;
    private GameObject arrow9;
    private GameObject arrow10;
    //The name of the player
    private GameObject playerName;
    //A bool to see if the carcaj is opened
    private bool active;
    //The backgorund, text and number of the arrows left
    private GameObject arrowsLeftBck;
    private GameObject arrowsLeftText;
    private GameObject arrowsLeftNumb;
    //The top10 window
    public GameObject top10;
    //The fast forward button
    private GameObject fastForwardButton;
    //The play and fast forward images
    public Sprite playSprite;
    public Sprite fastForwardSprite;
    //The number of bombs and instant kill arrows
    public int bombNumb;
    public int instantNumb;
    //The texts we are translating
    private Text remainingText;

    private Text endMenuText;
    private Text restarnEndMenuText;
    private Text menuEndMenuText;
    private Text endScoreText;
    private Text endCoinsText;
    private Text endTotalCoinsText;

    private Text continuePauseText;
    private Text restartPauseText;
    private Text menuPauseText;

    private Text top10Text;
    private Text top10InputFieldPlaceholder;
    private Text top10ButtonText;

    private void Awake()
    {
        //We find all the texts
        remainingText = GameObject.Find("RemainingText").GetComponent<Text>();

        endMenuText = GameObject.Find("EndMenuText").GetComponent<Text>();
        restarnEndMenuText = GameObject.Find("RestartEndMenuText").GetComponent<Text>();
        menuEndMenuText = GameObject.Find("MenuEndMenuText").GetComponent<Text>();
        endScoreText = GameObject.Find("EndScoreText").GetComponent<Text>();
        endCoinsText = GameObject.Find("EndGainedCoinsText").GetComponent<Text>();
        endTotalCoinsText = GameObject.Find("EndTotalCoinsText").GetComponent<Text>();

        continuePauseText = GameObject.Find("ContinuePauseText").GetComponent<Text>();
        restartPauseText = GameObject.Find("RestartPauseText").GetComponent<Text>();
        menuPauseText = GameObject.Find("MenuPauseText").GetComponent<Text>();

        top10Text = GameObject.Find("Top10Text").GetComponent<Text>();
        top10InputFieldPlaceholder = GameObject.Find("Top10InputFieldPlaceholder").GetComponent<Text>();
        top10ButtonText = GameObject.Find("Top10ButtonText").GetComponent<Text>();


        //We find all the gameobjects
        bombNumb = PlayerPrefs.GetInt("Bombs");
        instantNumb = PlayerPrefs.GetInt("InstantKills");
        endMenu = GameObject.Find("EndMenu");
        pauseMenu = GameObject.Find("PauseMenu");
        fastForwardButton = GameObject.Find("fastForwardButton");
        bow = GameObject.Find("bow");
        arrow1 = GameObject.Find("arrow1Button");
        arrow2 = GameObject.Find("arrow2Button");
        arrow3 = GameObject.Find("arrow3Button");
        arrow4 = GameObject.Find("arrow4Button");
        arrow5 = GameObject.Find("arrow5Button");
        arrow6 = GameObject.Find("arrow6Button");
        arrow7 = GameObject.Find("arrow7Button");
        arrow8 = GameObject.Find("arrow8Button");
        arrow9 = GameObject.Find("arrow9Button");
        arrow10 = GameObject.Find("arrow10Button");
        arrowsLeftBck = GameObject.Find("RemainingBck");
        arrowsLeftText = GameObject.Find("RemainingText");
        arrowsLeftNumb = GameObject.Find("RemainingNumb");
        endelessController = GameObject.Find("EndlessController");
        top10 = GameObject.Find("Top10Menu");
        playerName = GameObject.Find("Top10InputFieldText");
        //We deactivate all the carcaj interface
        arrow1.SetActive(false);
        arrow2.SetActive(false);
        arrow3.SetActive(false);
        arrow4.SetActive(false);
        arrow5.SetActive(false);
        arrow6.SetActive(false);
        arrow7.SetActive(false);
        arrow8.SetActive(false);
        arrow9.SetActive(false);
        arrow10.SetActive(false);
        arrowsLeftBck.SetActive(false);
        arrowsLeftText.SetActive(false);
        arrowsLeftNumb.SetActive(false);
        active = false;
        bow.GetComponent<bowScript>().carcajClosing = 0;
        //We deactivate the menu
        pauseMenu.SetActive(false);
        //We put the paused bool to false
        bow.GetComponent<bowScript>().paused = false;

        //We save the translations
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            remainingText.text = "Remaining arrows:";

            endMenuText.text = "You lost!";
            restarnEndMenuText.text = "Restart";
            menuEndMenuText.text = "Main menu";
            endScoreText.text = "Final score:";
            endCoinsText.text = "Gained coins:";
            endTotalCoinsText.text = "Total coins:";

            continuePauseText.text = "Continue";
            restartPauseText.text = "Restart";
            menuPauseText.text = "Main menu";

            top10Text.text = "You entered the top 10, congratulations! Enter your name to save the score.";
            top10InputFieldPlaceholder.text = "Name";
            top10ButtonText.text = "Save";
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            remainingText.text = "Flechas restantes:";

            endMenuText.text = "¡Has perdido!";
            restarnEndMenuText.text = "Reiniciar";
            menuEndMenuText.text = "Menú";
            endScoreText.text = "Puntuación final:";
            endCoinsText.text = "Monedas ganadas:";
            endTotalCoinsText.text = "Monedas totales:";

            continuePauseText.text = "Continuar";
            restartPauseText.text = "Reiniciar";
            menuPauseText.text = "Menú";

            top10Text.text = "¡Has conseguido entrar en el top 10 de mejores puntuaciones! Introduce tu nombre para guardar la puntuación.";
            top10InputFieldPlaceholder.text = "Nombre";
            top10ButtonText.text = "Guardar";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            remainingText.text = "Gainerako geziak:";

            endMenuText.text = "Galdu duzu!";
            restarnEndMenuText.text = "Berrabiatu";
            menuEndMenuText.text = "Menua";
            endScoreText.text = "Puntuazio finala:";
            endCoinsText.text = "Irabazitako txanponak:";
            endTotalCoinsText.text = "Txanponak guztira:";

            continuePauseText.text = "Jarraitu";
            restartPauseText.text = "Berrabiatu";
            menuPauseText.text = "Menua";

            top10Text.text = "Top 10ean sartzea lortu duzu! Sartu zure izena puntuazioa gordetzeko.";
            top10InputFieldPlaceholder.text = "Izena";
            top10ButtonText.text = "Gorde";
        }
    }

    //Function to pause and resume the game
    public void PauseGame()
    {
        if (Paused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
    //Function to resume the game
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        bow.GetComponent<bowScript>().paused = false;
        Paused = false;
    }
    //Function to pause the game
    void Pause()
    {
        pauseMenu.SetActive(true);
        bow.GetComponent<bowScript>().paused = true;
        Time.timeScale = 0f;
        Paused = true;
    }

    //Function to retry 
    public void Retry()
    {
        Time.timeScale = 1f;
        Paused = false;
        SceneManager.LoadScene(1);
    }

    //Function to open the menu
    public void Menu()
    {
        Time.timeScale = 1f;
        Paused = false;
        SceneManager.LoadScene(0);
    }

    //Function to save the arrow type
    public void arrowType(int type)
    {
        bow.GetComponent<bowScript>().arrowType = type;
        carcaj();
    }

    //Function to manage the carcaj
    public void carcaj()
    {
        if (!active)
        {
            arrow1.SetActive(true);
            if(PlayerPrefs.GetInt("Arrow2") == 1) arrow2.SetActive(true);
            if (bombNumb > 0)
            {
                arrow3.SetActive(true);
                arrowsLeftText.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Arrow4") == 1) arrow4.SetActive(true);
            if (PlayerPrefs.GetInt("Arrow5") == 1) arrow5.SetActive(true);
            if (instantNumb > 0)
            {
                arrow6.SetActive(true);
                arrowsLeftText.SetActive(true);
            }
            if (PlayerPrefs.GetInt("Arrow7") == 1) arrow7.SetActive(true);
            if (PlayerPrefs.GetInt("Arrow8") == 1) arrow8.SetActive(true);
            if (PlayerPrefs.GetInt("Arrow9") == 1) arrow9.SetActive(true);
            if (PlayerPrefs.GetInt("Arrow10") == 1) arrow10.SetActive(true);
            active = true;
            bow.GetComponent<bowScript>().carcajOpen = true;
        }
        else
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
            arrow4.SetActive(false);
            arrow5.SetActive(false);
            arrow6.SetActive(false);
            arrow7.SetActive(false);
            arrow8.SetActive(false);
            arrow9.SetActive(false);
            arrow10.SetActive(false);
            active = false;
            bow.GetComponent<bowScript>().carcajClosing = 5;
        }        
    }
    //Function to close the carcaj
    public void continueCarcaj()
    {
        if (active)
        {
            arrow1.SetActive(false);
            arrow2.SetActive(false);
            arrow3.SetActive(false);
            arrow4.SetActive(false);
            arrow5.SetActive(false);
            arrow6.SetActive(false);
            arrow7.SetActive(false);
            arrow8.SetActive(false);
            arrow9.SetActive(false);
            arrow10.SetActive(false);
            active = false;
            bow.GetComponent<bowScript>().carcajOpen = false;
        }        
    }

    //Function to update the highscores
    public void UpdateHighscore()
    {
        highScoreScript highScoreTableScript = new highScoreScript();
        highScoreTableScript.AddHighScoreEntry(((int)(Time.fixedTime - endelessController.GetComponent<endlessControllerScript>().startTime)), playerName.GetComponent<Text>().text);
        top10.SetActive(false);
    }

    //Function to put time x2 or normal
    public void FastForward()
    {
        if (bow.GetComponent<bowScript>().fastForward)
        {
            fastForwardButton.GetComponent<Image>().sprite = fastForwardSprite;
            bow.GetComponent<bowScript>().fastForward = false;
        }
        else
        {
            fastForwardButton.GetComponent<Image>().sprite = playSprite;
            bow.GetComponent<bowScript>().fastForward = true;
        }
        bow.GetComponent<bowScript>().fastForwarding = true;
    }
    
    public void StopFastForwarding()
    {
        bow.GetComponent<bowScript>().fastForwarding = false;
    }    

    private void Update()
    {
        //We decrease the number of bomb arrows or instant kill arrows if we use them
        if(bow.GetComponent<bowScript>().arrowType == 3)
        {
            arrowsLeftBck.SetActive(true);
            arrowsLeftText.SetActive(true);
            arrowsLeftNumb.SetActive(true);
            arrowsLeftNumb.GetComponent<Text>().text = bombNumb.ToString();
        }
        else if(bow.GetComponent<bowScript>().arrowType == 6)
        {
            arrowsLeftBck.SetActive(true);
            arrowsLeftText.SetActive(true);
            arrowsLeftNumb.SetActive(true);
            arrowsLeftNumb.GetComponent<Text>().text = instantNumb.ToString();
        }
        else
        {
            arrowsLeftBck.SetActive(false);
            arrowsLeftText.SetActive(false);
            arrowsLeftNumb.SetActive(false);
        }
    }
}

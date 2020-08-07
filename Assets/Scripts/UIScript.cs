using System.Collections;
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
    //The text and number of the arrows left
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

    private void Awake()
    {
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
        arrowsLeftText.SetActive(false);
        arrowsLeftNumb.SetActive(false);
        active = false;
        bow.GetComponent<bowScript>().carcajClosing = 0;
        //We deactivate the menu
        pauseMenu.SetActive(false);
        //We put the paused bool to false
        bow.GetComponent<bowScript>().paused = false;
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
            arrowsLeftText.SetActive(true);
            arrowsLeftNumb.SetActive(true);
            arrowsLeftNumb.GetComponent<Text>().text = bombNumb.ToString();
        }
        else if(bow.GetComponent<bowScript>().arrowType == 6)
        {
            arrowsLeftText.SetActive(true);
            arrowsLeftNumb.SetActive(true);
            arrowsLeftNumb.GetComponent<Text>().text = instantNumb.ToString();
        }
        else
        {
            arrowsLeftText.SetActive(false);
            arrowsLeftNumb.SetActive(false);
        }
    }
}

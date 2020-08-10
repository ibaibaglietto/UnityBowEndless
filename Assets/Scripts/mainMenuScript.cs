using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
    //The main menu
    private GameObject mainMenu;
    //The store menu
    private GameObject storeMenu;
    //The configuration menu
    private GameObject configurationMenu;
    //The highscore menu
    private GameObject highscoreMenu;
    //The coins
    private GameObject coins;
    //The arrows store menu
    private GameObject arrowsStoreMenu;
    //The regular arrows store menu
    private GameObject regularArrowsStoreMenu;
    //The special arrows store menu
    private GameObject specialArrowsStoreMenu;
    //The bow store menu
    private GameObject bowStoreMenu;
    //The special store menu
    private GameObject specialStoreMenu;
    //The number of bombs purchased
    private GameObject bombNumb;
    //The number of instant kill arrows purchased
    private GameObject instantkillNumb;
    //A bool to check if we entered the bow store directly from the menu
    private bool fromMenu;
    //Gameobjects to show that arrows or bows are purchased
    private GameObject arrow2Bought;
    private GameObject arrow4Bought;
    private GameObject arrow5Bought;
    private GameObject arrow7Bought;
    private GameObject arrow8Bought;
    private GameObject arrow9Bought;
    private GameObject arrow10Bought;
    private GameObject bow1Bought;
    private GameObject bow2Bought;
    private GameObject bow3Bought;
    private GameObject bow4Bought;
    private GameObject bow5Bought;
    private GameObject bow6Bought;
    //The actual damage
    private GameObject actualDamage;
    //The texts
    private Text buyDamagePriceNumb;


    void Awake()
    {
        highScoreScript highScoreTableScript = new highScoreScript();

        //We initialize the playerprefs
        if (!PlayerPrefs.HasKey("highscoreTable"))
        {
            string json = JsonUtility.ToJson("");
            PlayerPrefs.SetString("highscoreTable", json);
            highScoreTableScript.AddHighScoreEntry(600, "GOD");
            highScoreTableScript.AddHighScoreEntry(500, "IBA");
            highScoreTableScript.AddHighScoreEntry(420, "ACL");
            highScoreTableScript.AddHighScoreEntry(360, "AIT");
            highScoreTableScript.AddHighScoreEntry(280, "JUL");
            highScoreTableScript.AddHighScoreEntry(235, "IZA");
            highScoreTableScript.AddHighScoreEntry(190, "XAB");
            highScoreTableScript.AddHighScoreEntry(150, "AND");
            highScoreTableScript.AddHighScoreEntry(125, "JOE");
            highScoreTableScript.AddHighScoreEntry(100, "JOS");
            PlayerPrefs.SetInt("lastScore", 100);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 1);
        }
        if (!PlayerPrefs.HasKey("Bombs"))
        {
            PlayerPrefs.SetInt("Bombs", 0);
        }
        if (!PlayerPrefs.HasKey("InstantKills"))
        {
            PlayerPrefs.SetInt("InstantKills", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow2"))
        {
            PlayerPrefs.SetInt("Arrow2", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow4"))
        {
            PlayerPrefs.SetInt("Arrow4", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow5"))
        {
            PlayerPrefs.SetInt("Arrow5", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow7"))
        {
            PlayerPrefs.SetInt("Arrow7", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow8"))
        {
            PlayerPrefs.SetInt("Arrow8", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow9"))
        {
            PlayerPrefs.SetInt("Arrow9", 0);
        }
        if (!PlayerPrefs.HasKey("Arrow10"))
        {
            PlayerPrefs.SetInt("Arrow10", 0);
        }
        if (!PlayerPrefs.HasKey("Bow2"))
        {
            PlayerPrefs.SetInt("Bow2", 0);
        }
        if (!PlayerPrefs.HasKey("Bow3"))
        {
            PlayerPrefs.SetInt("Bow3", 0);
        }
        if (!PlayerPrefs.HasKey("Bow4"))
        {
            PlayerPrefs.SetInt("Bow4", 0);
        }
        if (!PlayerPrefs.HasKey("Bow5"))
        {
            PlayerPrefs.SetInt("Bow5", 0);
        }
        if (!PlayerPrefs.HasKey("Bow6"))
        {
            PlayerPrefs.SetInt("Bow6", 0);
        }
        if (!PlayerPrefs.HasKey("UsingBow"))
        {
            PlayerPrefs.SetInt("UsingBow", 1);
        }
        if (!PlayerPrefs.HasKey("UpgradeMultiplier"))
        {
            PlayerPrefs.SetFloat("UpgradeMultiplier", 0.0f);
        }
        //We find all the gameobjects
        mainMenu = GameObject.Find("MainMenu");
        storeMenu = GameObject.Find("StoreMenu");
        configurationMenu = GameObject.Find("ConfigurationMenu");
        highscoreMenu = GameObject.Find("HighscoreMenu");
        coins = GameObject.Find("Coins");
        arrowsStoreMenu = GameObject.Find("ArrowStoreMenu");
        regularArrowsStoreMenu = GameObject.Find("RegularArrowStoreMenu");
        arrow2Bought = GameObject.Find("arrow2Bought");
        arrow4Bought = GameObject.Find("arrow4Bought");
        arrow5Bought = GameObject.Find("arrow5Bought");
        arrow7Bought = GameObject.Find("arrow7Bought");
        arrow8Bought = GameObject.Find("arrow8Bought");
        arrow9Bought = GameObject.Find("arrow9Bought");
        arrow10Bought = GameObject.Find("arrow10Bought");
        bow1Bought = GameObject.Find("bow1Bought");
        bow2Bought = GameObject.Find("bow2Bought");
        bow3Bought = GameObject.Find("bow3Bought");
        bow4Bought = GameObject.Find("bow4Bought");
        bow5Bought = GameObject.Find("bow5Bought");
        bow6Bought = GameObject.Find("bow6Bought");
        specialArrowsStoreMenu = GameObject.Find("SpecialArrowStoreMenu");
        bombNumb = GameObject.Find("BombArrowsNumb");
        instantkillNumb = GameObject.Find("InstantKillArrowsNumb");
        bowStoreMenu = GameObject.Find("BowStoreMenu");
        specialStoreMenu = GameObject.Find("SpecialStoreMenu");
        actualDamage = GameObject.Find("ActualDamage");
        actualDamage.GetComponent<Text>().text = PlayerPrefs.GetFloat("UpgradeMultiplier").ToString();
        coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
        buyDamagePriceNumb = GameObject.Find("BuyDamagePriceNumb").GetComponent<Text>();
        //We deactivate some gameobjects
        storeMenu.SetActive(false);
        configurationMenu.SetActive(false);
        highscoreMenu.SetActive(false);
        arrowsStoreMenu.SetActive(false);
        regularArrowsStoreMenu.SetActive(false);
        specialArrowsStoreMenu.SetActive(false);
        bowStoreMenu.SetActive(false);
        specialStoreMenu.SetActive(false);
        //We get the number of bombs and instant kill arrows and write them with different colors depending on the amount of them we have
        bombNumb.GetComponent<Text>().text = PlayerPrefs.GetInt("Bombs").ToString();
        if (PlayerPrefs.GetInt("Bombs") == 10) bombNumb.GetComponent<Text>().color = Color.green;
        else if (PlayerPrefs.GetInt("Bombs") == 0) bombNumb.GetComponent<Text>().color = Color.red;
        else bombNumb.GetComponent<Text>().color = Color.black;
        instantkillNumb.GetComponent<Text>().text = PlayerPrefs.GetInt("InstantKills").ToString();
        if (PlayerPrefs.GetInt("InstantKills") == 5) instantkillNumb.GetComponent<Text>().color = Color.green;
        else if (PlayerPrefs.GetInt("InstantKills") == 0) instantkillNumb.GetComponent<Text>().color = Color.red;
        else instantkillNumb.GetComponent<Text>().color = Color.black;
        //We activate the bought checks if we have bought that arrow or bow
        arrow2Bought.SetActive(PlayerPrefs.GetInt("Arrow2") == 1);
        arrow4Bought.SetActive(PlayerPrefs.GetInt("Arrow4") == 1);
        arrow5Bought.SetActive(PlayerPrefs.GetInt("Arrow5") == 1);
        arrow7Bought.SetActive(PlayerPrefs.GetInt("Arrow7") == 1);
        arrow8Bought.SetActive(PlayerPrefs.GetInt("Arrow8") == 1);
        arrow9Bought.SetActive(PlayerPrefs.GetInt("Arrow9") == 1);
        arrow10Bought.SetActive(PlayerPrefs.GetInt("Arrow10") == 1);
        bow2Bought.SetActive(PlayerPrefs.GetInt("Bow2") == 1);
        bow3Bought.SetActive(PlayerPrefs.GetInt("Bow3") == 1);
        bow4Bought.SetActive(PlayerPrefs.GetInt("Bow4") == 1);
        bow5Bought.SetActive(PlayerPrefs.GetInt("Bow5") == 1);
        bow6Bought.SetActive(PlayerPrefs.GetInt("Bow6") == 1);
        //We save what bow we are using
        if (PlayerPrefs.GetInt("UsingBow") == 1)
        {
            bow1Bought.GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("UsingBow") == 2)
        {
            bow2Bought.GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("UsingBow") == 3)
        {
            bow3Bought.GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("UsingBow") == 4)
        {
            bow4Bought.GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("UsingBow") == 5)
        {
            bow5Bought.GetComponent<Image>().color = Color.yellow;
        }
        else if (PlayerPrefs.GetInt("UsingBow") == 6)
        {
            bow6Bought.GetComponent<Image>().color = Color.yellow;
        }
        buyDamagePriceNumb.text = (5000 + PlayerPrefs.GetFloat("UpgradeMultiplier") * 30000).ToString();
    }


    //Function to start a game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Function to open the store
    public void OpenStore()
    {
        mainMenu.SetActive(false);
        storeMenu.SetActive(true);
    }

    //function to close the store
    public void CloseStore()
    {
        mainMenu.SetActive(true);
        storeMenu.SetActive(false);
    }

    //Function to open the arrow store
    public void OpenArrowStore()
    {
        storeMenu.SetActive(false);
        arrowsStoreMenu.SetActive(true);
    }

    //Function to close the arrow store
    public void CloseArrowStore()
    {
        storeMenu.SetActive(true);
        arrowsStoreMenu.SetActive(false);
    }

    //Function to open the regular arrow store
    public void OpenRegularArrowStore()
    {
        arrowsStoreMenu.SetActive(false);
        regularArrowsStoreMenu.SetActive(true);
    }

    //Function to close the regular arrow store
    public void CloseRegularArrowStore()
    {
        arrowsStoreMenu.SetActive(true);
        regularArrowsStoreMenu.SetActive(false);
    }

    //Function to open the special arrow store
    public void OpenSpecialArrowStore()
    {
        arrowsStoreMenu.SetActive(false);
        specialArrowsStoreMenu.SetActive(true);
    }

    //Function to close the special arrow store
    public void CloseSpcialArrowStore()
    {
        arrowsStoreMenu.SetActive(true);
        specialArrowsStoreMenu.SetActive(false);
    }

    //Function to open the bow store from the store
    public void OpenBowStoreFromStore()
    {
        storeMenu.SetActive(false);
        bowStoreMenu.SetActive(true);
        fromMenu = false;
    }

    //Function to open the bow store from the menu
    public void OpenBowStoreFromMenu()
    {
        mainMenu.SetActive(false);
        bowStoreMenu.SetActive(true);
        fromMenu = true;
    }

    //Function to close the bow store
    public void CloseBowStore()
    {
        bowStoreMenu.SetActive(false);
        if (fromMenu) mainMenu.SetActive(true);
        else storeMenu.SetActive(true);
    }

    //Function to open the special store
    public void OpenSpecialStore()
    {
        storeMenu.SetActive(false);
        specialStoreMenu.SetActive(true);
    }

    //Function to close the special store
    public void CloseSpecialStore()
    {
        storeMenu.SetActive(true);
        specialStoreMenu.SetActive(false);
    }

    //Function to open the configuration
    public void OpenConfiguration()
    {
        mainMenu.SetActive(false);
        configurationMenu.SetActive(true);
    }

    //Function to close the configuration
    public void CloseConfiguration()
    {
        mainMenu.SetActive(true);
        configurationMenu.SetActive(false);
    }

    //Function to open the highscore
    public void OpenHighscore()
    {
        mainMenu.SetActive(false);
        highscoreMenu.SetActive(true);
    }

    //Function to close the highscore
    public void CloseHighscore()
    {
        mainMenu.SetActive(true);
        highscoreMenu.SetActive(false);
    }

    //Functions to unlock the arrows
    public void UnlockArrow2()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow2") == 0)
            {
                PlayerPrefs.SetInt("Arrow2", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow2Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow4()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow4") == 0)
            {
                PlayerPrefs.SetInt("Arrow4", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow4Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow5()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow5") == 0)
            {
                PlayerPrefs.SetInt("Arrow5", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow5Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow7()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow7") == 0)
            {
                PlayerPrefs.SetInt("Arrow7", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow7Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow8()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow8") == 0)
            {
                PlayerPrefs.SetInt("Arrow8", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow8Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow9()
    {
        if (PlayerPrefs.GetInt("Coins") >= 200)
        {
            if (PlayerPrefs.GetInt("Arrow9") == 0)
            {
                PlayerPrefs.SetInt("Arrow9", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 200);
                arrow9Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    public void UnlockArrow10()
    {
        if (PlayerPrefs.GetInt("Coins") >= 1000)
        {
            if (PlayerPrefs.GetInt("Arrow10") == 0)
            {
                PlayerPrefs.SetInt("Arrow10", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
                arrow10Bought.SetActive(true);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }

    //Function to upgrade the damage
    public void UpgradeDamage(){
        if (PlayerPrefs.GetInt("Coins") >= 5000 + PlayerPrefs.GetFloat("UpgradeMultiplier") * 30000)
        {
            PlayerPrefs.SetFloat("UpgradeMultiplier", PlayerPrefs.GetFloat("UpgradeMultiplier") + 0.1f);
            actualDamage.GetComponent<Text>().text = PlayerPrefs.GetFloat("UpgradeMultiplier").ToString();
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - (int)(5000 + PlayerPrefs.GetFloat("UpgradeMultiplier") * 30000));
            coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            buyDamagePriceNumb.text = (5000 + PlayerPrefs.GetFloat("UpgradeMultiplier") * 30000).ToString();
            Debug.Log(PlayerPrefs.GetFloat("UpgradeMultiplier"));
        }
    }
    //Function to buy instant kill arrows
    public void IncrementInstantKill()
    {
        if (PlayerPrefs.GetInt("Coins") >= 100)
        {
            if (PlayerPrefs.GetInt("InstantKills") < 5)
            {
                PlayerPrefs.SetInt("InstantKills", PlayerPrefs.GetInt("InstantKills") + 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
                instantkillNumb.GetComponent<Text>().text = PlayerPrefs.GetInt("InstantKills").ToString();
                if (PlayerPrefs.GetInt("InstantKills") == 5) instantkillNumb.GetComponent<Text>().color = Color.green;
                else instantkillNumb.GetComponent<Text>().color = Color.black;
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    //Function to buy bombs
    public void IncrementBomb()
    {
        if (PlayerPrefs.GetInt("Coins") >= 100)
        {
            if (PlayerPrefs.GetInt("Bombs") < 10)
            {
                PlayerPrefs.SetInt("Bombs", PlayerPrefs.GetInt("Bombs") + 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 100);
                bombNumb.GetComponent<Text>().text = PlayerPrefs.GetInt("Bombs").ToString();
                if (PlayerPrefs.GetInt("Bombs") == 10) bombNumb.GetComponent<Text>().color = Color.green;
                else bombNumb.GetComponent<Text>().color = Color.black;
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
            }
        }
    }
    //Functions to unlock bows
    public void UnlockBow1()
    {
        PlayerPrefs.SetInt("UsingBow", 1);
        bow1Bought.GetComponent<Image>().color = Color.yellow;
        bow2Bought.GetComponent<Image>().color = Color.white;
        bow3Bought.GetComponent<Image>().color = Color.white;
        bow4Bought.GetComponent<Image>().color = Color.white;
        bow5Bought.GetComponent<Image>().color = Color.white;
        bow6Bought.GetComponent<Image>().color = Color.white;
    }
    public void UnlockBow2()
    {
        if (PlayerPrefs.GetInt("Bow2") == 0)           
        {
            if (PlayerPrefs.GetInt("Coins") >= 500)
            {
                PlayerPrefs.SetInt("Bow2", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 500);
                bow2Bought.SetActive(true);
                PlayerPrefs.SetInt("UsingBow", 2);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();

                bow1Bought.GetComponent<Image>().color = Color.white;
                bow2Bought.GetComponent<Image>().color = Color.yellow;
                bow3Bought.GetComponent<Image>().color = Color.white;
                bow4Bought.GetComponent<Image>().color = Color.white;
                bow5Bought.GetComponent<Image>().color = Color.white;
                bow6Bought.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            PlayerPrefs.SetInt("UsingBow", 2);
            bow1Bought.GetComponent<Image>().color = Color.white;
            bow2Bought.GetComponent<Image>().color = Color.yellow;
            bow3Bought.GetComponent<Image>().color = Color.white;
            bow4Bought.GetComponent<Image>().color = Color.white;
            bow5Bought.GetComponent<Image>().color = Color.white;
            bow6Bought.GetComponent<Image>().color = Color.white;
        }
    }

    public void UnlockBow3()
    {
        if (PlayerPrefs.GetInt("Bow3") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= 1000)
            {
                PlayerPrefs.SetInt("Bow3", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1000);
                bow3Bought.SetActive(true);
                PlayerPrefs.SetInt("UsingBow", 3);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
                bow1Bought.GetComponent<Image>().color = Color.white;
                bow2Bought.GetComponent<Image>().color = Color.white;
                bow3Bought.GetComponent<Image>().color = Color.yellow;
                bow4Bought.GetComponent<Image>().color = Color.white;
                bow5Bought.GetComponent<Image>().color = Color.white;
                bow6Bought.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            PlayerPrefs.SetInt("UsingBow", 3);
            bow1Bought.GetComponent<Image>().color = Color.white;
            bow2Bought.GetComponent<Image>().color = Color.white;
            bow3Bought.GetComponent<Image>().color = Color.yellow;
            bow4Bought.GetComponent<Image>().color = Color.white;
            bow5Bought.GetComponent<Image>().color = Color.white;
            bow6Bought.GetComponent<Image>().color = Color.white;
        }
    }

    public void UnlockBow4()
    {
        if (PlayerPrefs.GetInt("Bow4") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= 1500)
            {
                PlayerPrefs.SetInt("Bow4", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 1500);
                bow4Bought.SetActive(true);
                PlayerPrefs.SetInt("UsingBow", 4);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
                bow1Bought.GetComponent<Image>().color = Color.white;
                bow2Bought.GetComponent<Image>().color = Color.white;
                bow3Bought.GetComponent<Image>().color = Color.white;
                bow4Bought.GetComponent<Image>().color = Color.yellow;
                bow5Bought.GetComponent<Image>().color = Color.white;
                bow6Bought.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            PlayerPrefs.SetInt("UsingBow", 4);
            bow1Bought.GetComponent<Image>().color = Color.white;
            bow2Bought.GetComponent<Image>().color = Color.white;
            bow3Bought.GetComponent<Image>().color = Color.white;
            bow4Bought.GetComponent<Image>().color = Color.yellow;
            bow5Bought.GetComponent<Image>().color = Color.white;
            bow6Bought.GetComponent<Image>().color = Color.white;
        }
    }

    public void UnlockBow5()
    {
        if (PlayerPrefs.GetInt("Bow5") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= 2000)
            {
                PlayerPrefs.SetInt("Bow5", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 2000);
                bow5Bought.SetActive(true);
                PlayerPrefs.SetInt("UsingBow", 5);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
                bow1Bought.GetComponent<Image>().color = Color.white;
                bow2Bought.GetComponent<Image>().color = Color.white;
                bow3Bought.GetComponent<Image>().color = Color.white;
                bow4Bought.GetComponent<Image>().color = Color.white;
                bow5Bought.GetComponent<Image>().color = Color.yellow;
                bow6Bought.GetComponent<Image>().color = Color.white;
            }
        }
        else
        {
            PlayerPrefs.SetInt("UsingBow", 5);
            bow1Bought.GetComponent<Image>().color = Color.white;
            bow2Bought.GetComponent<Image>().color = Color.white;
            bow3Bought.GetComponent<Image>().color = Color.white;
            bow4Bought.GetComponent<Image>().color = Color.white;
            bow5Bought.GetComponent<Image>().color = Color.yellow;
            bow6Bought.GetComponent<Image>().color = Color.white;
        }
    }

    public void UnlockBow6()
    {
        if (PlayerPrefs.GetInt("Bow6") == 0)
        {
            if (PlayerPrefs.GetInt("Coins") >= 3000)
            {
                PlayerPrefs.SetInt("Bow6", 1);
                PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - 3000);
                bow6Bought.SetActive(true);
                PlayerPrefs.SetInt("UsingBow", 6);
                coins.GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();
                bow1Bought.GetComponent<Image>().color = Color.white;
                bow2Bought.GetComponent<Image>().color = Color.white;
                bow3Bought.GetComponent<Image>().color = Color.white;
                bow4Bought.GetComponent<Image>().color = Color.white;
                bow5Bought.GetComponent<Image>().color = Color.white;
                bow6Bought.GetComponent<Image>().color = Color.yellow;
            }
        }
        else
        {
            PlayerPrefs.SetInt("UsingBow", 6);
            bow1Bought.GetComponent<Image>().color = Color.white;
            bow2Bought.GetComponent<Image>().color = Color.white;
            bow3Bought.GetComponent<Image>().color = Color.white;
            bow4Bought.GetComponent<Image>().color = Color.white;
            bow5Bought.GetComponent<Image>().color = Color.white;
            bow6Bought.GetComponent<Image>().color = Color.yellow;
        }
    }

    //Function to close the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}

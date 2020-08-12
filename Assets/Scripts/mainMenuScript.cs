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
    //The language selection menu
    private GameObject LanguageSelectionMenu;
    //The first language choose dropdown
    private Dropdown LanguageChooseDropdown;
    //The language choose dropdown
    private Dropdown LanguageDropdown;
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

    private Text playButtonText;
    private Text storeButtonText;
    private Text configurationButtonText;
    private Text highscoreButtonText;
    private Text exitButtonText;

    private Text storeMenuTitle;
    private Text arrowsButtonText;
    private Text bowsButtonText;
    private Text specialButtonText;
    private Text returnStoreButtonText;

    private Text arrowStoreTitle;
    private Text regularArrowButtonText;
    private Text specialArrowButtonText;
    private Text returnArrowStoreButtonText;

    private Text normalArrowsTitle;
    private Text buyNormalArrowsExplanationText;
    private Text blueArrowsText;
    private Text greyArrowsText;
    private Text greenArrowsText;
    private Text redArrowsText;
    private Text yellowArrowsText;
    private Text brownArrowsText;
    private Text returnRegularArrowButtonText;

    private Text specialArrowsTitle;
    private Text buySpecialArrowsExplanationText;
    private Text bombArrowsText;
    private Text instantKillArrowsText;
    private Text angelicArrowText;
    private Text returnSpecialArrowStoreText;

    private Text bowStoreTitle;
    private Text bowStoreExplanationText;
    private Text bow1Text;
    private Text bow2Text;
    private Text bow3Text;
    private Text bow4Text;
    private Text bow5Text;
    private Text bow6Text;
    private Text returnBowStoreButtonText;

    private Text specialStoreMenuTitle;
    private Text buyHighscoreText;
    private Text buyHighscoreButtonText;
    private Text buyDamageText;
    private Text buyDamagePriceText;
    private Text increaseDamageButtonText;
    private Text actualDamageText;
    private Text returnSpecialStoreButtonText;

    private Text configurationMenuTitle;
    private Text languageText;
    private Text masterText;
    private Text musicText;
    private Text effectsText;
    private Text configurationMenuReturnButtonText;

    private Text highscoreTitleText;
    private Text positionTitle;
    private Text scoreTitle;
    private Text nameTitle;
    private Text returnHighscoreText;

    private Text languageChooseText;
    private Text firstLanguageButtonText;

    void Awake()
    {
        //We find all the texts
        playButtonText = GameObject.Find("PlayButtonText").GetComponent<Text>();
        storeButtonText = GameObject.Find("StoreButtonText").GetComponent<Text>();
        configurationButtonText = GameObject.Find("ConfigurationButtonText").GetComponent<Text>();
        highscoreButtonText = GameObject.Find("HighscoreButtonText").GetComponent<Text>();
        exitButtonText = GameObject.Find("ExitButtonText").GetComponent<Text>();

        storeMenuTitle = GameObject.Find("StoreMenuTitle").GetComponent<Text>();
        arrowsButtonText = GameObject.Find("ArrowsButtonText").GetComponent<Text>();
        bowsButtonText = GameObject.Find("BowsButtonText").GetComponent<Text>();
        specialButtonText = GameObject.Find("SpecialButtonText").GetComponent<Text>();
        returnStoreButtonText = GameObject.Find("ReturnStoreButtonText").GetComponent<Text>();

        arrowStoreTitle = GameObject.Find("ArrowStoreTitle").GetComponent<Text>();
        regularArrowButtonText = GameObject.Find("RegularArrowButtonText").GetComponent<Text>();
        specialArrowButtonText = GameObject.Find("SpecialArrowButtonText").GetComponent<Text>();
        returnArrowStoreButtonText = GameObject.Find("ReturnArrowStoreButtonText").GetComponent<Text>();

        normalArrowsTitle = GameObject.Find("NormalArrowsTitle").GetComponent<Text>();
        buyNormalArrowsExplanationText = GameObject.Find("BuyNormalArrowsExplanationText").GetComponent<Text>();
        blueArrowsText = GameObject.Find("BlueArrowsText").GetComponent<Text>();
        greyArrowsText = GameObject.Find("GreyArrowsText").GetComponent<Text>();
        greenArrowsText = GameObject.Find("GreenArrowsText").GetComponent<Text>();
        redArrowsText = GameObject.Find("RedArrowsText").GetComponent<Text>();
        yellowArrowsText = GameObject.Find("YellowArrowsText").GetComponent<Text>();
        brownArrowsText = GameObject.Find("BrownArrowsText").GetComponent<Text>();
        returnRegularArrowButtonText = GameObject.Find("ReturnRegularArrowButtonText").GetComponent<Text>();

        specialArrowsTitle = GameObject.Find("SpecialArrowsTitle").GetComponent<Text>();
        buySpecialArrowsExplanationText = GameObject.Find("BuySpecialArrowsExplanationText").GetComponent<Text>();
        bombArrowsText = GameObject.Find("BombArrowsText").GetComponent<Text>();
        instantKillArrowsText = GameObject.Find("InstantKillArrowsText").GetComponent<Text>();
        angelicArrowText = GameObject.Find("AngelicArrowText").GetComponent<Text>();
        returnSpecialArrowStoreText = GameObject.Find("ReturnSpecialArrowStoreText").GetComponent<Text>();

        bowStoreTitle = GameObject.Find("BowStoreTitle").GetComponent<Text>();
        bowStoreExplanationText = GameObject.Find("BowStoreExplanationText").GetComponent<Text>();
        bow1Text = GameObject.Find("bow1Text").GetComponent<Text>();
        bow2Text = GameObject.Find("bow2Text").GetComponent<Text>();
        bow3Text = GameObject.Find("bow3Text").GetComponent<Text>();
        bow4Text = GameObject.Find("bow4Text").GetComponent<Text>();
        bow5Text = GameObject.Find("bow5Text").GetComponent<Text>();
        bow6Text = GameObject.Find("bow6Text").GetComponent<Text>();
        returnBowStoreButtonText = GameObject.Find("ReturnBowStoreButtonText").GetComponent<Text>();

        specialStoreMenuTitle = GameObject.Find("SpecialStoreMenuTitle").GetComponent<Text>();
        buyHighscoreText = GameObject.Find("BuyHighscoreText").GetComponent<Text>();
        buyHighscoreButtonText = GameObject.Find("BuyHighscoreButtonText").GetComponent<Text>();
        buyDamageText = GameObject.Find("BuyDamageText").GetComponent<Text>();
        buyDamagePriceText = GameObject.Find("BuyDamagePriceText").GetComponent<Text>();
        increaseDamageButtonText = GameObject.Find("IncreaseDamageButtonText").GetComponent<Text>();
        actualDamageText = GameObject.Find("ActualDamageText").GetComponent<Text>();
        returnSpecialStoreButtonText = GameObject.Find("ReturnSpecialStoreButtonText").GetComponent<Text>();

        configurationMenuTitle = GameObject.Find("ConfigurationMenuTitle").GetComponent<Text>();
        languageText = GameObject.Find("LanguageText").GetComponent<Text>();
        masterText = GameObject.Find("MasterText").GetComponent<Text>();
        musicText = GameObject.Find("MusicText").GetComponent<Text>();
        effectsText = GameObject.Find("EffectsText").GetComponent<Text>();
        configurationMenuReturnButtonText = GameObject.Find("ConfigurationMenuReturnButtonText").GetComponent<Text>();

        highscoreTitleText = GameObject.Find("HighscoreTitleText").GetComponent<Text>();
        positionTitle = GameObject.Find("PositionTitle").GetComponent<Text>();
        scoreTitle = GameObject.Find("ScoreTitle").GetComponent<Text>();
        nameTitle = GameObject.Find("NameTitle").GetComponent<Text>();
        returnHighscoreText = GameObject.Find("ReturnHighscoreText").GetComponent<Text>();

        languageChooseText = GameObject.Find("LanguageChooseText").GetComponent<Text>(); 
        firstLanguageButtonText = GameObject.Find("FirstLanguageButtonText").GetComponent<Text>(); 


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
        if (!PlayerPrefs.HasKey("Language")) PlayerPrefs.SetInt("Language", 0); //0-> english, 1-> spanish, 2-> basque
        if (!PlayerPrefs.HasKey("languageChoosen")) PlayerPrefs.SetInt("languageChoosen", 0);


        //We find all the gameobjects
        LanguageSelectionMenu = GameObject.Find("FirstLanguageMenu");
        LanguageChooseDropdown = GameObject.Find("FirstLanguageDropdown").GetComponent<Dropdown>();
        LanguageDropdown = GameObject.Find("LanguageDropdown").GetComponent<Dropdown>();
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
        actualDamage = GameObject.Find("ActualDamageNumb");
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


        //We check if the player has choosen the language
        if (PlayerPrefs.GetInt("languageChoosen") == 0)
        {
            LanguageSelectionMenu.SetActive(true);
            PlayerPrefs.SetInt("languageChoosen", 1);
        }
        else LanguageSelectionMenu.SetActive(false);

        //We save the translations
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            playButtonText.text = "Play";
            storeButtonText.text = "Store";
            configurationButtonText.text = "Configuration";
            highscoreButtonText.text = "High scores";
            exitButtonText.text = "Exit";

            storeMenuTitle.text = "Store";
            arrowsButtonText.text = "Arrows";
            bowsButtonText.text = "Bows";
            specialButtonText.text = "Special";
            returnStoreButtonText.text = "Return";

            arrowStoreTitle.text = "Arrows";
            regularArrowButtonText.text = "Normal arrows";
            specialArrowButtonText.text = "Special arrows";
            returnArrowStoreButtonText.text = "Return";

            normalArrowsTitle.text = "Normal arrows";
            buyNormalArrowsExplanationText.text = "Each type of arrow does more damage and pushes backwards one enemy class. Buy the arrows spending 200.";
            blueArrowsText.text = "Blue \narrows";
            greyArrowsText.text = "Grey \narrows";
            greenArrowsText.text = "Green \narrows";
            redArrowsText.text = "Red \narrows";
            yellowArrowsText.text = "Yellow \narrows";
            brownArrowsText.text = "Brown \narrows";
            returnRegularArrowButtonText.text = "Return";

            specialArrowsTitle.text = "Especial arrows";
            buySpecialArrowsExplanationText.text = "Welcome to the special arrow store. Here you can buy three types of arrow: bomb arrows (100 coins), instant kill arrows (100 coins) and angelic arrows (1000 coins). The first two are limited and you will need to buy them each time you use one, you can have 10 bomb arrows and 5 instant kill arrows. Speaking about angelic arrows, you will only need to buy them once.";
            bombArrowsText.text = "Bomb \narrows";
            instantKillArrowsText.text = "Instant kill arrows";
            angelicArrowText.text = "Angelic arrows";
            returnSpecialArrowStoreText.text = "Return";

            bowStoreTitle.text = "Bows";
            bowStoreExplanationText.text = "Welcome to the arrow store. You can buy and equip bows here.";
            bow1Text.text = "Games worst bow, but it’s free.";
            bow2Text.text = "Upgrades a bit the shooting speed and the damage. Price: 500";
            bow3Text.text = "It’s exactly the same as the previous one, but it shoots two arrows. Price: 1000";
            bow4Text.text = "It upgrades a bit the shooting speed and the damage. Price: 1500";
            bow5Text.text = "It upgrades again the shooting speed and the damage, did you expect it to worsen? Price: 2000";
            bow6Text.text = "It upgrades the damage a lot and it shoots three arrows, you can’t ask for more. Price: 3000";
            returnBowStoreButtonText.text = "Return";

            specialStoreMenuTitle.text = "Special articles";
            buyHighscoreText.text = "High scores. \nPrice: 2000";
            buyHighscoreButtonText.text = "Buy";
            buyDamageText.text = "Add 0.1 to the damage multiplier.";
            buyDamagePriceText.text = "Price:";
            increaseDamageButtonText.text = "Buy";
            actualDamageText.text = "Actual multiplier:";
            returnSpecialStoreButtonText.text = "Return";

            configurationMenuTitle.text = "Configuration";
            languageText.text = "Language:";
            masterText.text = "Main volume:";
            musicText.text = "Music:";
            effectsText.text = "Effects:";
            configurationMenuReturnButtonText.text = "Return";

            highscoreTitleText.text = "High scores";
            positionTitle.text = "POSITION";
            scoreTitle.text = "SCORE";
            nameTitle.text = "NAME";
            returnHighscoreText.text = "Return";

            languageChooseText.text = "Select the language you want the game to be. \nYou can change it whenever you want on the settings.";
            firstLanguageButtonText.text = "Save";
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            playButtonText.text = "Jugar";
            storeButtonText.text = "Tienda";
            configurationButtonText.text = "Configuración";
            highscoreButtonText.text = "Puntuaciones";
            exitButtonText.text = "Salir";

            storeMenuTitle.text = "Tienda";
            arrowsButtonText.text = "Flechas";
            bowsButtonText.text = "Arcos";
            specialButtonText.text = "Especial";
            returnStoreButtonText.text = "Volver";

            arrowStoreTitle.text = "Flechas";
            regularArrowButtonText.text = "Flechas normales";
            specialArrowButtonText.text = "Flechas especiales";
            returnArrowStoreButtonText.text = "Volver";

            normalArrowsTitle.text = "Flechas normales";
            buyNormalArrowsExplanationText.text = "Cada tipo de flecha hace más daño a un tipo concreto de enemigo y le empuja hacia atrás. Para comprar las flechas realiza un único pago de 200.";
            blueArrowsText.text = "Flechas \nazules";
            greyArrowsText.text = "Flechas \ngrises";
            greenArrowsText.text = "Flechas \nverdes";
            redArrowsText.text = "Flechas \nrojas";
            yellowArrowsText.text = "Flechas \namarillas";
            brownArrowsText.text = "Flechas \nmarrones";
            returnRegularArrowButtonText.text = "Volver";

            specialArrowsTitle.text = "Flechas especiales";
            buySpecialArrowsExplanationText.text = "Bienvenido a la tienda de flechas especiales. Aquí podrás encontrar tres tipos de flecha: flechas bomba, 100 monedas, flechas de muerte instantánea, 100 monedas, y flechas angelicales, 1000 monedas. Las dos primeras son limitadas y tendrás que comprarlas con cada uso, 10 y 5 respectivamente. En el caso de las flechas angelicales solo tendrás que realizar una compra.";
            bombArrowsText.text = "Flechas \nbomba";
            instantKillArrowsText.text = "Flechas de muerte instantánea";
            angelicArrowText.text = "Flechas angelicales";
            returnSpecialArrowStoreText.text = "Volver";

            bowStoreTitle.text = "Arcos";
            bowStoreExplanationText.text = "Bienvenido a la tienda de arcos. Además de comprar los arcos en esta misma ventana puedes elegir el arco que usaras en el juego.";
            bow1Text.text = "El peor arco del juego, pero es gratis.";
            bow2Text.text = "Mejora un poco la velocidad de disparo y el daño. Precio: 500";
            bow3Text.text = "Es exactamente igual a su predecesor, pero lanza dos flechas en lugar de una. Precio: 1000";
            bow4Text.text = "Mejora ligeramente la velocidad de disparo y el daño. Precio: 1500";
            bow5Text.text = "Vuelve a mejorar ligeramente la velocidad de disparo y el daño, ¿qué esperabas, que bajaran? Precio: 2000";
            bow6Text.text = "Mejora ampliamente el daño y lanza 3 flechas, ¿qué más se le podría pedir? Precio: 3000";
            returnBowStoreButtonText.text = "Volver";

            specialStoreMenuTitle.text = "Artículos especiales";
            buyHighscoreText.text = "Tabla de puntuaciones. \nPrecio: 2000";
            buyHighscoreButtonText.text = "Comprar";
            buyDamageText.text = "Sumar 0.1 al multiplicador de daño.";
            buyDamagePriceText.text = "Precio:";
            increaseDamageButtonText.text = "Comprar";
            actualDamageText.text = "Multiplicador actual:";
            returnSpecialStoreButtonText.text = "Volver";

            configurationMenuTitle.text = "Configuración";
            languageText.text = "Idioma:";
            masterText.text = "Volumen maestro:";
            musicText.text = "Música:";
            effectsText.text = "Efectos:";
            configurationMenuReturnButtonText.text = "Volver";

            highscoreTitleText.text = "Tabla de puntuaciones";
            positionTitle.text = "POSICIÓN";
            scoreTitle.text = "PUNTUACIÓN";
            nameTitle.text = "NOMBRE";
            returnHighscoreText.text = "Volver";

            languageChooseText.text = "Selecciona el idioma en el que quieres que esté el juego. \nPuedes cambiarlo cuando quieras en los ajustes.";
            firstLanguageButtonText.text = "Guardar";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            playButtonText.text = "Jolastu";
            storeButtonText.text = "Denda";
            configurationButtonText.text = "Konfigurazioa";
            highscoreButtonText.text = "Puntuazioak";
            exitButtonText.text = "Irten";

            storeMenuTitle.text = "Denda";
            arrowsButtonText.text = "Geziak";
            bowsButtonText.text = "Arkuak";
            specialButtonText.text = "Berezia";
            returnStoreButtonText.text = "Itzuli";

            arrowStoreTitle.text = "Geziak";
            regularArrowButtonText.text = "Gezi normalak";
            specialArrowButtonText.text = "Gezi bereziak";
            returnArrowStoreButtonText.text = "Itzuli";

            normalArrowsTitle.text = "Gezi normalak";
            buyNormalArrowsExplanationText.text = "Gezi mota bakoitzak etsai mota bateri min gehiago egiten dio eta atzerantz bultzatzen du. Geziak erosi 200 gastatuz.";
            blueArrowsText.text = "Gezi \nurdinak";
            greyArrowsText.text = "Gezi \ngrisak";
            greenArrowsText.text = "Gezi \nberdeak";
            redArrowsText.text = "Gezi \ngorriak";
            yellowArrowsText.text = "Gezi \nhoriak";
            brownArrowsText.text = "Gezi \nmarroiak";
            returnRegularArrowButtonText.text = "Itzuli";

            specialArrowsTitle.text = "Gezi bereziak";
            buySpecialArrowsExplanationText.text = "Ongi etorri gezi berezien dendara. Hemen hiru motako geziak erosi ahalko dituzu: bonbadun geziak, 100 txanpon, istanteko heriotzeko geziak, 100 txanpon, eta aingeruen geziak, 1000 txanpon. Lehengo biak mugatuak dira eta erabilera bakoitzarekin erosi beharko dituzu, 10 bonba eta 5 istanteko heriotz izan ditzakezu. Aingeruen gezien kasuan behin bakarrik erosi beharko dituzu.";
            bombArrowsText.text = "Bonbadun \ngeziak";
            instantKillArrowsText.text = "Istanteko heriotzeko geziak";
            angelicArrowText.text = "Aingeruen geziak";
            returnSpecialArrowStoreText.text = "Itzuli";

            bowStoreTitle.text = "Arkuak";
            bowStoreExplanationText.text = "Ongi etorri arkuen dendara. Arkuak erosteaz gain, leiho honetan zein arku erabili erabaki dezakezu. ";
            bow1Text.text = "Jokoko arku txarrena, baina doan da.";
            bow2Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu. Prezioa: 500";
            bow3Text.text = "Aurrekoaren berdina da, baina bi gezi jaurtitzen ditu baten beharrean. Prezioa: 1000";
            bow4Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu. Prezioa: 1500";
            bow5Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu berriz, zer espero zenuen, hauek jaistea? Prezioa: 2000";
            bow6Text.text = "Mina asko hobetzen du eta 3 gezi jaurtitzen ditu, zer gehiago eskatu ahal zaio? Prezioa: 3000";
            returnBowStoreButtonText.text = "Itzuli";

            specialStoreMenuTitle.text = "Artikulu bereziak";
            buyHighscoreText.text = "Puntuazio taula. \nPrezioa: 2000";
            buyHighscoreButtonText.text = "Erosi";
            buyDamageText.text = "0.1 gehitu min bidertzaileari.";
            buyDamagePriceText.text = "Prezioa:";
            increaseDamageButtonText.text = "Erosi";
            actualDamageText.text = "Momentuko bidertzailea:";
            returnSpecialStoreButtonText.text = "Itzuli";

            configurationMenuTitle.text = "Konfigurazioa";
            languageText.text = "Hizkuntza:";
            masterText.text = "Bolumen nagusia:";
            musicText.text = "Musika:";
            effectsText.text = "Efektuak:";
            configurationMenuReturnButtonText.text = "Itzuli";

            highscoreTitleText.text = "Puntuazio taula";
            positionTitle.text = "POSIZIOA";
            scoreTitle.text = "PUNTUAZIOA";
            nameTitle.text = "IZENA";
            returnHighscoreText.text = "Itzuli";

            languageChooseText.text = "Erabaki zein hizkuntzatan izan nahi duzun jolasa. \nNahi duzunean alda dezakezu ezarpenetan.";
            firstLanguageButtonText.text = "Gorde";
        }
    }

    //Function to change the language
    public void ChangeLanguage(bool first)
    {
        if (first) PlayerPrefs.SetInt("Language", LanguageChooseDropdown.value);
        else PlayerPrefs.SetInt("Language", LanguageDropdown.value);
        if (PlayerPrefs.GetInt("Language") == 0)
        {
            playButtonText.text = "Play";
            storeButtonText.text = "Store";
            configurationButtonText.text = "Configuration";
            highscoreButtonText.text = "High scores";
            exitButtonText.text = "Exit";

            storeMenuTitle.text = "Store";
            arrowsButtonText.text = "Arrows";
            bowsButtonText.text = "Bows";
            specialButtonText.text = "Special";
            returnStoreButtonText.text = "Return";

            arrowStoreTitle.text = "Arrows";
            regularArrowButtonText.text = "Normal arrows";
            specialArrowButtonText.text = "Special arrows";
            returnArrowStoreButtonText.text = "Return";

            normalArrowsTitle.text = "Normal arrows";
            buyNormalArrowsExplanationText.text = "Each type of arrow does more damage and pushes backwards one enemy class. Buy the arrows spending 200.";
            blueArrowsText.text = "Blue \narrows";
            greyArrowsText.text = "Grey \narrows";
            greenArrowsText.text = "Green \narrows";
            redArrowsText.text = "Red \narrows";
            yellowArrowsText.text = "Yellow \narrows";
            brownArrowsText.text = "Brown \narrows";
            returnRegularArrowButtonText.text = "Return";

            specialArrowsTitle.text = "Especial arrows";
            buySpecialArrowsExplanationText.text = "Welcome to the special arrow store. Here you can buy three types of arrow: bomb arrows (100 coins), instant kill arrows (100 coins) and angelic arrows (1000 coins). The first two are limited and you will need to buy them each time you use one, you can have 10 bomb arrows and 5 instant kill arrows. Speaking about angelic arrows, you will only need to buy them once.";
            bombArrowsText.text = "Bomb \narrows";
            instantKillArrowsText.text = "Instant kill arrows";
            angelicArrowText.text = "Angelic arrows";
            returnSpecialArrowStoreText.text = "Return";

            bowStoreTitle.text = "Bows";
            bowStoreExplanationText.text = "Welcome to the arrow store. You can buy and equip bows here.";
            bow1Text.text = "Games worst bow, but it’s free.";
            bow2Text.text = "Upgrades a bit the shooting speed and the damage. Price: 500";
            bow3Text.text = "It’s exactly the same as the previous one, but it shoots two arrows. Price: 1000";
            bow4Text.text = "It upgrades a bit the shooting speed and the damage. Price: 1500";
            bow5Text.text = "It upgrades again the shooting speed and the damage, did you expect it to worsen? Price: 2000";
            bow6Text.text = "It upgrades the damage a lot and it shoots three arrows, you can’t ask for more. Price: 3000";
            returnBowStoreButtonText.text = "Return";

            specialStoreMenuTitle.text = "Special articles";
            buyHighscoreText.text = "High scores. \nPrice: 2000";
            buyHighscoreButtonText.text = "Buy";
            buyDamageText.text = "Add 0.1 to the damage multiplier.";
            buyDamagePriceText.text = "Price:";
            increaseDamageButtonText.text = "Buy";
            actualDamageText.text = "Actual multiplier:";
            returnSpecialStoreButtonText.text = "Return";

            configurationMenuTitle.text = "Configuration";
            languageText.text = "Language:";
            masterText.text = "Main volume:";
            musicText.text = "Music:";
            effectsText.text = "Effects:";
            configurationMenuReturnButtonText.text = "Return";

            highscoreTitleText.text = "High scores";
            positionTitle.text = "POSITION";
            scoreTitle.text = "SCORE";
            nameTitle.text = "NAME";
            returnHighscoreText.text = "Return";

            languageChooseText.text = "Select the language you want the game to be. \nYou can change it whenever you want on the settings.";
            firstLanguageButtonText.text = "Save";
        }
        else if (PlayerPrefs.GetInt("Language") == 1)
        {
            playButtonText.text = "Jugar";
            storeButtonText.text = "Tienda";
            configurationButtonText.text = "Configuración";
            highscoreButtonText.text = "Puntuaciones";
            exitButtonText.text = "Salir";

            storeMenuTitle.text = "Tienda";
            arrowsButtonText.text = "Flechas";
            bowsButtonText.text = "Arcos";
            specialButtonText.text = "Especial";
            returnStoreButtonText.text = "Volver";

            arrowStoreTitle.text = "Flechas";
            regularArrowButtonText.text = "Flechas normales";
            specialArrowButtonText.text = "Flechas especiales";
            returnArrowStoreButtonText.text = "Volver";

            normalArrowsTitle.text = "Flechas normales";
            buyNormalArrowsExplanationText.text = "Cada tipo de flecha hace más daño a un tipo concreto de enemigo y le empuja hacia atrás. Para comprar las flechas realiza un único pago de 200.";
            blueArrowsText.text = "Flechas \nazules";
            greyArrowsText.text = "Flechas \ngrises";
            greenArrowsText.text = "Flechas \nverdes";
            redArrowsText.text = "Flechas \nrojas";
            yellowArrowsText.text = "Flechas \namarillas";
            brownArrowsText.text = "Flechas \nmarrones";
            returnRegularArrowButtonText.text = "Volver";

            specialArrowsTitle.text = "Flechas especiales";
            buySpecialArrowsExplanationText.text = "Bienvenido a la tienda de flechas especiales. Aquí podrás encontrar tres tipos de flecha: flechas bomba, 100 monedas, flechas de muerte instantánea, 100 monedas, y flechas angelicales, 1000 monedas. Las dos primeras son limitadas y tendrás que comprarlas con cada uso, 10 y 5 respectivamente. En el caso de las flechas angelicales solo tendrás que realizar una compra.";
            bombArrowsText.text = "Flechas \nbomba";
            instantKillArrowsText.text = "Flechas de muerte instantánea";
            angelicArrowText.text = "Flechas angelicales";
            returnSpecialArrowStoreText.text = "Volver";

            bowStoreTitle.text = "Arcos";
            bowStoreExplanationText.text = "Bienvenido a la tienda de arcos. Además de comprar los arcos en esta misma ventana puedes elegir el arco que usaras en el juego.";
            bow1Text.text = "El peor arco del juego, pero es gratis.";
            bow2Text.text = "Mejora un poco la velocidad de disparo y el daño. Precio: 500";
            bow3Text.text = "Es exactamente igual a su predecesor, pero lanza dos flechas en lugar de una. Precio: 1000";
            bow4Text.text = "Mejora ligeramente la velocidad de disparo y el daño. Precio: 1500";
            bow5Text.text = "Vuelve a mejorar ligeramente la velocidad de disparo y el daño, ¿qué esperabas, que bajaran? Precio: 2000";
            bow6Text.text = "Mejora ampliamente el daño y lanza 3 flechas, ¿qué más se le podría pedir? Precio: 3000";
            returnBowStoreButtonText.text = "Volver";

            specialStoreMenuTitle.text = "Artículos especiales";
            buyHighscoreText.text = "Tabla de puntuaciones. \nPrecio: 2000";
            buyHighscoreButtonText.text = "Comprar";
            buyDamageText.text = "Sumar 0.1 al multiplicador de daño.";
            buyDamagePriceText.text = "Precio:";
            increaseDamageButtonText.text = "Comprar";
            actualDamageText.text = "Multiplicador actual:";
            returnSpecialStoreButtonText.text = "Volver";

            configurationMenuTitle.text = "Configuración";
            languageText.text = "Idioma:";
            masterText.text = "Volumen maestro:";
            musicText.text = "Música:";
            effectsText.text = "Efectos:";
            configurationMenuReturnButtonText.text = "Volver";

            highscoreTitleText.text = "Tabla de puntuaciones";
            positionTitle.text = "POSICIÓN";
            scoreTitle.text = "PUNTUACIÓN";
            nameTitle.text = "NOMBRE";
            returnHighscoreText.text = "Volver";

            languageChooseText.text = "Selecciona el idioma en el que quieres que esté el juego. \nPuedes cambiarlo cuando quieras en los ajustes.";
            firstLanguageButtonText.text = "Guardar";
        }
        else if (PlayerPrefs.GetInt("Language") == 2)
        {
            playButtonText.text = "Jolastu";
            storeButtonText.text = "Denda";
            configurationButtonText.text = "Konfigurazioa";
            highscoreButtonText.text = "Puntuazioak";
            exitButtonText.text = "Irten";

            storeMenuTitle.text = "Denda";
            arrowsButtonText.text = "Geziak";
            bowsButtonText.text = "Arkuak";
            specialButtonText.text = "Berezia";
            returnStoreButtonText.text = "Itzuli";

            arrowStoreTitle.text = "Geziak";
            regularArrowButtonText.text = "Gezi normalak";
            specialArrowButtonText.text = "Gezi bereziak";
            returnArrowStoreButtonText.text = "Itzuli";

            normalArrowsTitle.text = "Gezi normalak";
            buyNormalArrowsExplanationText.text = "Gezi mota bakoitzak etsai mota bateri min gehiago egiten dio eta atzerantz bultzatzen du. Geziak erosi 200 gastatuz.";
            blueArrowsText.text = "Gezi \nurdinak";
            greyArrowsText.text = "Gezi \ngrisak";
            greenArrowsText.text = "Gezi \nberdeak";
            redArrowsText.text = "Gezi \ngorriak";
            yellowArrowsText.text = "Gezi \nhoriak";
            brownArrowsText.text = "Gezi \nmarroiak";
            returnRegularArrowButtonText.text = "Itzuli";

            specialArrowsTitle.text = "Gezi bereziak";
            buySpecialArrowsExplanationText.text = "Ongi etorri gezi berezien dendara. Hemen hiru motako geziak erosi ahalko dituzu: bonbadun geziak, 100 txanpon, istanteko heriotzeko geziak, 100 txanpon, eta aingeruen geziak, 1000 txanpon. Lehengo biak mugatuak dira eta erabilera bakoitzarekin erosi beharko dituzu, 10 bonba eta 5 istanteko heriotz izan ditzakezu. Aingeruen gezien kasuan behin bakarrik erosi beharko dituzu.";
            bombArrowsText.text = "Bonbadun \ngeziak";
            instantKillArrowsText.text = "Istanteko heriotzeko geziak";
            angelicArrowText.text = "Aingeruen geziak";
            returnSpecialArrowStoreText.text = "Itzuli";

            bowStoreTitle.text = "Arkuak";
            bowStoreExplanationText.text = "Ongi etorri arkuen dendara. Arkuak erosteaz gain, leiho honetan zein arku erabili erabaki dezakezu. ";
            bow1Text.text = "Jokoko arku txarrena, baina doan da.";
            bow2Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu. Prezioa: 500";
            bow3Text.text = "Aurrekoaren berdina da, baina bi gezi jaurtitzen ditu baten beharrean. Prezioa: 1000";
            bow4Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu. Prezioa: 1500";
            bow5Text.text = "Jaurtiketa abiadura eta mina pixka bat hobetzen ditu berriz, zer espero zenuen, hauek jaistea? Prezioa: 2000";
            bow6Text.text = "Mina asko hobetzen du eta 3 gezi jaurtitzen ditu, zer gehiago eskatu ahal zaio? Prezioa: 3000";
            returnBowStoreButtonText.text = "Itzuli";

            specialStoreMenuTitle.text = "Artikulu bereziak";
            buyHighscoreText.text = "Puntuazio taula. \nPrezioa: 2000";
            buyHighscoreButtonText.text = "Erosi";
            buyDamageText.text = "0.1 gehitu min bidertzaileari.";
            buyDamagePriceText.text = "Prezioa:";
            increaseDamageButtonText.text = "Erosi";
            actualDamageText.text = "Momentuko bidertzailea:";
            returnSpecialStoreButtonText.text = "Itzuli";

            configurationMenuTitle.text = "Konfigurazioa";
            languageText.text = "Hizkuntza:";
            masterText.text = "Bolumen nagusia:";
            musicText.text = "Musika:";
            effectsText.text = "Efektuak:";
            configurationMenuReturnButtonText.text = "Itzuli";

            highscoreTitleText.text = "Puntuazio taula";
            positionTitle.text = "POSIZIOA";
            scoreTitle.text = "PUNTUAZIOA";
            nameTitle.text = "IZENA";
            returnHighscoreText.text = "Itzuli";

            languageChooseText.text = "Erabaki zein hizkuntzatan izan nahi duzun jolasa. \nNahi duzunean alda dezakezu ezarpenetan.";
            firstLanguageButtonText.text = "Gorde";
        }
    }

    //Function to close the first language choose window
    public void CloseChooseLanguage()
    {
        LanguageSelectionMenu.SetActive(false);
        if (PlayerPrefs.GetInt("Language") == 0) LanguageDropdown.value = 0;
        else if (PlayerPrefs.GetInt("Language") == 1) LanguageDropdown.value = 1;
        else if (PlayerPrefs.GetInt("Language") == 2) LanguageDropdown.value = 2;
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

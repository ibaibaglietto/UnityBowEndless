using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endlessControllerScript : MonoBehaviour
{
    //The gameobjects of the enemies
    public GameObject blueMonster;
    public GameObject flyingMonster;
    public GameObject melonMonster;
    public GameObject plantMonster;
    public GameObject spikyMonster;
    public GameObject wormMonster;
    //The time the last monster spawned
    private float lastMonster;
    //The type of enemy that must spawn
    private int r;
    //The y the enemy will spawn
    private float ry;
    //The last y an enemy spawned
    private float lastRy;
    //an int to choose where the enemy must spawn, on the top or on the bot
    private int rtopbot;
    //The monster
    private GameObject monster;
    //The start time
    public float startTime;
    //The time between monster spawns
    private float monsterTime;
    //The life multiplier
    public float lifeMultiplyer;
    //The score
    private GameObject score;
    //The gained coins
    public float coinsGained;
    //The time the last coin was gained
    private float lastCoin;
    //The coins per second
    private float coinsPerSecond;

    
    void Start()
    {
        //We find the score
        score = GameObject.Find("Score");
        //We initialize the lastRy and the last Monser
        lastRy = -10.0f;
        lastMonster = -5.0f;
        //We initialize the start time and the last coin time
        startTime = Time.fixedTime;
        lastCoin = Time.fixedTime;
        //We initialize the coins gained and the coins per second
        coinsGained = 0;
        coinsPerSecond = 1.0f;
    }


    void Update()
    {
        //We gain coins each second and we gain 0.015 coins more each second 
        if((Time.fixedTime - lastCoin) >= 1.0f)
        {
            coinsGained += coinsPerSecond;
            lastCoin = Time.fixedTime;
            coinsPerSecond += 0.015f;
        }
        //The score is the seconds that passed from the beginning of the game
        score.GetComponent<Text>().text = ((int)(Time.fixedTime - startTime)).ToString();
        //Depending on how much time has passed the time between monster spawns will decrease and their life will increase
        if ((Time.fixedTime - startTime) < 15.0f)
        {
            monsterTime = 4.0f;
            lifeMultiplyer = 1.0f;
        }
        else if ((Time.fixedTime - startTime) < 30.0f)
        {
            monsterTime = 3.5f;
            lifeMultiplyer = 1.25f;
        }
        else if ((Time.fixedTime - startTime) < 45.0f)
        {
            monsterTime = 3.0f;
            lifeMultiplyer = 1.5f;
        }
        else if ((Time.fixedTime - startTime) < 60.0f)
        {
            monsterTime = 2.5f;
            lifeMultiplyer = 1.75f;
        }
        else if ((Time.fixedTime - startTime) < 75.0f)
        {
            monsterTime = 2.0f;
            lifeMultiplyer = 2.0f;
        }
        else if ((Time.fixedTime - startTime) < 90.0f)
        {
            monsterTime = 1.5f;
            lifeMultiplyer = 2.5f;
        }
        else if ((Time.fixedTime - startTime) < 105.0f)
        {
            monsterTime = 1.25f;
            lifeMultiplyer = 3.0f;
        }
        else
        {
            monsterTime = 1.0f;
            lifeMultiplyer = 3.0f + ((Time.fixedTime - startTime) - 105.0f) * 0.01f;
        }

        //There will be enemy waves depending on the time of the game choosing randomly some spawns
        if ((Time.fixedTime - lastMonster) > monsterTime)
        {
            if ((Time.fixedTime - startTime) < 15.0f) r = 1;
            else if ((Time.fixedTime - startTime) < 25.0f) r = 2;
            else if ((Time.fixedTime - startTime) < 35.0f) r = 3;
            else if ((Time.fixedTime - startTime) < 45.0f) r = 4;
            else if ((Time.fixedTime - startTime) < 52.0f) r = 5;
            else if ((Time.fixedTime - startTime) < 60.0f) r = 6;
            else if ((Time.fixedTime - startTime) < 70.0f) r = Random.Range(1, 3);
            else if ((Time.fixedTime - startTime) < 80.0f) r = Random.Range(3, 5);
            else if ((Time.fixedTime - startTime) < 90.0f) r = Random.Range(5, 7);
            else if ((Time.fixedTime - startTime) < 100.0f) r = Random.Range(1, 4);
            else if ((Time.fixedTime - startTime) < 110.0f) r = Random.Range(4, 7);
            else r = Random.Range(1, 7);
            //The spawn position will be random in a range depending on the last spawn
            if((lastRy < -4.5f) || (lastRy > 3.5f)) ry = Random.Range(-4.5f, 3.5f);
            else if (lastRy < -3.5f) ry = Random.Range(-2.5f, 3.5f);
            else if (lastRy > 2.5f) ry = Random.Range(-4.5f, 1.5f);
            //if the last spawn was on the center we will choose randomly a side and then randomly again the exact position
            else
            {
                rtopbot = Random.Range(1, 2);
                if (((rtopbot == 1) && lastRy>-2.5f) || (lastRy>1.5f))
                {
                    ry = Random.Range(-4.5f, lastRy - 2.5f);
                }
                else ry = Random.Range(lastRy + 1.5f, 3.5f);
            }
            //we will instantiate a monser depending on the r
            if (r == 1)
            {
                monster = Instantiate(blueMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            else if (r == 2)
            {
                monster = Instantiate(flyingMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            else if (r == 3)
            {
                monster = Instantiate(melonMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            else if (r == 4)
            {
                monster = Instantiate(plantMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            else if (r == 5)
            {
                monster = Instantiate(spikyMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            else if (r == 6)
            {
                monster = Instantiate(wormMonster, new Vector3(12.00f, ry, ry), Quaternion.identity);
            }
            //we save the monster type, the time it spawned and the position
            monster.GetComponent<mobScript>().type = r;
            lastMonster = Time.fixedTime;
            lastRy = ry;
        }
    }
}

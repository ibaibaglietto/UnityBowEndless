using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mobScript : MonoBehaviour
{
    //The type of the mob
    public int type;
    //The health of the mob
    public float health;
    //The max health of the mob
    public float maxHealth;
    //The last time the mob has hit
    public float hitTime;
    //The healthbar
    private GameObject healthBar;
    //The endless mode controller
    private GameObject endlessController;

    private void Start()
    {
        //We find the controller
        endlessController = GameObject.Find("EndlessController");
        //We put the max health depending on the mob type
        if (type == 1) maxHealth = 10.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        else if (type == 2) maxHealth = 11.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        else if (type == 3) maxHealth = 7.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        else if (type == 4) maxHealth = 9.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        else if (type == 5) maxHealth = 15.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        else if (type == 6) maxHealth = 12.0f * endlessController.GetComponent<endlessControllerScript>().lifeMultiplyer;
        //We initialize the last time the mob was hit
        hitTime = 0f;
        //We initialize the health
        health = maxHealth;
        //We find the healthbar
        healthBar = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
    }


    void Update()
    {
        //If the health is not the maximum we make the healthbar appear
        if (health != maxHealth) healthBar.transform.parent.gameObject.SetActive(true);
        //We update the healthbar every frame
        healthBar.GetComponent<Image>().fillAmount = health / maxHealth;     
        //If the mob is hit we push the enemies
        if(hitTime > Time.fixedTime) gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(3.0f, 0.0f);
        else gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);
    }
}

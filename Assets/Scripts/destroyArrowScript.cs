using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyArrowScript : MonoBehaviour
{
    //The bow
    private GameObject bow;
    //The type
    public int type;
    //The damages for every color
    private float damageRed;
    private float damageBrown;
    private float damageGrey;
    private float damageBlue;
    private float damageGreen;
    private float damageYellow;
    //The damage multiplier
    private float damageMultiplier;
    //Booleans to see if the players deals more damage to the color
    private bool doubleDamageRed;
    private bool doubleDamageBrown;
    private bool doubleDamageGrey;
    private bool doubleDamageBlue;
    private bool doubleDamageGreen;
    private bool doubleDamageYellow;
    //The explosion
    public GameObject explosion;
    private GameObject explode;

    /// <summary>
    /// flecha 1 = normal
    /// flecha 2 = brown damage
    /// flecha 3 = area damage   BOMB
    /// flecha 4 = green damage
    /// flecha 5 = yellow damage
    /// flecha 6 = instant kill
    /// flecha 7 = red damage
    /// flecha 8 = blue damage
    /// flecha 9 = grey damage
    /// flecha 10 = extra damage
    /// </summary>

    private void Start()
    {
        //We save the bow
        bow = GameObject.Find("bow");
        //We save the damage multiplier
        damageMultiplier = bow.GetComponent<bowScript>().damageMultipier;
        //We save the damages and the booleans of the damage depending on the type of the arrow
        if(type == 1)
        {
            damageBlue = 1.0f * damageMultiplier;
            damageRed = 1.0f * damageMultiplier;
            damageBrown = 1.0f * damageMultiplier;
            damageGrey = 1.0f * damageMultiplier;
            damageGreen = 1.0f * damageMultiplier;
            damageYellow = 1.0f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 2)
        {
            damageBlue = 0.8f * damageMultiplier;
            damageRed = 0.8f * damageMultiplier;
            damageBrown = 1.5f * damageMultiplier;
            damageGrey = 0.8f * damageMultiplier;
            damageGreen = 0.8f * damageMultiplier;
            damageYellow = 0.8f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = true;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 3)
        {
            damageBlue = 0.0f * damageMultiplier;
            damageRed = 0.0f * damageMultiplier;
            damageBrown = 0.0f * damageMultiplier;
            damageGrey = 0.0f * damageMultiplier;
            damageGreen = 0.0f * damageMultiplier;
            damageYellow = 0.0f * damageMultiplier;
            doubleDamageBlue = true;
            doubleDamageBrown = true;
            doubleDamageGreen = true;
            doubleDamageGrey = true;
            doubleDamageRed = true;
            doubleDamageYellow = true;
        }
        else if (type == 4)
        {
            damageBlue = 0.8f * damageMultiplier;
            damageRed = 0.8f * damageMultiplier;
            damageBrown = 0.8f * damageMultiplier;
            damageGrey = 0.8f * damageMultiplier;
            damageGreen = 1.5f * damageMultiplier;
            damageYellow = 0.8f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = true;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 5)
        {
            damageBlue = 0.8f * damageMultiplier;
            damageRed = 0.8f * damageMultiplier;
            damageBrown = 0.8f * damageMultiplier;
            damageGrey = 0.8f * damageMultiplier;
            damageGreen = 0.8f * damageMultiplier;
            damageYellow = 1.5f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = true;
        }
        else if (type == 6)
        {
            damageBlue = 0.0f * damageMultiplier;
            damageRed = 0.0f * damageMultiplier;
            damageBrown = 0.0f * damageMultiplier;
            damageGrey = 0.0f * damageMultiplier;
            damageGreen = 0.0f * damageMultiplier;
            damageYellow = 0.0f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 7)
        {
            damageBlue = 0.8f * damageMultiplier;
            damageRed = 1.5f * damageMultiplier;
            damageBrown = 0.8f * damageMultiplier;
            damageGrey = 0.8f * damageMultiplier;
            damageGreen = 0.8f * damageMultiplier;
            damageYellow = 0.8f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = true;
            doubleDamageYellow = false;
        }
        else if (type == 8)
        {
            damageBlue = 1.5f * damageMultiplier;
            damageRed = 0.8f * damageMultiplier;
            damageBrown = 0.8f * damageMultiplier;
            damageGrey = 0.8f * damageMultiplier;
            damageGreen = 0.8f * damageMultiplier;
            damageYellow = 0.8f * damageMultiplier;
            doubleDamageBlue = true;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = false;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 9)
        {
            damageBlue = 0.8f * damageMultiplier;
            damageRed = 0.8f * damageMultiplier;
            damageBrown = 0.8f * damageMultiplier;
            damageGrey = 1.5f * damageMultiplier;
            damageGreen = 0.8f * damageMultiplier;
            damageYellow = 0.8f * damageMultiplier;
            doubleDamageBlue = false;
            doubleDamageBrown = false;
            doubleDamageGreen = false;
            doubleDamageGrey = true;
            doubleDamageRed = false;
            doubleDamageYellow = false;
        }
        else if (type == 10)
        {
            damageBlue = 1.3f * damageMultiplier;
            damageRed = 1.3f * damageMultiplier;
            damageBrown = 1.3f * damageMultiplier;
            damageGrey = 1.3f * damageMultiplier;
            damageGreen = 1.3f * damageMultiplier;
            damageYellow = 1.3f * damageMultiplier;
            doubleDamageBlue = true;
            doubleDamageBrown = true;
            doubleDamageGreen = true;
            doubleDamageGrey = true;
            doubleDamageRed = true;
            doubleDamageYellow = true;
        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mob")
        {
            //If the arrow hits an enemy and it isnt a bomb nor an instant kill arrow we check the type of the enemy and apply the corresponding damage
            if (type != 6 && type != 3)
            {
                if ((collision.gameObject.GetComponent<mobScript>().type == 1) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageBlue;
                    if (doubleDamageBlue) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else if ((collision.gameObject.GetComponent<mobScript>().type == 2) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageGrey;
                    if (doubleDamageGrey) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else if ((collision.gameObject.GetComponent<mobScript>().type == 3) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageGreen;
                    if (doubleDamageGreen) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else if ((collision.gameObject.GetComponent<mobScript>().type == 4) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageRed;
                    if (doubleDamageRed) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else if ((collision.gameObject.GetComponent<mobScript>().type == 5) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageYellow;
                    if (doubleDamageYellow) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
                else if ((collision.gameObject.GetComponent<mobScript>().type == 6) && (collision.gameObject.GetComponent<mobScript>().health > 0.0f))
                {
                    collision.gameObject.GetComponent<mobScript>().health -= damageBrown;
                    if (doubleDamageBrown) collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.1f;
                    if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
            //If the arrow is an instant kill it destroys everything it touches
            else if (type == 6)
            {
                collision.gameObject.GetComponent<mobScript>().health -= collision.gameObject.GetComponent<mobScript>().health;
                if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
            }
            //If the arrow is a bomb it damages everything in an area
            else if (type == 3)
            {
                Destroy(gameObject);
                explode = Instantiate(explosion, transform.position, Quaternion.identity);
                explode.GetComponent<destroyExplosion>().damage = 4.0f * damageMultiplier;
                explode.GetComponent<Animator>().SetTrigger("explode");
            }
        }

    }

    //If the arrow gets too far away it self destroys
    void Update()
    {
        if (Mathf.Abs(bow.transform.position.x - transform.transform.position.x) + Mathf.Abs(bow.transform.position.y - transform.transform.position.y) > 25.0f) Destroy(gameObject);
    }


}

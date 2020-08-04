using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplosion : MonoBehaviour
{
    //The damage
    public float damage;

    //Function to destroy the explosion
    public void explode()
    {
        Destroy(gameObject);
    }
    //If an enemy touches the explosion it gets damaged
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "mob")
        {
            collision.gameObject.GetComponent<mobScript>().health -= damage;
            collision.gameObject.GetComponent<mobScript>().hitTime = Time.fixedTime + 0.3f;
            if (collision.gameObject.GetComponent<mobScript>().health <= 0.0f) Destroy(collision.gameObject);
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}

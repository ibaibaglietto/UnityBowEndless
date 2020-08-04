using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScript : MonoBehaviour
{
    //The world an touch points
    private Vector3 worldPoint;
    private Vector2 touchPos;
    //The finger count
    private int fingerCount;
    //The arrows
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject arrow7;
    public GameObject arrow8;
    public GameObject arrow9;
    public GameObject arrow10;
    //The arrows we are going to throw
    private GameObject arrowSolo;
    private GameObject arrowDuo;
    private GameObject arrowTrio;
    //The arrow speed
    private float arrowSpeed;
    //The arrow type
    public int arrowType = 1;
    //A bool to see if the carcaj is open
    public bool carcajOpen;
    //An int to see if the carcaj is closing
    public int carcajClosing;
    //The firing rate
    private float firingRate;
    //The time the last arrow was thrown
    private float lastArrow = -0.3f;
    //The arrow number
    private int arrowNumber;
    //The damage multiplier
    public float damageMultipier;
    //The screen height
    float h = Screen.height;
    //A bool to see if the game is paused
    public bool paused;
    //A bool to see if the player is dead
    public bool dead;
    //The explosion
    public GameObject explosion;
    //The sprites of the bows
    public Sprite bow1;
    public Sprite bow2;
    public Sprite bow3;
    public Sprite bow4;
    public Sprite bow5;
    public Sprite bow6;
    //The number of the bow
    public int bowNumber;
    //The canvas
    private GameObject canvas;

    private void Start()
    {
        //We save the bow number we are using
        bowNumber = PlayerPrefs.GetInt("UsingBow");
        //Find the canvas
        canvas = GameObject.Find("Canvas");
        //We save the sprite of the bow, the arrow number, the firing rate and the damage multiplier depending on the bow number
        if (bowNumber == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow1;
            arrowNumber = 1;
            firingRate = 0.3f;
            damageMultipier = 1.0f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        else if (bowNumber == 2) {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow2;
            arrowNumber = 1;
            firingRate = 0.25f;
            damageMultipier = 1.5f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        else if (bowNumber == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow3;
            arrowNumber = 2;
            firingRate = 0.25f;
            damageMultipier = 1.5f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        else if (bowNumber == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow4;
            arrowNumber = 2;
            firingRate = 0.2f;
            damageMultipier = 1.6f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        else if (bowNumber == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow5;
            arrowNumber = 2;
            firingRate = 0.15f;
            damageMultipier = 1.7f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        else if (bowNumber == 6)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bow6;
            arrowNumber = 3;
            firingRate = 0.15f;
            damageMultipier = 1.7f + PlayerPrefs.GetFloat("UpgradeMultiplier");
        }
        //We initialize the dead bool
        dead = false;
        Debug.Log(damageMultipier);
    }


        
    void Update()
    {
        if (!paused && !dead)
        {
            if (carcajOpen) Time.timeScale = 0.1f;
            else Time.timeScale = 1.0f;
            //We can change the arrows with the numbers
            if (Input.GetKeyDown(KeyCode.Alpha1)) arrowType = 1;
            if (Input.GetKeyDown(KeyCode.Alpha2)) arrowType = 2;
            if (Input.GetKeyDown(KeyCode.Alpha3)) arrowType = 3;
            if (Input.GetKeyDown(KeyCode.Alpha4)) arrowType = 4;
            if (Input.GetKeyDown(KeyCode.Alpha5)) arrowType = 5;
            if (Input.GetKeyDown(KeyCode.Alpha6)) arrowType = 6;
            if (Input.GetKeyDown(KeyCode.Alpha7)) arrowType = 7;
            if (Input.GetKeyDown(KeyCode.Alpha8)) arrowType = 8;
            if (Input.GetKeyDown(KeyCode.Alpha9)) arrowType = 9;
            if (Input.GetKeyDown(KeyCode.Alpha0)) arrowType = 10;
            //We save the arrow speed
            arrowSpeed = 10.0f;
            fingerCount = 0;
            //We save every touch and throw an arrow for each one if we can, depending on the firing rate
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                    fingerCount++;
                if ((fingerCount > 0) && ((Time.fixedTime - lastArrow) >= firingRate) && !carcajOpen)
                {
                    //If the arrow isn't a bomb nor an instant kill arrow
                    if (arrowType != 3 && arrowType != 6)
                    {
                        //We check how much arrows we must shoot. We will always save a rotation and a velocity to the arrow. 
                        //The direction will change a bit depending on the number of arrows we are shooting.
                        if (arrowNumber == 1)
                        {
                            Vector2 dir = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                            var rot = Quaternion.AngleAxis(angle, Vector3.forward);
                            if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot);
                            else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot);
                            else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot);
                            else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot);
                            else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot);
                            else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot);
                            else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot);
                            else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot);
                            else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot);
                            else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot);
                            transform.rotation = rot;
                            dir.Normalize();
                            arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowSolo.GetComponent<Rigidbody2D>().velocity = dir * arrowSpeed;
                        }
                        else if (arrowNumber == 2)
                        {
                            Vector2 dir1 = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y - 20.5f)) - transform.position;
                            var angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
                            var rot1 = Quaternion.AngleAxis(angle1, Vector3.forward);
                            if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot1);
                            else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot1);
                            else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot1);
                            else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot1);
                            else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot1);
                            else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot1);
                            else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot1);
                            else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot1);
                            else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot1);
                            else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot1);
                            transform.rotation = rot1;
                            dir1.Normalize();
                            arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowSolo.GetComponent<Rigidbody2D>().velocity = dir1 * arrowSpeed;
                            Vector2 dir2 = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y + 20.5f)) - transform.position;
                            var angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
                            var rot2 = Quaternion.AngleAxis(angle2, Vector3.forward);
                            if (arrowType == 1) arrowDuo = Instantiate(arrow1, transform.position, rot2);
                            else if (arrowType == 2) arrowDuo = Instantiate(arrow2, transform.position, rot2);
                            else if (arrowType == 3) arrowDuo = Instantiate(arrow3, transform.position, rot2);
                            else if (arrowType == 4) arrowDuo = Instantiate(arrow4, transform.position, rot2);
                            else if (arrowType == 5) arrowDuo = Instantiate(arrow5, transform.position, rot2);
                            else if (arrowType == 6) arrowDuo = Instantiate(arrow6, transform.position, rot2);
                            else if (arrowType == 7) arrowDuo = Instantiate(arrow7, transform.position, rot2);
                            else if (arrowType == 8) arrowDuo = Instantiate(arrow8, transform.position, rot2);
                            else if (arrowType == 9) arrowDuo = Instantiate(arrow9, transform.position, rot2);
                            else if (arrowType == 10) arrowDuo = Instantiate(arrow10, transform.position, rot2);
                            transform.rotation = rot2;
                            dir2.Normalize();
                            arrowDuo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowDuo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowDuo.GetComponent<Rigidbody2D>().velocity = dir2 * arrowSpeed;
                        }
                        else if (arrowNumber == 3)
                        {
                            Vector2 dir1 = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y - 20.5f)) - transform.position;
                            var angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
                            var rot1 = Quaternion.AngleAxis(angle1, Vector3.forward);
                            if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot1);
                            else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot1);
                            else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot1);
                            else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot1);
                            else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot1);
                            else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot1);
                            else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot1);
                            else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot1);
                            else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot1);
                            else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot1);
                            transform.rotation = rot1;
                            dir1.Normalize();
                            arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowSolo.GetComponent<Rigidbody2D>().velocity = dir1 * arrowSpeed;
                            Vector2 dir2 = Camera.main.ScreenToWorldPoint(new Vector2(touch.position.x, touch.position.y + 20.5f)) - transform.position;
                            var angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
                            var rot2 = Quaternion.AngleAxis(angle2, Vector3.forward);
                            if (arrowType == 1) arrowDuo = Instantiate(arrow1, transform.position, rot2);
                            else if (arrowType == 2) arrowDuo = Instantiate(arrow2, transform.position, rot2);
                            else if (arrowType == 3) arrowDuo = Instantiate(arrow3, transform.position, rot2);
                            else if (arrowType == 4) arrowDuo = Instantiate(arrow4, transform.position, rot2);
                            else if (arrowType == 5) arrowDuo = Instantiate(arrow5, transform.position, rot2);
                            else if (arrowType == 6) arrowDuo = Instantiate(arrow6, transform.position, rot2);
                            else if (arrowType == 7) arrowDuo = Instantiate(arrow7, transform.position, rot2);
                            else if (arrowType == 8) arrowDuo = Instantiate(arrow8, transform.position, rot2);
                            else if (arrowType == 9) arrowDuo = Instantiate(arrow9, transform.position, rot2);
                            else if (arrowType == 10) arrowDuo = Instantiate(arrow10, transform.position, rot2);
                            transform.rotation = rot2;
                            dir2.Normalize();
                            arrowDuo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowDuo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowDuo.GetComponent<Rigidbody2D>().velocity = dir2 * arrowSpeed;
                            Vector2 dir3 = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                            var angle3 = Mathf.Atan2(dir3.y, dir3.x) * Mathf.Rad2Deg;
                            var rot3 = Quaternion.AngleAxis(angle3, Vector3.forward);
                            if (arrowType == 1) arrowTrio = Instantiate(arrow1, transform.position, rot3);
                            else if (arrowType == 2) arrowTrio = Instantiate(arrow2, transform.position, rot3);
                            else if (arrowType == 3) arrowTrio = Instantiate(arrow3, transform.position, rot3);
                            else if (arrowType == 4) arrowTrio = Instantiate(arrow4, transform.position, rot3);
                            else if (arrowType == 5) arrowTrio = Instantiate(arrow5, transform.position, rot3);
                            else if (arrowType == 6) arrowTrio = Instantiate(arrow6, transform.position, rot3);
                            else if (arrowType == 7) arrowTrio = Instantiate(arrow7, transform.position, rot3);
                            else if (arrowType == 8) arrowTrio = Instantiate(arrow8, transform.position, rot3);
                            else if (arrowType == 9) arrowTrio = Instantiate(arrow9, transform.position, rot3);
                            else if (arrowType == 10) arrowTrio = Instantiate(arrow10, transform.position, rot3);
                            transform.rotation = rot3;
                            dir3.Normalize();
                            arrowTrio.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowTrio.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowTrio.GetComponent<Rigidbody2D>().velocity = dir3 * arrowSpeed;
                        }
                    }else
                    {
                        //If we are throwing bombs or instant kill arrows we will shoot one arrow
                        if ((arrowType == 3 && canvas.GetComponent<UIScript>().bombNumb > 0) || (arrowType == 6 && canvas.GetComponent<UIScript>().instantNumb > 0))
                        {
                            Vector2 dir = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
                            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                            var rot = Quaternion.AngleAxis(angle, Vector3.forward);
                            if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot);
                            else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot);
                            else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot);
                            else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot);
                            else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot);
                            else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot);
                            else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot);
                            else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot);
                            else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot);
                            else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot);
                            transform.rotation = rot;
                            dir.Normalize();
                            arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                            arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                            arrowSolo.GetComponent<Rigidbody2D>().velocity = dir * arrowSpeed;
                            if (arrowType == 3) canvas.GetComponent<UIScript>().bombNumb -= 1;
                            else if (arrowType == 6) canvas.GetComponent<UIScript>().instantNumb -= 1;
                        }
                        
                    }
                    //We save the time the last arrow was shot
                    lastArrow = Time.fixedTime;
                }
            }
            //We can shoot arrows using the mouse too
            if ((Input.GetMouseButtonDown(0)) && ((Time.fixedTime - lastArrow) >= firingRate) && !carcajOpen)
            {
                if (arrowType != 3 && arrowType != 6)
                {
                    if (arrowNumber == 1)
                    {
                        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        var rot = Quaternion.AngleAxis(angle, Vector3.forward);
                        if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot);
                        else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot);
                        else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot);
                        else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot);
                        else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot);
                        else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot);
                        else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot);
                        else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot);
                        else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot);
                        else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot);
                        transform.rotation = rot;
                        dir.Normalize();
                        arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowSolo.GetComponent<Rigidbody2D>().velocity = dir * arrowSpeed;
                    }
                    if (arrowNumber == 2)
                    {
                        Vector2 dir1 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - h * 0.02f, Input.mousePosition.z)) - transform.position;
                        var angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
                        var rot1 = Quaternion.AngleAxis(angle1, Vector3.forward);
                        if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot1);
                        else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot1);
                        else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot1);
                        else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot1);
                        else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot1);
                        else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot1);
                        else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot1);
                        else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot1);
                        else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot1);
                        else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot1);
                        transform.rotation = rot1;
                        dir1.Normalize();
                        arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowSolo.GetComponent<Rigidbody2D>().velocity = dir1 * arrowSpeed;
                        Vector2 dir2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + h * 0.02f, Input.mousePosition.z)) - transform.position;
                        var angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
                        var rot2 = Quaternion.AngleAxis(angle2, Vector3.forward);
                        if (arrowType == 1) arrowDuo = Instantiate(arrow1, transform.position, rot2);
                        else if (arrowType == 2) arrowDuo = Instantiate(arrow2, transform.position, rot2);
                        else if (arrowType == 3) arrowDuo = Instantiate(arrow3, transform.position, rot2);
                        else if (arrowType == 4) arrowDuo = Instantiate(arrow4, transform.position, rot2);
                        else if (arrowType == 5) arrowDuo = Instantiate(arrow5, transform.position, rot2);
                        else if (arrowType == 6) arrowDuo = Instantiate(arrow6, transform.position, rot2);
                        else if (arrowType == 7) arrowDuo = Instantiate(arrow7, transform.position, rot2);
                        else if (arrowType == 8) arrowDuo = Instantiate(arrow8, transform.position, rot2);
                        else if (arrowType == 9) arrowDuo = Instantiate(arrow9, transform.position, rot2);
                        else if (arrowType == 10) arrowDuo = Instantiate(arrow10, transform.position, rot2);
                        transform.rotation = rot2;
                        dir2.Normalize();
                        arrowDuo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowDuo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowDuo.GetComponent<Rigidbody2D>().velocity = dir2 * arrowSpeed;
                    }
                    if (arrowNumber == 3)
                    {
                        Vector2 dir1 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - h * 0.02f, Input.mousePosition.z)) - transform.position;
                        var angle1 = Mathf.Atan2(dir1.y, dir1.x) * Mathf.Rad2Deg;
                        var rot1 = Quaternion.AngleAxis(angle1, Vector3.forward);
                        if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot1);
                        else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot1);
                        else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot1);
                        else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot1);
                        else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot1);
                        else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot1);
                        else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot1);
                        else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot1);
                        else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot1);
                        else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot1);
                        transform.rotation = rot1;
                        dir1.Normalize();
                        arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowSolo.GetComponent<Rigidbody2D>().velocity = dir1 * arrowSpeed;
                        Vector2 dir2 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y + h * 0.02f, Input.mousePosition.z)) - transform.position;
                        var angle2 = Mathf.Atan2(dir2.y, dir2.x) * Mathf.Rad2Deg;
                        var rot2 = Quaternion.AngleAxis(angle2, Vector3.forward);
                        if (arrowType == 1) arrowDuo = Instantiate(arrow1, transform.position, rot2);
                        else if (arrowType == 2) arrowDuo = Instantiate(arrow2, transform.position, rot2);
                        else if (arrowType == 3) arrowDuo = Instantiate(arrow3, transform.position, rot2);
                        else if (arrowType == 4) arrowDuo = Instantiate(arrow4, transform.position, rot2);
                        else if (arrowType == 5) arrowDuo = Instantiate(arrow5, transform.position, rot2);
                        else if (arrowType == 6) arrowDuo = Instantiate(arrow6, transform.position, rot2);
                        else if (arrowType == 7) arrowDuo = Instantiate(arrow7, transform.position, rot2);
                        else if (arrowType == 8) arrowDuo = Instantiate(arrow8, transform.position, rot2);
                        else if (arrowType == 9) arrowDuo = Instantiate(arrow9, transform.position, rot2);
                        else if (arrowType == 10) arrowDuo = Instantiate(arrow10, transform.position, rot2);
                        transform.rotation = rot2;
                        dir2.Normalize();
                        arrowDuo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowDuo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowDuo.GetComponent<Rigidbody2D>().velocity = dir2 * arrowSpeed;
                        Vector2 dir3 = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        var angle3 = Mathf.Atan2(dir3.y, dir3.x) * Mathf.Rad2Deg;
                        var rot3 = Quaternion.AngleAxis(angle3, Vector3.forward);
                        if (arrowType == 1) arrowTrio = Instantiate(arrow1, transform.position, rot3);
                        else if (arrowType == 2) arrowTrio = Instantiate(arrow2, transform.position, rot3);
                        else if (arrowType == 3) arrowTrio = Instantiate(arrow3, transform.position, rot3);
                        else if (arrowType == 4) arrowTrio = Instantiate(arrow4, transform.position, rot3);
                        else if (arrowType == 5) arrowTrio = Instantiate(arrow5, transform.position, rot3);
                        else if (arrowType == 6) arrowTrio = Instantiate(arrow6, transform.position, rot3);
                        else if (arrowType == 7) arrowTrio = Instantiate(arrow7, transform.position, rot3);
                        else if (arrowType == 8) arrowTrio = Instantiate(arrow8, transform.position, rot3);
                        else if (arrowType == 9) arrowTrio = Instantiate(arrow9, transform.position, rot3);
                        else if (arrowType == 10) arrowTrio = Instantiate(arrow10, transform.position, rot3);
                        transform.rotation = rot3;
                        dir3.Normalize();
                        arrowTrio.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowTrio.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowTrio.GetComponent<Rigidbody2D>().velocity = dir3 * arrowSpeed;
                    }
                }else
                {
                    if ((arrowType == 3 && canvas.GetComponent<UIScript>().bombNumb > 0) || (arrowType == 6 && canvas.GetComponent<UIScript>().instantNumb > 0))
                    {
                        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                        var rot = Quaternion.AngleAxis(angle, Vector3.forward);
                        if (arrowType == 1) arrowSolo = Instantiate(arrow1, transform.position, rot);
                        else if (arrowType == 2) arrowSolo = Instantiate(arrow2, transform.position, rot);
                        else if (arrowType == 3) arrowSolo = Instantiate(arrow3, transform.position, rot);
                        else if (arrowType == 4) arrowSolo = Instantiate(arrow4, transform.position, rot);
                        else if (arrowType == 5) arrowSolo = Instantiate(arrow5, transform.position, rot);
                        else if (arrowType == 6) arrowSolo = Instantiate(arrow6, transform.position, rot);
                        else if (arrowType == 7) arrowSolo = Instantiate(arrow7, transform.position, rot);
                        else if (arrowType == 8) arrowSolo = Instantiate(arrow8, transform.position, rot);
                        else if (arrowType == 9) arrowSolo = Instantiate(arrow9, transform.position, rot);
                        else if (arrowType == 10) arrowSolo = Instantiate(arrow10, transform.position, rot);
                        transform.rotation = rot;
                        dir.Normalize();
                        arrowSolo.GetComponent<destroyArrowScript>().type = arrowType;
                        arrowSolo.GetComponent<destroyArrowScript>().explosion = explosion;
                        arrowSolo.GetComponent<Rigidbody2D>().velocity = dir * arrowSpeed;
                        if (arrowType == 3) canvas.GetComponent<UIScript>().bombNumb -= 1;
                        else if (arrowType == 6) canvas.GetComponent<UIScript>().instantNumb -= 1;
                    }
                }
                lastArrow = Time.fixedTime;

            }
            //We manage the carcaj closing
            if (carcajClosing > 1) carcajClosing -= 1;
            else if (carcajClosing == 1)
            {
                carcajClosing = 0;
                carcajOpen = false;
            }
        }
    }
}

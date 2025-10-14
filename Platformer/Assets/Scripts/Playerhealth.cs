using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Playerhealth : MonoBehaviour
{
    //store the players health
    public float health = 10;
    float maxHealth;
    //we needa reference to our healthbar game object
    public Image healthBar;
    //if we collide with tagged enemies, take damage
    //if 0 health, die(reload level)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);  
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets to low, die
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            healthBar.fillAmount = health / maxHealth;
            //if health gets to low, die
            if (health <=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        //if we collide with health pack
        if(collision.gameObject.tag == "HealthPack")
        {
            health++;
            if (health >maxHealth)
            {
                health--;
            }
            healthBar.fillAmount = health / maxHealth;
        }
        if (collision.gameObject.tag == "EnemyBullet")
        {
            health--;
            
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
        healthBar.fillAmount = health / maxHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        healthBar.fillAmount = health / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

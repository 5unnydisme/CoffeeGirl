using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int health;

    public SpriteRenderer playerSr;
    public PlayerMovement2D playerMovement; 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            playerSr.enabled = false;
            playerMovement.enabled = false; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}


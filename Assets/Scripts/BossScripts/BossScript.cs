using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    public static int health = 300;
    public int healthBar = 300;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeText.text = healthBar + "%";
        healthBar = health;
        Die();
    }

    //health reduction
    public static void TakeDamage(int damage)
    {
        health -= damage;
    }

    public void Die()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("MainScene");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Weapon")
        {
            TakeDamage(10);
        }
    }
}

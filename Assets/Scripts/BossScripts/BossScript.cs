using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    public static int health = 100;
    public int healthBar = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

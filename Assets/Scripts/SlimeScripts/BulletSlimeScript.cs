using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSlimeScript : MonoBehaviour
{
    public float timeDestroy = 0.5f;
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Terrain") {
            Destroy(gameObject);
        }    
    }
}

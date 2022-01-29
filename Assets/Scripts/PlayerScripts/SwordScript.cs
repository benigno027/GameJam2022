using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public LayerMask actionMask;
    private bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isAttacking)
            {
                isAttacking = true;
                StartCoroutine(Attack());
            }
        }
    }

    IEnumerator Attack()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        isAttacking = false;
    }


    public string [] tagsToAttack = { "Enemy", "BossFireBall", "BulletSlime" };
    void OnTriggerEnter2D(Collider2D other)
    {
        foreach (string tag in tagsToAttack)
        {
            if (other.gameObject.tag == tag)
            {
                destroyObject(other.gameObject);
            }
        }
    }

    void destroyObject( GameObject other)
    {
        Destroy(other);
    }

}
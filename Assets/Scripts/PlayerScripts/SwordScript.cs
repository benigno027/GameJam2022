using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public LayerMask actionMask;
    private bool isAttacking = false;

    public GameObject playerGameObject;
    [SerializeField]
    Animator animator;
    const string STATE_PLAYER_ATTACK = "isPlayerAttack";

    void Awake()
    {
        animator = playerGameObject.GetComponent<Animator>();
    }

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
        animator.SetBool(STATE_PLAYER_ATTACK, true);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool(STATE_PLAYER_ATTACK, false);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBallScript : MonoBehaviour
{

    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    public float rangeSeePlayer = 5f;
    Rigidbody2D rigidBody;
    public float runningSpeed = 10f;
    public bool isMovingLeft = false;
    public LayerMask actionMask;

    public bool isFollowingPlayer = false;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0,2) == 0)
        {
            isMovingLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        raycast();
        if (this.isMovingLeft)
        {
            rigidBody.velocity = new Vector2(-1 * runningSpeed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(runningSpeed, rigidBody.velocity.y);
        }
    }

    void raycast()
    {
        hitLeft = Physics2D.Raycast(this.transform.position, Vector2.left, rangeSeePlayer, actionMask);
        hitRight = Physics2D.Raycast(this.transform.position, Vector2.right, rangeSeePlayer, actionMask);

        Debug.DrawRay(this.transform.position, Vector2.left * rangeSeePlayer, Color.green);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Player")
            {
                isMovingLeft = true;
                following_player();
            }
        }

        Debug.DrawRay(this.transform.position, Vector2.right * rangeSeePlayer, Color.green);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Player")
            {
                isMovingLeft = false;
                following_player();
            }
        }
    }

    void following_player()
    {
        if (!isFollowingPlayer)
        {
            isFollowingPlayer = true;
            destroy_self();
        }
    }

    //self destroy after 2 seconds
    void destroy_self()
    {
        Destroy(gameObject, 2f);
    }


}

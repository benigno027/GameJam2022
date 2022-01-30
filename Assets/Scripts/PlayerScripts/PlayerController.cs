using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Variables del movimiento del personaje
    public float jumpForce = 6f;
    public float runningSpeed = 2f;
    Rigidbody2D rigidBody;
    Animator animator;

    const string STATE_ON_THE_GROUND = "isOnTheGround";
    const string STATE_PLAYER_RUN = "isPlayerRun";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start()
    {
        animator.SetBool(STATE_ON_THE_GROUND, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        if(horizontalMovement != 0)
        {
            Run(horizontalMovement);
        }
        else
        {
            StopRun();
        }
        
    }


    void FixedUpdate()
    {


    }

    
    void Run(float horizontalMovement)
    {
        animator.SetBool(STATE_PLAYER_RUN, true);
        rigidBody.velocity = new Vector2(horizontalMovement * runningSpeed, rigidBody.velocity.y);
    }

    void StopRun()
    {
        animator.SetBool(STATE_PLAYER_RUN, false);
    }


    public string[] tagsToDamage = { "Enemy", "BossFireBall", "BulletSlime" };
    private void OnCollisionEnter2D(Collision2D other)
    {

        foreach (string tag in tagsToDamage)
        {
            if (other.gameObject.tag == tag)
            {
                CharacterLifeScript.collisionDamage();
                Destroy(other.gameObject);
            }
        }
    }

    void Jump()
    {
        if (IsTouchingTheGround())
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //Nos indica si el personaje está o no tocando el suelo
    bool IsTouchingTheGround()
    {
        if (Physics2D.Raycast(this.transform.position,
                             Vector2.down,
                             2f,
                             groundMask))
        {
            //TODO: programar lógica de contacto con el suelo
            
            return true;
        }
        else
        {
            //TODO: programar lógica de no contacto
            return false;
        }
    }

    public void killPlayer()
    {
        Destroy(this.gameObject);
    }

    void attack_weapon()
    {

    }

}

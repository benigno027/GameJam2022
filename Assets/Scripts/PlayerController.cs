using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Variables del movimiento del personaje
    public float jumpForce = 6f;
    public float runningSpeed = 2f;

    Rigidbody2D rigidBody;
    Animator animator;

    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask groundMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
        // animator.SetBool(STATE_ALIVE, true);
        // animator.SetBool(STATE_ON_THE_GROUND, true);
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        // animator.SetBool(STATE_ON_THE_GROUND, IsTouchingTheGround());
	}

    
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        gameObject.GetComponent<SpriteRenderer>().flipX = horizontalMovement < 0;
        rigidBody.velocity = new Vector2(horizontalMovement * runningSpeed, rigidBody.velocity.y);

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "BulletSlime") {
            CharacterLifeScript.collisionDamage();
            Destroy(other.gameObject);
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
    bool IsTouchingTheGround(){
        if(Physics2D.Raycast(this.transform.position,
                             Vector2.down,
                             1.5f, 
                             groundMask)){
            //TODO: programar lógica de contacto con el suelo
            return true;
        }else {
            //TODO: programar lógica de no contacto
            return false;
        }
    }

    public void killPlayer(){
        Destroy(this.gameObject);
    }

}

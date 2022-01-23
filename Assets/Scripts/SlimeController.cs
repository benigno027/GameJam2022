using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float rangeMovement = 0.5f;
    public bool isMovingLeft = false;
    public float jumpForce = 6f;
    public float runningSpeed = 0.5f;
    public float timeRemaining = 3;
    public GameObject bulletSlime;
    public float bulletForce = 10f;
    public float shootTimeRemaining = 3f;
    public bool isShooting = false;
    RaycastHit2D hitLeft;
    RaycastHit2D hitRight;
    Rigidbody2D rigidBody;
    Animator animator;
    const string STATE_ALIVE = "isAlive";
    const string STATE_ON_THE_GROUND = "isOnTheGround";

    public LayerMask actionMask;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slimMovement();
        raycast();
        shootTimer();
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            CharacterLifeScript.collisionDamage();
        }   
    }

    void slimMovement()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            this.isMovingLeft = !this.isMovingLeft;
            timeRemaining = 3;
        }

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
        hitLeft = Physics2D.Raycast(this.transform.position, Vector2.left, 2f, actionMask);
        hitRight = Physics2D.Raycast(this.transform.position, Vector2.right, 2f, actionMask);

        Debug.DrawRay(this.transform.position, Vector2.left * 2f, Color.green);
        if (hitLeft.collider != null)
        {
            if (hitLeft.collider.tag == "Player")
            {
                if (!isShooting)
                {
                    shoot(150f);
                }
            }
        }

        Debug.DrawRay(this.transform.position, Vector2.right * 2f, Color.green);
        if (hitRight.collider != null)
        {
            if (hitRight.collider.tag == "Player")
            {
                if (!isShooting)
                {
                    shoot(30f);
                }
            }
        }
    }

    void shootTimer()
    {
        if (shootTimeRemaining > 0)
        {
            shootTimeRemaining -= Time.deltaTime;
        }
        else
        {
            this.isShooting = false;
            shootTimeRemaining = 3;
        }
    }

    void shoot(float shooting_angle)
    {
        this.isShooting = true;

        float xcomponent = Mathf.Cos(shooting_angle * Mathf.PI / 180) * bulletForce;
        float ycomponent = Mathf.Sin(shooting_angle * Mathf.PI / 180) * bulletForce;

        GameObject bullet = Instantiate(bulletSlime, this.transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(xcomponent, ycomponent), ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSkillsScript : MonoBehaviour
{

    public GameObject rigthHand;

    public GameObject leftHand;

    public GameObject fireBall;

    public bool isShooting = false;
    public float shootTimeRemaining = 3f;
    private float shootTimeRemainingStatic;

    // Start is called before the first frame update
    void Start()
    {
        shootTimeRemainingStatic = shootTimeRemaining;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer();
        if (!this.isShooting)
        {
            this.isShooting = true;
            fireBallSkill();
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
            shootTimeRemaining = shootTimeRemainingStatic;
        }
    }

    public void fireBallSkill()
    {
        if (Random.Range(0, 2) == 0)
        {
            GameObject fireBallClone = Instantiate(fireBall, rigthHand.transform.position, rigthHand.transform.rotation);
        }
        else
        {
            GameObject fireBallClone = Instantiate(fireBall, leftHand.transform.position, leftHand.transform.rotation);
        }
    }
}

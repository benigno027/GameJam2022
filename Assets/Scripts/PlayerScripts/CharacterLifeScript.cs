using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterLifeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController player;
    public Text lifeText;
    public float timeRemaining = 10;
    static int lifePlayer = 100;

    private void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateRemainingTime();
        lifeText.text = "Life: " + lifePlayer + "%";
    }

    private void FixedUpdate()
    {
        stopScene();
    }

    //Nos calcula el tiempo restante para el descuento de vida
    void CalculateRemainingTime()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            UpdateLife();
            timeRemaining = 10;
        }
    }

    //Nos indica la vida del personaje
    public void UpdateLife()
    {
        lifePlayer--;
    }

    //Le reduce la vida al personaje en caso de una colision
    static public void collisionDamage()
    {
        lifePlayer -= 10;
    }

    static public void criticalDamage(int damage)
    {
        lifePlayer = damage;
    }


    //Si la vida del personaje llega a 0, se detiene la escena
    void stopScene()
    {
        if (lifePlayer <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}

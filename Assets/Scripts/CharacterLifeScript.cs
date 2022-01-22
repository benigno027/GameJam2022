using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterLifeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController player;
    public Text lifeText;
    public float timeRemaining = 10;
    private int lifePlayer = 100;

    private void Awake()
    {

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    private void FixedUpdate()
    {

    }

    public void UpdateLife()
    {
        lifePlayer--;
        lifeText.text = "Life: " + lifePlayer + "%";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int points;

    public Sprite brokenGear;
    public Sprite gear;
    public Image[] gears;
    public GameObject score;
    public GameObject gameOverScreen;

    public PlayerController playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        score.GetComponent<Text>().text = "0";
        
        maxHealth = playerHealth.maxHealthPoints;
        for (int i = 0; i < gears.Length; i++)
        {
            if (i < maxHealth)
            {
                gears[i].enabled = true;
            }
            else
            {
                gears[i].enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.healthPoints;

        for (int i = 0; i < gears.Length; i++)
        {
            if (i < health)
            {
                gears[i].sprite = gear;
            }
            else
            {
                gears[i].sprite = brokenGear;
            }
            
        }

        points = playerHealth.points;
        score.GetComponent<Text>().text = points.ToString();

        if (health <= 0)
        {
            gameOverScreen.SetActive(true);
        }
    }
}

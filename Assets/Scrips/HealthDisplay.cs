using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    public int health;

    [SerializeField]
    public int maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    public PlayerHealth playerHealth;

    void Update()
    {
        health = playerHealth.health;
        maxHealth = playerHealth.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled =false;
            }
        }
    }
}

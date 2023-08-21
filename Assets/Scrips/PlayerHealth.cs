using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;
    public event EventHandler MuerteJugador;

    public SpriteRenderer playerSr;
    public Character2DController playerMovement;


    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            playerSr.enabled = false;
            playerMovement.enabled = false; 

        }
    }
}

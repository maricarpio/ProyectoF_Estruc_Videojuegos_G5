using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    float health = 100.0F;

    public event EventHandler MuerteJugador;

    public void TakeDamage(float damage)
    {
        health -= Mathf.Abs(damage);

        if (health <= 0)
        {
            MuerteJugador?.Invoke(this,EventArgs.Empty);
            Destroy(gameObject);

        }
    }

}

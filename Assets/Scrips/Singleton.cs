using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;

    // Propiedades y campos necesarios para el funcionamiento del juego
    public int Score { get; set; }
    public bool IsPaused { get; private set; }

    private GameManager()
    {
        // Constructor privado para evitar instanciación externa
        Score = 0;
        IsPaused = false;
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    public void PauseGame()
    {
        IsPaused = true;
        // Lógica para pausar el juego
    }

    public void ResumeGame()
    {
        IsPaused = false;
        // Lógica para reanudar el juego
    }
}
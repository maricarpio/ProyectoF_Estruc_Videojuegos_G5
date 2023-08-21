using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;

    public Animator animator;

    public float health { get; private set; }

    private void Start()
    {
        life = hearts.Length;
    }

    public void Update()
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("hit");

        }

        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("hit");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("hit");

        }
    }

    public void TakeDamage(float damage)
    {
        health -= Mathf.Abs(damage);

        if (health <= 0)
        {
            Destroy(gameObject);

        }
    }

    public void PlayerDamage()
    {
        life--;
    }
}

 

    


   

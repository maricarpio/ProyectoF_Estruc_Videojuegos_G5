using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeleeController : MonoBehaviour
{

    readonly object _lock = new object();
    static MeleeController _instance;

    public static MeleeController Instance
    {
        get
        {
            return _instance;
        }
    }


    [SerializeField]
    Transform attackPoint;

    [SerializeField]
    float attackRadius = 1.5F;

    [SerializeField]
    Animator animator;

    [SerializeField]
    float damage = 50.0F;

    [HideInInspector]
    public UnityEvent onAttack;

     void Awake()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = this;
                }
            }
        }
        onAttack.AddListener(OnAttack);
    }

  

    void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("melee");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
    }


    void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius);

        foreach(Collider2D collider in colliders)
        {
            HealthController controller = collider.GetComponent<HealthController>();  
            if (controller != null)
            {
                controller.TakeDamage(damage);
            }
        }
    }
}

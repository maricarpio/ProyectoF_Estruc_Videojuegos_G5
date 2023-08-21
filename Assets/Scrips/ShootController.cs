using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootController : MonoBehaviour
{
    readonly object _lock = new object();
    static ShootController _instance;

    public static ShootController Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletSpeed = 100.0F;

    [SerializeField]
    float bulletLifeTime= 5.0F;

    [SerializeField]
    int fireRate = 3;

    [SerializeField]
    Animator animator;

    [HideInInspector]
    public UnityEvent onFire;

    float _nextFireTime = 0.0F;

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
        onFire.AddListener(OnFire);
    }

    void Update()
    {
        if (Input.GetButtonUp("Fire2") && Time.time > _nextFireTime)
        {
            _nextFireTime = Time.time + 1.0F / fireRate;
            animator.SetTrigger("fire");
        }
    }

    void OnFire()
    {
        animator.ResetTrigger("fire");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed * Time.deltaTime;
        Destroy(bullet, bulletLifeTime);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed; 

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
        
    }

    private void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else {
            rb.velocity = new Vector2 (-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5F && currentPoint == pointB.transform) 
        {
            flip();
            currentPoint = pointA.transform;

        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5F && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;

        }
    }

    private void flip() 
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5F);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5F);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }*/
    
}

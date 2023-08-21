using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AgrroController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;


    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;



        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1); 
            }
        }
    }

}

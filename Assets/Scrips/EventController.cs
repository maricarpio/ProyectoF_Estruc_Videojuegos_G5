using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public void OnAttack()
    {
        MeleeController.Instance.onAttack.Invoke();
    }

    public void OnFire()
    {
        ShootController.Instance.onFire.Invoke();   
    }
}

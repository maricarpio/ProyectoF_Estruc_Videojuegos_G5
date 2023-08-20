using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public void OnAttack()
    {
        MeleeController.Instance.onAttack.Invoke();
    }
}

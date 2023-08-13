using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI timerText;

    [SerializeField]
    float remainingTime = 90.0F;

    float elapsedTime;

    bool _isRemainingTime;


    void Start()
    {
        _isRemainingTime = remainingTime > 0.0F;
    }

    void Update()
    {
        if (_isRemainingTime)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0.0F)
            {
                remainingTime = 0.0F;
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            elapsedTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float targetTime = 60.0f;
    private bool timerEnded = false;

    void Update() {

        if (!timerEnded) {
            targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded = true;
            Debug.Log("Timer ended.");
        }
        }
    }

    public bool timeIsUp() {
        return timerEnded;
    }
}

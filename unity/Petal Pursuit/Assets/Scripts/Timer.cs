using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float targetTime = 60.0f;
    private bool timerEnded = false;
    
    [SerializeField]
    private TextMeshProUGUI timerText; // Reference to UI text component
    
    [SerializeField]
    private Image messageBackground; // Reference to background UI image
    
    // Time intervals for messages (in seconds from start)
    private float[] messageIntervals = new float[] { 60.0f, 30.0f, 15.0f, 5.0f };
    private string[] messageTexts = new string[] {
        "60 seconds remaining!",
        "30 seconds left!",
        "Hurry up! 15 seconds left!",
        "Final countdown: 5 seconds!"
    };
    private int currentIntervalIndex = 0;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogWarning("Timer Text reference not set! Please assign in inspector.");
        }
        if (messageBackground == null)
        {
            Debug.LogWarning("Message Background image not set! Please assign in inspector.");
        }
        else
        {
            messageBackground.enabled = false; // Hide background initially
        }
        
        // Hide text initially
        if (timerText != null)
        {
            timerText.enabled = false;
        }
    }

    void Update()
    {
        if (!timerEnded)
        {
            targetTime -= Time.deltaTime;

            // Check for interval messages
            if (currentIntervalIndex < messageIntervals.Length && 
                targetTime <= messageIntervals[currentIntervalIndex])
            {
                ShowTimerMessage(currentIntervalIndex);
                currentIntervalIndex++;
            }

            if (targetTime <= 0.0f)
            {
                timerEnded = true;
                Debug.Log("Timer ended.");
            }
        }
    }

    private void ShowTimerMessage(int index)
    {
        if (timerText != null && index >= 0 && index < messageTexts.Length)
        {
            StartCoroutine(ShowMessageTemporarily(messageTexts[index]));
        }
    }

    private IEnumerator ShowMessageTemporarily(string message)
    {
        // Show message and background
        if (messageBackground != null)
        {
            messageBackground.enabled = true;
        }
        if (timerText != null)
        {
            timerText.enabled = true;
            timerText.text = message;
        }
        
        yield return new WaitForSeconds(2.0f); // Show message for 2 seconds
        
        // Hide background and text
        if (!timerEnded)
        {
            if (messageBackground != null)
            {
                messageBackground.enabled = false;
            }
            if (timerText != null)
            {
                timerText.enabled = false;
            }
        }
    }

    public bool timeIsUp()
    {
        return timerEnded;
    }
}

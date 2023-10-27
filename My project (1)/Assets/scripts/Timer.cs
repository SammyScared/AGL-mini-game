/*

    This script adds a timer to the game. 
    When the timer ends, the game restarts.

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown;

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit))) 
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            
            if (currentTime <= 0)
            {
                player.transform.position = respawnPoint.transform.position;
                Physics.SyncTransforms();
                Debug.Log("Player Respawned");
            }
            
            //Application.Quit();
            //Debug.Log("Application Quitted");
            enabled = false;
        }

        SetTimerText();
    }

    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }


}

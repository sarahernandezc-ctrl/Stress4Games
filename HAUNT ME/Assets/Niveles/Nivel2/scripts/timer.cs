using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer_Text;
    //[SerializeField] 
    public float TimeRemaining;

    public bool StartTimer = false;

    //bool pauseMenu = false;     Cuando esten los menús.

    // Update is called once per frame
    void Update()
    {

        if (StartTimer)
        {
            if (TimeRemaining > 0.0f)
            {
                TimeRemaining -= Time.deltaTime;
            }
            else if (TimeRemaining < 0.0f)
            {
                TimeRemaining = 0.0f;
                //Time.timeScale = 0.0f;
            }
            int minutes = Mathf.FloorToInt(TimeRemaining / 60);
            int seconds = Mathf.FloorToInt(TimeRemaining % 60);
            timer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}

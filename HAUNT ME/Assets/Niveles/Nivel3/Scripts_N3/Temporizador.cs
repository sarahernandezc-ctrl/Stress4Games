using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    
   //bool pauseMenu = false;     Cuando esten los menús.

    // Update is called once per frame
    void Update()
    {



        if (remainingTime > 0) 
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            Time.timeScale = 0.0f;
        }
        int minutes =  Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /*public void Pause()   //Cuando esten los menús
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }*/

    /*public void Resume()   //Cuando esten los menús
   {
       pauseMenu.SetActive(false);
       Time.timeScale = 1;
   }*/

}

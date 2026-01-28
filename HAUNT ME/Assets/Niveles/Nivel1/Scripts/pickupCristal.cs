using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class pickupCristal : MonoBehaviour
{
    //Nerea
    // script para recoger cristales, contador, y que te permita atravesar la puerta

    public bool Can_UseInputs2;

    //cristales
    public GameObject cristal;
    public float Cristal_Points;
    public GameObject videoMemory;
    public float timer;
    public bool videoPlaying;
    //puerta
    public GameObject puerta;
    public bool open;
    //Sara

    //CristalDataSave

    public SaveData savedata;
    public float CristalSave_points;

    // Start is called before the first frame update
    void Start()
    {
        Can_UseInputs2 = true;
        open = false;
        videoMemory.SetActive(false);
        videoPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlaying == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                timer = 0.0f;
                videoMemory.SetActive(false);
                videoPlaying = false;
            }
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        //cuando toque el cristal1, o el 2, o el 3
        if (other.CompareTag("cristal0"))
        {
            //se añade un punto
            Cristal_Points++;
            //y se desactiva el objeto para que no se pueda a volver a uasr el mismo
            other.gameObject.SetActive(false);
            Debug.Log("He detectado un cristal. Total: " + Cristal_Points);
            videoMemory.SetActive(true);
            videoPlaying = true;

        }

        if ((other.gameObject.CompareTag("puerta")) && Cristal_Points >= 1)
        {
            open = true;

            if (open == true)
            {
                SceneManager.LoadScene(4);
                Time.timeScale = 0.0f;
            }
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
    public void SaveCristals()
    {
        PlayerPrefs.SetFloat("Cristales", Cristal_Points);
        Debug.Log("GUARDADO");
    }
    public void LoadCristals()
    {
        CristalSave_points = PlayerPrefs.GetFloat("Cristales");
        Cristal_Points = CristalSave_points;
        Debug.Log("Cargado");
    }
}

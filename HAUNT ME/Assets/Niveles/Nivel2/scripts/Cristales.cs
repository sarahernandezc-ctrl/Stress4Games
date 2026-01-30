using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Cristales : MonoBehaviour
{
    //Nerea
    // script para recoger cristales, contador, y que te permita atravesar la puerta

    public bool Can_UseInputs;

    [Header("CRISTALES")]
    //cristales
    public TMP_Text cristales;
    public float puntos_cristales;
    public GameObject cristal;
    public GameObject cristal2;
    public GameObject cristal3;
    public GameObject memory;
    public float timer;
    public bool memoryplaying;

    [Header("PUERTA")]
    //puerta
    public GameObject puerta;
    public bool abrir;
    public bool apagar;

    [Header("guardar")]
    public float guardado_cristales;
    

    // Start is called before the first frame update
    void Start()
    {
        apagar = false;

        Can_UseInputs = true;

        abrir = false;

        memory.SetActive(false);
        memoryplaying = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (apagar == false)
        {
            cristales.text = "Crystals: " + puntos_cristales;

            if (memoryplaying == true)
            {
                timer -= Time.deltaTime;
                if (timer <= 0.0f)
                {
                    timer = 0.0f;
                    memory.SetActive(false);
                }
            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        //cuando toque el cristal1, o el 2, o el 3
        if (other.CompareTag("cristal") || other.CompareTag("cristal2") || other.CompareTag("cristal3"))
        {
            //se añade un punto
            puntos_cristales++;
            //y se desactiva el objeto para que no se pueda a volver a uasr el mismo
            other.gameObject.SetActive(false);
            Debug.Log("He detectado un cristal. Total: " + puntos_cristales);

            if ( puntos_cristales >= 3)
            {
                apagar = true;

                if (apagar == true)
                {
                    memory.SetActive(true);
                    memoryplaying = true;
                }
                
            }

            apagar = false;
           
        }

        if ( (other.gameObject.CompareTag("puertaa")) && puntos_cristales >= 3 )
        { 
            abrir = true;

            if (abrir == true)
            {
                SceneManager.LoadScene(3);
            }
        }

       
    }

    public void Savecristals()
    {
        PlayerPrefs.SetFloat("Cristales" , puntos_cristales);

    }


    public void Loadcristals()
    {
        guardado_cristales = PlayerPrefs.GetFloat("Cristales");
        puntos_cristales = guardado_cristales;

    }

}

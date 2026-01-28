using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cristales_Nv3 : MonoBehaviour
{
    //Nerea
    // script para recoger cristales, contador, y que te permita atravesar la puerta

    public bool puedo_usar_imputs;

    //cristales
    public TMP_Text cristales;
    public int puntos_cristales;
    public GameObject cristal_1;
    public GameObject cristal_2;
    public GameObject cristal_3;
    public GameObject memory_2;
    public float timer_2;
    public bool memory_playing;

    //puerta
    public GameObject puerta;
    public bool abrir;
    public bool apagar;
    // Start is called before the first frame update
    void Start()
    {
        puedo_usar_imputs = true;

        abrir = false;

        memory_2.SetActive(false);
        memory_playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        cristales.text = "Crystals: " + puntos_cristales;

        if (memory_2 == true)
        {
            timer_2 -= Time.deltaTime;
            if (timer_2 <= 0.0f)
            {
                timer_2 = 0.0f;
                memory_2.SetActive (false);

            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        //cuando toque el cristal1, o el 2, o el 3
        if (other.CompareTag("cristal_1") || other.CompareTag("cristal_2") || other.CompareTag("cristal_3"))
        {
            //se añade un punto
            puntos_cristales++;
            //y se desactiva el objeto para que no se pueda a volver a uasr el mismo
            other.gameObject.SetActive(false);
            Debug.Log("He detectado un cristal. Total: " + puntos_cristales);

            if (puntos_cristales >= 3)
            {
                apagar = true;
                if (apagar == true)
                {
                    memory_2.SetActive(true);
                    memory_playing = true;
                }
            }

            apagar = false;

        }

        if ((other.gameObject.CompareTag("puerta2")) && puntos_cristales == 3)
        {
            abrir = true;

            if (abrir == true)
            {
                SceneManager.LoadScene(3);
            }
        }


    }






}

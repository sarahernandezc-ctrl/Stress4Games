using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.Rendering;
using UnityEngine;

public class PatoTransform : MonoBehaviour
{

    // nerea

    //public bool isLana = false;
    //public bool isCar = false;

    [Header("OBJ")]

    public Transform PointOfView;
    //public GameObject CarRenderer;
    public GameObject PatoRender;
    public GameObject PlayerRender;
    public GameObject PatoObject;
    //public GameObject CarObject;
    public PlayerGosht PlayerGosht;
    public timer tiempo_transform;


    [Header("Salto pato doble")]

    public int maxJumps = 2;
    //private int jumpCount = 0;

    public bool isPato = false;
    //public bool isCar = false;


    [Header("Transformations")]
    public bool pato = false;
    // public bool Car = false;
    public float timer = 6.0f;
    private float timerCurrent = 0.0f;


    void Start()
    {
        PatoRender.SetActive(false);
        // CarRenderer.SetActive(false);
        // Car = false;
        pato = false;
       // timerCurrent = 0.0f;
       timerCurrent = tiempo_transform.TimeRemaining;
    }
    void Update()
    {
        if (isPato == true)
        {
            // PatoObject.gameObject.SetActive(true);
            /* PatoRender.SetActive(true);
            Fantasma();
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 3;
                PatoRender.gameObject.SetActive(false);
                PlayerRender.gameObject.SetActive(true);

               
            }
            */

            if (timerCurrent <= 0f)
            {
                timerCurrent = timer;
            }

            timerCurrent -= Time.deltaTime;

            if (timerCurrent <= 0f)
            {
                // Destransformar automáticamente
                PatoRender.SetActive(false);
                PlayerRender.SetActive(true);
                pato = false;
                isPato = false;
                PlayerGosht.maxJumps = 1; // volver a fantasma
            }

        }
        /* else if (isCar == true)
         {

             CarRenderer.SetActive(true);
             timer -= Time.deltaTime;
             if (timer <= 0)
             {
                 timer = 0;
                 Fantasma();
             }
         }*/
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Pato") && Input.GetKeyDown(KeyCode.E) && isPato == false) // cuando el jugador toca este objeto
        {
            //PointOfView.localPosition = Vector3.zero;

            Debug.Log("Colisión detectada con Pato");

            tiempo_transform.StartTimer = true;

            PatoObject.SetActive(false);
            PlayerRender.gameObject.SetActive(false);
            PatoRender.gameObject.SetActive(true);
            isPato = true;
            pato = true;
            //los max de saltos que hace el pato
            PlayerGosht.maxJumps = 2;
            // timerCurrent = timer; // reiniciar temporizador al transformarse
        }
        /*  if (hit.collider.CompareTag("Car")&& Input.GetKeyDown(KeyCode.E) && isCar == false)
          {
              //CarObject.SetActive(false);
              PlayerRender.gameObject.SetActive(false);
             // CarRenderer.gameObject.SetActive(true);
              //isCar = true;
              Car = true;
              PlayerGosht.speed = PlayerGosht.speed * 2;
              PlayerGosht.jumpSpeed = 0;
          }*/
    }
    public void Fantasma()//Bloquear inputs al destransformarse
    {
        //ccuando vuelve a fantasma, que solo sea un salto



        if (pato == true && Input.GetKeyDown(KeyCode.E))
        {
            PatoRender.gameObject.SetActive(false);
            PlayerRender.gameObject.SetActive(true);
            pato = false;
            isPato = false;
            PlayerGosht.maxJumps = 1;
        }


        /* if (Car == true  && Input.GetKeyDown(KeyCode.E))
         {
            // CarRenderer.gameObject.SetActive(false);
             PlayerRender.gameObject.SetActive(true);
             PlayerGosht.speed = PlayerGosht.speed / 2;
             Car = false;
            // isCar = false;
         }*/
    }
}
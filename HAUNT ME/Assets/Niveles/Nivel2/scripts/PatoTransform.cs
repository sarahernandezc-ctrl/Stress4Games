using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.Rendering;
using UnityEngine;

public class PatoTransform : MonoBehaviour
{
    public bool isLana = false;
    //public bool isCar = false;

    public Transform PointOfView;
    //public GameObject CarRenderer;
    public GameObject PatoRender;
    public GameObject PlayerRender;
    public GameObject PatoObject;
    //public GameObject CarObject;
    public PlayerGosht PlayerGosht;

    [Header("Transformations")]
    public bool Lana = false; 
    public bool Car = false;
    public float timer = 3.0f;

    void Start()
    {
        PatoRender.SetActive(false);
      // CarRenderer.SetActive(false);
       // Car = false;
        Lana = false;
    }
    void Update()
    {
        if (isLana == true)
        {
            
            PatoRender.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Fantasma();
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
        if (hit.collider.CompareTag("Pato") && Input.GetKeyDown(KeyCode.E) && isLana == false) // cuando el jugador toca este objeto
        {            
            //PointOfView.localPosition = Vector3.zero;
            
            Debug.Log("Colisión detectada con Pato");

            PatoObject.SetActive(false);
            PlayerRender.gameObject.SetActive(false);
            PatoRender.gameObject.SetActive(true);
            isLana = true;
            Lana = true;
            PlayerGosht.jumpSpeed = 10;
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
        if (Lana == true && Input.GetKeyDown(KeyCode.E))
        {
            PatoRender.gameObject.SetActive(false);
            PlayerRender.gameObject.SetActive(true);
            Lana = false;
            isLana = false;
        }
        if (Car == true  && Input.GetKeyDown(KeyCode.E))
        {
           // CarRenderer.gameObject.SetActive(false);
            PlayerRender.gameObject.SetActive(true);
            PlayerGosht.speed = PlayerGosht.speed / 2;
            Car = false;
           // isCar = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.Rendering;
using UnityEngine;

public class LanaTransform : MonoBehaviour
{
    //Sara
    public bool isLana = false;
    public bool isCar = false;

    public Transform PointOfView;
    public GameObject CarRenderer;
    public GameObject LanaRenderer;
    public GameObject PlayerRender;
    public GameObject LanaObject;
    public GameObject CarObject;
    public GameObject DeathPanel;
    public PlayerManager playerManager;

    [Header("Transformations")]
    public bool Lana = false; 
    public bool Car = false;
    public float timer = 3.0f;

    [Header("Ui")]
    public GameObject Text;

    void Start()
    {
        LanaRenderer.SetActive(false);
        CarRenderer.SetActive(false);
        Car = false;
        Lana = false;
        DeathPanel.SetActive(false);
        Text.SetActive(false);
    }
    void Update()
    {
        if (isLana == true)
        {
            
            LanaRenderer.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Fantasma();
            }
        }
        else if (isCar == true)
        {
            
            CarRenderer.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Fantasma();
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("fff");
        if (other.CompareTag("Lana") || other.CompareTag("Car"))
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("dddd");
        if (other.CompareTag("Lana") || other.CompareTag("Car"))
        {
            Text.SetActive(false);
        }
    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.CompareTag("Lana") && Input.GetKeyDown(KeyCode.E) && isLana == false) // cuando el jugador toca este objeto
        {                     
            Debug.Log("Colisión detectada con Lana");

            LanaObject.SetActive(false);
            PlayerRender.gameObject.SetActive(false);
            LanaRenderer.gameObject.SetActive(true);
            isLana = true;
            Lana = true;
            Text.SetActive(false);
        }
        if (hit.collider.CompareTag("Car") && Input.GetKeyDown(KeyCode.E) && isCar == false)
        {
            CarObject.SetActive(false);
            PlayerRender.gameObject.SetActive(false);
            CarRenderer.gameObject.SetActive(true);
            isCar = true;
            Car = true;
            playerManager.speed = playerManager.speed * 2;
            playerManager.jumpSpeed = 0;
            Text.SetActive(false);
        }
        if (hit.collider.CompareTag("Enemy"))
        {
            DeathPanel.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }
    public void Fantasma()//Vuelve a ser fantasma
    {
        if (Lana == true && Input.GetKeyDown(KeyCode.E))
        {
            LanaRenderer.gameObject.SetActive(false);
            PlayerRender.gameObject.SetActive(true);
            Lana = false;
            isLana = false;
        }
        if (Car == true  && Input.GetKeyDown(KeyCode.E))
        {
            CarRenderer.gameObject.SetActive(false);
            PlayerRender.gameObject.SetActive(true);
            playerManager.speed = playerManager.speed / 2;
            playerManager.jumpSpeed = 5;
            Car = false;
            isCar = false;
        }
    }
}
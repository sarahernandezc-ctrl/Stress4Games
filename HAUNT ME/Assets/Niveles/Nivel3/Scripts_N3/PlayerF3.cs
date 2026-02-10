using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerF3 : MonoBehaviour
{
    // Sara

    private CharacterController characterController;
    private float ySpeed;
    private float OriginalStepOffSet;
    public Animator animPlayer;
    private bool IsMoving;
    public LanaTransform LanaTransform;

    public bool Muerte_Pelusa = false;

    [Header("Player Settings")]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public bool CanUseInputs;
    public bool IsAlive;

    [Header("CameraFollow")]
    public Transform CameraTransform;

    [Header("UI")]
    public GameObject menupausa;
    public GameObject menupausa2;

    public GameObject Choque;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animPlayer = GetComponent<Animator>();
        OriginalStepOffSet = characterController.stepOffset;
        CanUseInputs = true;
        Choque.SetActive(false);
        menupausa.SetActive(false);
        menupausa2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (CanUseInputs == true) //&& IsAlive == true)
        {

            Movement();
            Animation();
            menupause();

        }

        if (Muerte_Pelusa == true)
        {

            CanUseInputs = false;

            Time.timeScale = 0.0f;
        }
    }

    public void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");//Detect horizontal inputs like a d <- ->
        float verticalInput = Input.GetAxis("Vertical");//Detect vertical inputs like w s up and down arrows

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed; //The magnitude is never going to be infinity. It's limits are 1 or 0

        movementDirection = Quaternion.AngleAxis(CameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize(); //Allways the same velocity

        ySpeed += Physics.gravity.y * Time.deltaTime; //gravity in y

        if (characterController.isGrounded) //is on ground?
        {
            characterController.stepOffset = OriginalStepOffSet;
            ySpeed = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ySpeed = jumpSpeed;
            }
        }
        else //not climbing walls
        {
            characterController.stepOffset = 0.0f;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        characterController.Move(velocity * Time.deltaTime); //Move player in direction

        if (movementDirection != Vector3.zero) //chaeck if we are moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //create the rotate in direction of movement
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);//rotate
            transform.rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            //transform.forward = CameraTransform.forward;
        }

    }
    public void Animation()
    {
        if (IsMoving == false)
        {
            animPlayer.SetBool("IsMoving", false);

        }
        else
        {
            animPlayer.SetBool("IsMoving", true);
        }


    }


    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("He detectado una colisión con: " + hit.collider.name);

        if (hit.collider.CompareTag("muerte_Pelusa"))
        {

            Muerte_Pelusa = true;

            Debug.Log("He detectado una colisión con Muerte");



        }
        if (hit.collider.CompareTag("Cajas") && Input.GetKeyDown(KeyCode.F))
        {

            Choque.SetActive(true);

            Debug.Log("He detectado una colisión con la Caja");



        }



    }


    public void menupause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menupausa.activeInHierarchy)
            {
                menupausa.SetActive(true);
                menupausa2.SetActive(false);
                Time.timeScale = 0.0f;
            }
            else 
            { 
                menupausa.SetActive(false);
                menupausa2.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }

    }


   
    public void menupause2()
    {
        if (!menupausa2.activeInHierarchy)
        {
            menupausa.SetActive(false);
            menupausa2.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            menupausa.SetActive(true);
            menupausa2.SetActive(false);
            Time.timeScale = 0.0f;
        }
    }
 
    public void resume()
    {
        menupausa.SetActive(false);
        Time.timeScale = 1.0f;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGosht : MonoBehaviour
{
    // nerea

    private CharacterController characterController;
    private float ySpeed;
    private float OriginalStepOffSet;
    public Animator animPlayer;
    private bool IsMoving;
    public PatoTransform PatoTransform;

    //para el salto del fantasma
    [Header("Salto fantasma")]

    public int maxJumps = 1;
    private int jumpCount = 0;


    [Header("Player Settings")]
    public float speed;
    public float jumpSpeed;
    public float rotationSpeed;
    public bool CanUseInputs;
    public bool IsAlive;

    [Header("CameraFollow")]
    public Transform CameraTransform;


    [Header("UI")]
    public GameObject pausemenu;
    public GameObject pausemenu2;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animPlayer = GetComponent<Animator>();
        OriginalStepOffSet = characterController.stepOffset;
        CanUseInputs = true;
        pausemenu.SetActive(false);
        pausemenu2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (CanUseInputs == true) //&& IsAlive == true)
        {
            Animation();
            Movement();
            menupausa();
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
            jumpCount = 0; // resetea los saltos

        }
        else //not climbing walls
        {
            characterController.stepOffset = 0.0f;
        }

        // Salto y DOBLE salto
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            ySpeed = jumpSpeed;
            jumpCount++;  // suma salto


        }

        if (!characterController.isGrounded)
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

        /* if (PatoTransform.isCar == false)
         {
             animPlayer.SetBool("IsCar", false);
         }
         else
         {
             animPlayer.SetBool("IsCar", true);
         }*/
    }




    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("He detectado una colision con:" + hit.collider.name);
        if (hit.collider.CompareTag("agua"))
        {
            Debug.Log("He detectado una colision con:muerte");


            CanUseInputs = false;
            //hace que cuando choque no le permita moverse y se pare

            Time.timeScale = 0.0f;
        }


    }

    public void menupausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausemenu.activeInHierarchy)
            {
                pausemenu.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else
            {
                pausemenu.SetActive(false);
                pausemenu2.SetActive(false);
                Time.timeScale = 1.0f;
            }


        }
    }

    public void menupausa2()
    {
        if (!pausemenu2.activeInHierarchy)
        {
            pausemenu.SetActive(false);
            pausemenu2.SetActive(true);
            //Time.timeScale = 0.0f;
        }
        else
        {
            pausemenu.SetActive(true);
            pausemenu2.SetActive(false);
            // Time.timeScale = 0.0f;
        }
    }



    public void resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
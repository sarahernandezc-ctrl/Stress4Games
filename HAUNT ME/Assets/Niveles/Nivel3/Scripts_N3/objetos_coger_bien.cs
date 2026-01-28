using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos_coger_bien : MonoBehaviour
{
    // public PatoTransform Pato_transform;
    [Header("BRAZOS")]

    public Transform handPoint;


    private Rigidbody pickedRigbody;

    [Header("INTERACCIONES")]

    private GameObject pickedObject = null;
    private GameObject pickedpato = null;

    //para saber cuando toca al objeto, para salir el panel
    public bool dentroDeObjeto = false;
    public bool dentroDePato = false;

    [Header("TEXTO")]
    public GameObject textdetect;
    public GameObject textSoltar;
    public GameObject textPato;

    //public bool detecta;
    // GameObject ultimoReconocido = null;





    // Start is called before the first frame update
    void Start()
    {
        //no sale el texto
        textdetect.SetActive(false);
        // detecta = false;

        textSoltar.SetActive(false);

        textPato.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // quitar objeto con j
        /* if (pickedObject != null)
         {
             if (Input.GetKey("j"))
             {
                 pickedObject.GetComponent<Rigidbody>().useGravity = true;
                 pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                 pickedObject.gameObject.transform.SetParent(null);

                 pickedObject = null;
             }
         }*/
        if (!dentroDeObjeto && pickedObject == null)
        {
            textdetect.SetActive(false);
        }

        if (pickedObject != null && Input.GetKeyDown(KeyCode.R))
        {
            pickedRigbody.useGravity = true;
            pickedRigbody.drag = 0f;
            pickedRigbody.angularDrag = 0.05f;

            pickedObject = null;
            pickedRigbody = null;

            textSoltar.SetActive(false);
        }




    }

    void FixedUpdate()
    {
        // Mover la caja con física real
        if (pickedObject != null && pickedRigbody != null)
        {
            pickedRigbody.MovePosition(handPoint.position);
            pickedRigbody.MoveRotation(handPoint.rotation);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cajas") && pickedObject == null)
        {
            // cuando las manos toquen el objeto, que salga el panel, es como decir que tocar el objeto es cierto
            dentroDeObjeto = true;
            //por lo tanto el texto se activa
            textdetect.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                pickedObject = other.gameObject;
                pickedRigbody = pickedObject.GetComponent<Rigidbody>();

                pickedRigbody.useGravity = false;
                pickedRigbody.drag = 50f;
                pickedRigbody.angularDrag = 10f;

                //es false, para que se quite el panel mientras lo sostienes el objeto
                textdetect.SetActive(false);
                textSoltar.SetActive(true);
            }
        }

        // textPato.SetActive(false);

        if (other.CompareTag("Pato") && pickedpato == null)
        {
            dentroDePato = true;

            textPato.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                pickedpato = other.gameObject;
                //es false, para que se quite el panel mientras lo sostienes el objeto
                textPato.SetActive(false);
            }
        }


        /* if (other.CompareTag("Pato") && !textPato.activeSelf)
         {
             dentroDePato = false;    
             textPato.SetActive(true); // Mostrar texto cuando se acerque


         }*/

        // textPato.SetActive(false);


        /*if (!dentroDePato && pickedpato == null)
        {
            textPato.SetActive(false);
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cajas"))
        {
            dentroDeObjeto = false;
        }

        if (other.CompareTag("Pato"))
        {
            textPato.SetActive(false);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prueba_3_Obj : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject handPoint2;

    private GameObject pickedObject2 = null;


    public GameObject Choque;


    // Start is called before the first frame update
    void Start()
    {
        Choque.SetActive(false);
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

        if (pickedObject2 != null)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                pickedObject2.GetComponent<Rigidbody>().useGravity = true;
                pickedObject2.GetComponent<Rigidbody>().isKinematic = false;
                pickedObject2.transform.SetParent(null);
                pickedObject2 = null;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        //coger objeto con k

        if (other.gameObject.CompareTag("Cajas"))
        {
            if (Input.GetKeyDown(KeyCode.K) && pickedObject2 == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;

                other.transform.position = handPoint2.transform.position;
                other.transform.SetParent(handPoint2.transform);

                pickedObject2 = other.gameObject;
            }
        }

        

    }

    
}

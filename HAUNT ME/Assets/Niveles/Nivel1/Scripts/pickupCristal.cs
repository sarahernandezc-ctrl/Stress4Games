using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pickupCristal : MonoBehaviour
{
    //Nerea
    // script para recoger cristales, contador, y que te permita atravesar la puerta

    public bool Can_UseInputs2;

    //cristales
    public GameObject cristal;
    public int Cristal_Points;
    //puerta
    public GameObject puerta;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        Can_UseInputs2 = true;
        open = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        }

        if ((other.gameObject.CompareTag("puerta")) && Cristal_Points >= 1)
        {
            open = true;

            if (open == true)
            {
                SceneManager.LoadScene(4);
            }
        }
    }

}

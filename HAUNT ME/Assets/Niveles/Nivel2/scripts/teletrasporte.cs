using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teletrasporte : MonoBehaviour
{
    //Nerea

    [Header("Destino del teletransporte")]
    public Transform teleportDestination; // Objeto al que quieres teletransportar al jugador

    [Header("Tag del jugador")]
    public string playerTag = "Player"; // Tag del jugador

    private void OnTriggerEnter(Collider other)
    {
        // Solo teletransporta al jugador con la tag correcta
        if (other.CompareTag(playerTag))
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            if (cc != null)
            {
                //Calcular desplazamiento necesario para llegar al destino
                Vector3 displacement = teleportDestination.position - other.transform.position;

                // Usar Move para teletransportar al CharacterController
                cc.Move(displacement);

               // cc.transform.position = teleportDestination.position;
              // teleportDestination.position = cc.transform.position;
                // Opcional: ajustar rotación directamente
                other.transform.rotation = teleportDestination.rotation;
                Debug.Log(teleportDestination.transform);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveData : MonoBehaviour
{
    //sara
    [Header("Save")]
    public CharacterController Player;
    public float posX;
    public float posY;
    public float posZ;
    public Vector3 Possition;

    // Start is called before the first frame update
    void Start()
    {
        //Load_Data();
        Player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Save_Data()
    {
        PlayerPrefs.SetFloat("Possicion X", transform.position.x);
        PlayerPrefs.SetFloat("Possicion Y", transform.position.y);
        PlayerPrefs.SetFloat("Possicion Z", transform.position.z);
        Debug.Log("GUARDADO!");
    }
    public void Load_Data()
    {
        
        posX = PlayerPrefs.GetFloat("Possicion X");
        posY = PlayerPrefs.GetFloat("Possicion Y");
        posZ = PlayerPrefs.GetFloat("Possicion Z");

        Possition.x = posX;
        Possition.y = posY;
        Possition.z = posZ;
        Player.enabled = false;
        Player.transform.position = Possition;
        Player.enabled = true;
        Debug.Log("CARGADO!");
    }
}

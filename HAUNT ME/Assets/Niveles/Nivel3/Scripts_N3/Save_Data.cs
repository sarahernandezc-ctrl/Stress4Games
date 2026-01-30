using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Data : MonoBehaviour
{
    // Start is called before the first frame update

    //Sara

    [Header("Save")]
    public CharacterController Player;
    public float posX;
    public float posY;
    public float posZ;
    public Vector3 Possition;


    void Start()
    {
        //Load_Data();
        Player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sava_Data()
    {
        PlayerPrefs.SetFloat("Possition X", transform.position.x);
        PlayerPrefs.SetFloat("Possition Y", transform.position.y);
        PlayerPrefs.SetFloat("Possition Z", transform.position.z);
        Debug.Log("SAVE!");

    }

    public void Load_Data()
    {
        posX = PlayerPrefs.GetFloat("Possition X");
        posY = PlayerPrefs.GetFloat("Possition Y");
        posZ = PlayerPrefs.GetFloat("Possition Z");

        Possition.x = posX;
        Possition.y = posY;
        Possition.z = posZ;
        Player.enabled = false;
        Player.transform.position = Possition;
        Player.enabled = true;
        Debug.Log("LOAD!");
    }

}

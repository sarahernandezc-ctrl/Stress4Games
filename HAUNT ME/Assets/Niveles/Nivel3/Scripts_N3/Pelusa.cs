using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_volador : MonoBehaviour
{
    //Eva

    Rigidbody Pelusa;

    public float speed = 5f;

    public float max_distance;

    public float initial_point;

    public int direction = 1;

    public CharacterController PlayerF3;

    // Start is called before the first frame update
    void Start()
    {

        initial_point = transform.position.y;

    }

    void Enemy_Movement()
    {
        float NewPosition = transform.position.y + speed * Time.deltaTime * direction;

        if (max_distance < NewPosition)
        {
            direction = -1;

        }

        if (NewPosition <= initial_point)
        {
            direction = 1;
        }

        transform.Translate(Vector3.up * speed * Time.deltaTime * direction);

    }

    // Update is called once per frame
    void Update()
    {
        Enemy_Movement();
    }
}
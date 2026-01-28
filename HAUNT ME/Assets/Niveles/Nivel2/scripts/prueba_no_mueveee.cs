using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_no_mueveee : MonoBehaviour
{
    public Rigidbody quieto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        quieto.constraints = RigidbodyConstraints.FreezeAll;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        

        //Verifica si el objeto coliciona con el objeto del tactil

        if (collision.gameObject.name == "brush(Clone)"||collision.gameObject.name == "soap")
        {
           
            Destroy(gameObject);
        }
    }

}

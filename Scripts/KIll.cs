using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KIll : MonoBehaviour
{
   
   void Update()
    {
        if( transform.position.y<-100){
            Destroy(gameObject, 0f);
        }
    }

}

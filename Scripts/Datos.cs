using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datos : MonoBehaviour
{
    // Start is called before the first frame update
    int Level ;
    public static int Nivel;
    void Start()
    {
       Level = PlayerPrefs.GetInt("Nivel", 1);
       Debug.Log("EE");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

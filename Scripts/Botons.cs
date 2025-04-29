using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botons : MonoBehaviour
{
    [SerializeField] private GameObject MOSTRAR , MOSTRAR1;// Start is called before the first frame update
    void Start()
    {
       // Desactiva el objeto que contiene este script
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Mostrar(){
        MOSTRAR.SetActive(true);
        MOSTRAR1.SetActive(false);
         gameObject.SetActive(false);  
    }
}

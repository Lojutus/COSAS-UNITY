using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soap : MonoBehaviour
{
    public GameObject Water;
    public GameObject water;

    public GameObject soap;

    public GameObject WAter;
     
    // Start is called before the first frame update
    void Start()
    {
        //Water water = waterComp.GetComponent<Water>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Agua(){
        //Water.SetActive(false);
        //water.SetActive(false);
         Water water = WAter.GetComponent<Water>();
         if (water.finalizado)
         {
            soap.SetActive(true);
            WAter.SetActive(false);
         }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicio : MonoBehaviour
{
     public GameObject water;
     public GameObject waterF;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Active(){
        water.SetActive(true);
        waterF.SetActive(true);
        gameObject.SetActive(false);
    }
}

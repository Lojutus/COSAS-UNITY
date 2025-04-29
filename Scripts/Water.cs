using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update
    public bool finalizado=false;
    public GameObject Soap;
    public GameObject Ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Contar(){
        StartCoroutine(Contar5Segundos());
    }
    private IEnumerator Contar5Segundos()
    {
        // Esperar 5 segundos
        yield return new WaitForSeconds(5);

        // Acción después de 5 segundos
        Debug.Log("Han pasado 5 segundos.");
        finalizado=true;
        Soap.SetActive(true);
        Ui.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dry : MonoBehaviour
{
 
     public GameObject UiNext;
      public GameObject Ui;
      public GameObject all;
      public GameObject alltwo;
     void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.gameObject.name == "bubble_3(Clone)")
        {
           
            Destroy(collision.gameObject);
            
            
        }
    }
    void Update()
    {
        int cantidad = ContarObjetos("bubble_3(Clone)");
        if(cantidad== 0 ){
            gameObject.SetActive(false);
            Ui.SetActive(false);
            
        }
    }
    int ContarObjetos(string nombre)
    {
        // Encontrar todos los objetos en la escena
        GameObject[] todosLosObjetos = FindObjectsOfType<GameObject>();
        int contador = 0;

        foreach (GameObject obj in todosLosObjetos)
        {
            // Si el nombre del objeto coincide con el nombre especificado, incrementar el contador
            if (obj.name == nombre)
            {
                contador++;
            }
        }

        return contador;
    }
    public void ActivarMaquillage(){
        UiNext.SetActive(true);
        all.SetActive(false);
        alltwo.SetActive(false);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapComp : MonoBehaviour
{
    private bool Colicion;
    private bool ready;
   public GameObject Burbujitas;

   public GameObject Toalla;

   public GameObject Toallita;
   public GameObject Ui;
   
   private int MAX;
    // Start is called before the first frame update
    void Start()
    {
         Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (MAX>7)
        {
            gameObject.SetActive(false);
            Toalla.SetActive(true);
            Toallita.SetActive(true);
            Ui.SetActive(false);
        }
    }
     void OnTriggerStay2D(Collider2D collision)
    {
        

        if (collision.gameObject.name == "dibujo 1"&& ready)
        {
            // lógica aquí cuando colisiona con el Tactil
            StartCoroutine(Burbujas());
            Colicion=true;

        
            
        }
    }
    private IEnumerator Burbujas()
    {
        ready = false;
        // Esperar 1 segundos
        yield return new WaitForSeconds(1);


        // Acción después de 1 segundo
            Spawn();
            

       
    }
    void Spawn(){
        if (Colicion|| MAX<100)
        {
                  Instantiate(Burbujitas, transform.position, transform.rotation);
            MAX++;
            ready = true;
        }
    }
    }


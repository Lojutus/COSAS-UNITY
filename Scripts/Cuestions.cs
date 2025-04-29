using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuestions : MonoBehaviour
{
    [SerializeField] private GameObject Cuestion;
    [SerializeField] private GameObject All;
    [SerializeField] private bool cuestionBool = false; // cambiar a false para que se muestre la cuestión inicialmente

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Respawn;

    [SerializeField] private int nivelActual;

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
         if(collision.gameObject.name  == "Player" || cuestionBool==false) 
         {
            cuestionOn();
        }
    }
    void cuestionOn(){
        Cuestion.SetActive(true);
        All.SetActive(false);
    }
    void cuestionOff(){
        cuestionBool = true;
         

        Cuestion.SetActive(false);
        
        All.SetActive(true);
        
    }
   void correctAnswer(){
        // para que aparezca la respuesta correcta
        Debug.Log("Correcto");
        cuestionOff();

    }
    public void wrongAnswer(){
            // para que aparezca la respuesta incorrecta
            Debug.Log("Incorrecto");
            Behaviors behaviors = Player.GetComponent<Behaviors>();
            behaviors.Damage();
            cuestionOff();
            
    }
    public void pass(){
        Respawn.transform.position = gameObject.transform.position ;
        gameObject.SetActive(false);
        
        cuestionOff();
        correctAnswer();
        Save();
        
    }
    public void Save(){
        PlayerPrefs.SetInt("Nivel", nivelActual);

    }
    
}



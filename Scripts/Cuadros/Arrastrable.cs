using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Arrastrable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool Arrastrando, Gravedad=true;
    private  GameObject Tactil;
    private PosicionToque posicionToque;
    private Collider2D micollider;
    private Rigidbody2D rb2D;
    


    void Start()
    {
        //Busca el objeto Tactil
        Tactil = GameObject.Find("Posicion_toque");
        
        CambiarValorArrastrando(Arrastrando);
       rb2D = GetComponent<Rigidbody2D>();
        micollider = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
      
       
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        //Obtener si ya se esta arrastrando algo 

        bool ValorAntes = ObtenerValor();

        //Verifica si el objeto coliciona con el objeto del tactil

        if (collision.gameObject.name == "Posicion_toque" && ValorAntes==false && Touchscreen.current.primaryTouch.press.isPressed)
        {
            // lógica aquí cuando colisiona con el Tactil
            StartCoroutine(isPress());
                     // Modificar la gravedad del objeto
            rb2D.gravityScale = 0f; // Ajusta este valor según sea necesario

            
        }
    }

    public IEnumerator isPress(){
        do
        {
            //Establece que algo se esta arrastrando
            Arrastrando = true;
            CambiarValorArrastrando(Arrastrando);
            transform.position= Tactil.transform.position;
            micollider.enabled = false;
            yield return null;
 
            
        } while(Touchscreen.current.primaryTouch.press.isPressed);
        // Se establece que nada se esta arrastrando 
        Arrastrando = false;
        CambiarValorArrastrando(Arrastrando);
        micollider.enabled = true;
        if(Gravedad){
        // Modificar la gravedad del objeto
       rb2D.gravityScale = 0.5f; // Ajusta este valor según sea necesario
        }
    }
        //Cancela  la corutina si se solta el objeto 

        void CambiarValorArrastrando(bool Valor){
        // Obtener una referencia al script PosicionToque dentro del GameObject "Tactil"
        if(Tactil != null){
        PosicionToque posicionToque = Tactil.GetComponent<PosicionToque>();
        
        // Acceder y modificar el booleano arrastrando del script PosicionToque
        posicionToque.arrastrando = Valor;}
        
    }
     bool ObtenerValor(){
        // Obtener una referencia al script PosicionToque dentro del GameObject "Tactil"
        PosicionToque posicionToque = Tactil.GetComponent<PosicionToque>();

        // Acceder y modificar el booleano arrastrando del script PosicionToque
        bool ValorAntes = posicionToque.arrastrando;
        
        return ValorAntes;
    }

}


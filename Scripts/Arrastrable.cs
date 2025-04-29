using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Arrastrable : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool Arrastrando;
    private  GameObject Tactil;
    private PosicionToque posicionToque;
    private Collider2D collider;
    private Rigidbody2D rb2D;
    public Color color;
    [SerializeField] private Image ColorPicker;

    void Start()
    {
        //Busca el objeto Tactil
        Tactil = GameObject.Find("Posicion_toque");
        
        CambiarValorArrastrando(Arrastrando);
       rb2D = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
         // Modificar la gravedad del objeto
        rb2D.gravityScale = 0f; // Ajusta este valor según sea necesario
        color= Color.red;
       
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
            if (gameObject.name == "water")
            {
                 //Extras
            Water water = gameObject.GetComponent<Water>();
            water.Contar();
            
            }
           
        }
    }

    public IEnumerator isPress(){
        do
        {
            //Establece que algo se esta arrastrando
            Arrastrando = true;
            CambiarValorArrastrando(Arrastrando);
            transform.position= Tactil.transform.position;
            //collider.enabled = false;
            yield return null;
 
            
        } while(Touchscreen.current.primaryTouch.press.isPressed);
        // Se establece que nada se esta arrastrando 
        Arrastrando = false;
        CambiarValorArrastrando(Arrastrando);
        collider.enabled = true;
        // Modificar la gravedad del objeto
       rb2D.gravityScale = 0.0f; // Ajusta este valor según sea necesario
       Debug.Log("exe");
    }
        //Cancela  la corutina si se solta el objeto 

        void CambiarValorArrastrando(bool Valor){
        // Obtener una referencia al script PosicionToque dentro del GameObject "Tactil"
        PosicionToque posicionToque = Tactil.GetComponent<PosicionToque>();

        // Acceder y modificar el booleano arrastrando del script PosicionToque
        posicionToque.arrastrando = Valor;
        
    }
     bool ObtenerValor(){
        // Obtener una referencia al script PosicionToque dentro del GameObject "Tactil"
        PosicionToque posicionToque = Tactil.GetComponent<PosicionToque>();

        // Acceder y modificar el booleano arrastrando del script PosicionToque
        bool ValorAntes = posicionToque.arrastrando;
        
        return ValorAntes;
    }

}


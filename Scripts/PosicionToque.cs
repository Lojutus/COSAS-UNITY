using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PosicionToque : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera CamaraPrincipal;
    public Vector3 PosicionGlobalToque ; 

    public bool arrastrando=false;

    void Start()
    {
        CamaraPrincipal = Camera.main; 
    }

    // Update is called once per frame
    void Update(){
        posicionToque();
        transform.position= PosicionGlobalToque;
    }
    void posicionToque(){
        if(Touchscreen.current.primaryTouch.press.isPressed){
            Vector2 posicion_toque = Touchscreen.current.primaryTouch.position.ReadValue();
            PosicionGlobalToque = CamaraPrincipal.ScreenToWorldPoint(posicion_toque);
            PosicionGlobalToque.z = 0f;

        }

    }
}

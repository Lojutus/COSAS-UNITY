
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;  // Para detectar si el toque está sobre un botón

public class PosicionToque : MonoBehaviour
{
    private Camera CamaraPrincipal;
    public Vector3 PosicionGlobalToque;
    public bool arrastrando; // No se modifica esta variable

    void Start()
    {
        CamaraPrincipal = Camera.main;
    }

    void Update()
    {
        posicionToque();
        transform.position = PosicionGlobalToque;
    }

    void posicionToque()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 posicion_toque = Touchscreen.current.primaryTouch.position.ReadValue();

            // ✅ **Ignorar si el toque está sobre un botón u otro objeto UI**
            if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(Touchscreen.current.primaryTouch.touchId.ReadValue()))
            {
                Debug.Log("❌ Toque sobre UI detectado, ignorando...");
                return;
            }

            PosicionGlobalToque = CamaraPrincipal.ScreenToWorldPoint(posicion_toque);
            PosicionGlobalToque.z = 0f;
        }
    }
}

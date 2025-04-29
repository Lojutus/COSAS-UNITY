using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private Ui ui;
    void Start()
    {
        GameObject UI = GameObject.Find("Canvas");
        ui = UI.GetComponent<Ui>();
                
                transform.rotation = Quaternion.Euler(0, 0, -85);

    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si el objeto con el que colisionamos tiene el componente "DatosCuadro"
        DatosCuadro datos = other.GetComponent<DatosCuadro>();

        // Si tiene el componente y su "Valor_Operacion" es igual a 1, destruye ambos objetos
        if (datos != null && datos.Valor_Operacion == 1)
        {
            // Destruir el objeto con el que colisionamos
            Destroy(other.gameObject);
            ui.shieldEscena-= 1;
            // Destruir este objeto (el que tiene el script)
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOperations : MonoBehaviour
{
// Lista para almacenar los objetos dentro del trigger
    private List<GameObject> objetosDentro;

    void Start()
    {
        // Inicializar la lista
        objetosDentro = new List<GameObject>();
                               Debug.Log(objetosDentro);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el objeto dentro del trigger es de interés
        if (other.CompareTag("cubo"))
        {
            // Agregar el objeto a la lista si no está presente
            if (!objetosDentro.Contains(other.gameObject))
            {
                objetosDentro.Add(other.gameObject);


            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Remover el objeto de la lista al salir del trigger
        if (other.CompareTag("cubo"))
        {
            objetosDentro.Remove(other.gameObject);
        }
    }

    // Método para obtener la lista de objetos dentro del trigger
    public List<GameObject> ObtenerObjetosDentro()
    {
        return objetosDentro;
    }
    void Update()
    {
    }
}

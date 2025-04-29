using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab; // El prefab a instanciar.
    public int poolSize = 10; // Tamaño inicial del pool.

    private List<GameObject> pool = new List<GameObject>();

    private void Start()
    {
        // Llena el pool con objetos inactivos.
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false); // Desactívalo inicialmente.
            pool.Add(obj); // Añádelo al pool.
        }
    }

    // Método para obtener un objeto del pool.
    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true); // Actívalo y devuélvelo.
                return obj;
            }
        }

        // Si no hay objetos disponibles, crea uno nuevo, agrégalo al pool y devuélvelo.
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        pool.Add(newObj);
        return newObj;
    }

    // Método para regresar un objeto al pool.
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false); // Simplemente desactívalo.
    }
}

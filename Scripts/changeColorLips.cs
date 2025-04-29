using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorLips : MonoBehaviour
{
     private SpriteRenderer spriteRenderer;//Declaro El espacio del componenete
     public Color color;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Lo establesco 
         if (spriteRenderer == null)
        {
            Debug.LogError("No se encontro un componente SpriteRenderer en el GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeColor(Color.blue);
    }
    public void ChangeColor(Color newColor)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = newColor;
        }
    }
     void OnTriggerStay2D(Collider2D collision)
    {
        

        //Verifica si el objeto coliciona con el objeto del tactil

        if (collision.gameObject.name == "bottle_lipstick(Clone)"||collision.gameObject.name == "bottle_lipstick")
        {
           
            Arrastrable arrastrable = collision.gameObject.GetComponent<Arrastrable>();

        // Acceder y modificar la variable arrastrando del script arrastrable
        color = arrastrable.color;
        ChangeColor(color);
        }
    }
}

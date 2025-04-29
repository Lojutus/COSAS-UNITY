using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float scalePower = 1;
    [SerializeField] private int Position = 70 ;
    [SerializeField] private bool position_Active = true;


    // Update is called once per frame
void Start()

    {
      // Calculamos el tamaño que necesita tener el objeto s
        float screenWidth =  (Screen.width);
        float PosX = Position;
        // Calculamos la posicion que necesita tener el objeto 
        if (Position!=0 && Position!=1 )
        {
             PosX = (Position*10)/Screen.width;     
        }
        else if( Position == 1 ){
            PosX = Screen.width/Screen.width;   
        }
         else if( Position == 0 ){
            PosX = 0;   
        }
        
 
        // Establece el tamaño y la posicion que necesita tener el objeto 
        transform.localScale = new Vector2((scalePower*700)/screenWidth, 1f);
        if(position_Active){
            transform.position = new Vector2(PosX, transform.position.y);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
     public float groundCheckRadius = 0.4f; // El radio del círculo para verificar el suelo
     public float speed = 2f; // La velocidad del enemigo

    //LEFT
      public Transform groundCheckLeft; // Un punto en el pie del personaje para verificar el suelo
    //Right
      public Transform groundCheckRight; // Un punto en el pie del personaje para verificar el suelo
    public bool direccion= false;

    private bool see;
    private bool Collicion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        
        //Acceso al componente Rigidbody2D
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        
        // Verifica si está tocando el suelo
        if(Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, LayerMask.GetMask("Ground"))&&!Collicion)
        {
            // Si está tocando el suelo Rigt 
            if(!see){
                //mueve hacia la derecha  
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else{
                 // mueve hacia la izquierda
                rb.velocity = new Vector2(-1* speed, rb.velocity.y);
            }
        }
        else{
            Girar();
        }
      
      
        
       

       /* if(direccion){
            // Si está tocando el suelo, mueve al enemigo hacia la izquierda
            rb.velocity = new Vector2(-1* speed, rb.velocity.y);
            Girar();
        }
        else{
            // Si No está tocando el suelo left , mueve al enemigo hacia la derecha si Derecha Esta tocado el suelo 
            rb.velocity = new Vector2(speed, rb.velocity.y);
            Girar();
        }
        
         if(Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, LayerMask.GetMask("Ground"))&& !see){
            
           // Si Right toca el suelo  , mueve al enemigo hacia la derecha si Derecha Esta tocado el suelo 
            rb.velocity = new Vector2(speed, rb.velocity.y);
            
        }
       else if(Physics2D.OverlapCircle(groundCheckLeft.position, groundCheckRadius, LayerMask.GetMask("Ground")) && see && Physics2D.OverlapCircle(groundCheckRight.position, groundCheckRadius, LayerMask.GetMask("Ground"))==false){
            
              // Si está tocando el suelo left, mueve al enemigo hacia la izquierda
            rb.velocity = new Vector2(-1* speed, rb.velocity.y);
            
        }
        else{
            Girar();
        }
       
        */
    
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckLeft.position, groundCheckRadius);
        Gizmos.DrawWireSphere(groundCheckRight.position, groundCheckRadius);
    }
     void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Behaviors behaviors = collision.gameObject.GetComponent<Behaviors>();
            behaviors.Damage();
        }
        if (collision.gameObject.tag == "self")
        {
            Collicion = true;
        }
        else{ Collicion = false;}
        
    }
    void OnTriggerStay2D(Collider2D collision)
    {
         if(collision.gameObject.name  == "PlayerKiller")
         {
            
            Destroy(gameObject);
            
        }
        
    }
    private void Girar(){
        see = !see;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale= escala;
    }
    }




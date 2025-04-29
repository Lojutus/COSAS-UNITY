using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCharacter : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;

    //SALTO
    [SerializeField] private float JumpStrength= 10;
      public Transform groundCheck; // Un punto en el pie del personaje para verificar el suelo
    public float groundCheckRadius = 0.2f; // El radio del círculo para verificar el suelo
    private Animator animator;

    private bool isGrounded, MoveL, MoveR;

    private bool see;
    private MOVE entradasMovimiento;    // Start is called before the first frame update
     /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void Awake()
    {
        entradasMovimiento = new MOVE();
    }
    void OnEnable()
    {
        entradasMovimiento.Enable();
    }
    void OnDisable(){
        entradasMovimiento.Disable();
    }
    void Start()
    {
        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius,  LayerMask.GetMask("Ground"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(JumpStrength);
        }
        
    }
    private void Move()
    {
        rb = this.GetComponent<Rigidbody2D>();
        //acceder al input horizontal 
        //float moveInput = Input.GetAxis("Horizontal");
        float moveInput = entradasMovimiento.Movimiento.Horizontal.ReadValue<float>();
         // Crear un vector de movimiento
        Vector2 move = new Vector2(moveInput * speed, rb.velocity.y);
         // Asignar el vector de movimiento a la velocidad del Rigidbody2D
        rb.velocity = move;
        //Hacer animacion de correr
        animator.SetFloat("Horinzontal", Mathf.Abs(moveInput));
        //Girar
        if (moveInput<0 && !see){
            Girar(); 
        }
        else if (moveInput>0 && see){
            Girar();
        }
        if (MoveR==true)
        {
            MR();
        }
        else if(MoveL==true){
            Ml();
        }
    }
    
    public void MR(){
        rb = this.GetComponent<Rigidbody2D>();
        //acceder al input horizontal 
        float moveInput = 0.75f;
         // Crear un vector de movimiento
        Vector2 move = new Vector2(moveInput * speed, rb.velocity.y);
         // Asignar el vector de movimiento a la velocidad del Rigidbody2D
        rb.velocity = move;
        //Hacer animacion de correr
        animator.SetFloat("Horinzontal", Mathf.Abs(moveInput));
        //Girar
        if (moveInput<0 && !see){
            Girar(); 
        }
        else if (moveInput>0 && see){
            Girar();
        }
        }
    public void Ml(){
        rb = this.GetComponent<Rigidbody2D>();
        //acceder al input horizontal 
        float moveInput = -0.75f;
         // Crear un vector de movimiento
        Vector2 move = new Vector2(moveInput * speed, rb.velocity.y);
         // Asignar el vector de movimiento a la velocidad del Rigidbody2D
        rb.velocity = move;
        //Hacer animacion de correr
        animator.SetFloat("Horinzontal", Mathf.Abs(moveInput));
        //Girar
        if (moveInput<0 && !see){
            Girar(); 
        }
        else if (moveInput>0 && see){
            Girar();
        }
    }
    public void MoveUiR(){
        
        if (MoveR==false)
        {
            MoveR = true;
        }
        else{
            MoveR= false;
        }
        if (MoveL)
        {
            MoveL=false;
        }
        
    }
    public void MoveUiL(){
        
        if (MoveL==false)
        {
            MoveL= true;
        }
        else{
            MoveL= false;
        }
        if (MoveR)
        {
            MoveR=false;
        }
       
    }
    public void Jump(float Fuerza){
        if(isGrounded){
        rb.AddForce(Vector2.up * Fuerza, ForceMode2D.Impulse);}
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    private void Girar(){
        see = !see;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale= escala;
    }
    
}

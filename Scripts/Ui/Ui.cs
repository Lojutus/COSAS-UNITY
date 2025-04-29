using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
public class Ui : MonoBehaviour
{      
    // Start is called before the first frame update
    public TMP_Text pointsText, almacenamientoDerecha, priceMult, pricePower, priceFasterText,priceSpaceText, priceShieldText,priceAlmacenamientoKText,AlmacenamientoText;
    public int Points, shield, shieldEscena; 
    private string Num= "";
    private string NumAntes;
    public int newPoints, Buff, Min, Max, PricePower = 1,priceFaster, priceSpace, priceShield, Almacenamiento =1000, priceAlmacenamientoK,Stack, StackSpawn;
     public GameObject Shield;
   
    public float Price= 1,Space = 1;
    private Spawn spawn;
    public int StackPrice;
    public GameObject deathUI;
    //VARIABLES DEL CRONOMETRO
    public TMP_Text textoCronometro; // Referencia al texto de la UI

    public float tiempoTranscurrido = 0f; // Tiempo acumulado
    private bool cronometroActivo = false;

    //END VARIABLES DEL CRONOMETRO
    void Start()
    {
        GameObject SP = GameObject.Find("Posicion_toque");
        spawn = SP.GetComponent<Spawn>();
        
        Price = 1 ;
        priceFaster = 1;

        priceFasterText.text = priceFaster.ToString(); 

        priceMult.text = Price.ToString();
        pricePower.text = PricePower.ToString();
        shield = -1000;
         priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " K " ;
         IniciarCronometro();
    }

    // Update is called once per frame
    void Update()
    {
         FindAnyObjectByType<DeadBarController>().AddPoints(Points, Stack);

        uiShowPoints();
        
         if(shield>Points){
            Points = shield;
        }
        Cronometer();
        
        
    }
    // function of cronometer starts
    void Cronometer(){
        if (cronometroActivo)
        {
            tiempoTranscurrido += Time.deltaTime; // Incrementar tiempo acumulado
            ActualizarTextoCronometro();
        }
    }
    public void IniciarCronometro()
    {
        cronometroActivo = true;
    }
    public void PausarCronometro()
    {
        cronometroActivo = false;
    }
    public void ReiniciarCronometro()
    {
        cronometroActivo = false;
        tiempoTranscurrido = 0f;
        ActualizarTextoCronometro();
    }
    private void ActualizarTextoCronometro()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        textoCronometro.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }





    //ends
    public void uiShowPoints(){
        
        if (Points>Almacenamiento)// maneja eventos al pasasr del inventario al banco ( inventario izquierda, banco derecha)
        {
            if(Stack==0){// Si Stack es igual a 0 es decir no hay ningun buff de Almacenamineto  ( es menor que 10k )
                newPoints+= Points / 1000;
                spawn.K();
                Num = newPoints.ToString()+ " K " ;
                almacenamientoDerecha.text = Num;
                Points = 0;
                
            }
            else{
                newPoints+= Points / 100;
                Points /= 100;
            }
            
            
        }
        else{
            if(Stack==0){// Si Stack es igual a 0 es decir no hay ningun buff de Almacenamineto  ( es menor que 1000k )
               
                pointsText.text = Points.ToString();
                Num = newPoints.ToString()+ " K " ;
                almacenamientoDerecha.text = Num;
                
                
            }
        }
           
            switch (Stack) // COLOCAR EL VALOR DE SUBIR EL TAMAÑO DEL NUMERO( M, B ...) 
        {
            case 1:
            pointsText.text = Points.ToString()+ "K";
            Num = newPoints.ToString()+ " M " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " M " ;
             break;
            case 2: 
            pointsText.text = Points.ToString()+ "M";
            Num = newPoints.ToString()+ " B " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " B " ;
            break;
            case 3:
            pointsText.text = Points.ToString()+ "B";
            Num = newPoints.ToString()+ " T " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " T " ;
            break;
            case 4:
            pointsText.text = Points.ToString()+ "T";
            Num = newPoints.ToString()+ " Q " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " Q " ;
            break;
            case 5:
            pointsText.text = Points.ToString()+ " Q";
            Num = newPoints.ToString()+ " s " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " s " ;
            break;
            case 6:
            pointsText.text = Points.ToString()+ "s";
            Num = newPoints.ToString()+ " S " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " S " ;
            deathUI.SetActive(true);
            break;
            case 7:
            pointsText.text = Points.ToString()+ "S";
            Num = newPoints.ToString()+ " O " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " O " ;

            break;
            case 8:
            pointsText.text = Points.ToString()+ "O";
            Num = newPoints.ToString()+ " N " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " N " ;
            break;
            case 9:
            pointsText.text = Points.ToString()+ "N";
            Num = newPoints.ToString()+ " d " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " d " ;

        
            break;
            default:
           
             break;
        }

        
       
             
            
            
            //newPoints son los puntos De mil  ( K  POints) ; en el primer nivel
            //Points son los puntos netos ; en el primer nivel 
        
       
    }
    
    public void spawnMult(){
        if (Points>=Price){
            spawn.spawnMult();
            Points -= ((int)Price);
            calculatePrice();
            
            priceMult.text = Price.ToString();
        }
        else{
            Debug.Log("No tienes suficiente puntos");
            ejecutarAnimacion("Points", "Shake");
        }
    }
    void calculatePrice(){
        Price = Price * 2f;
    }
    public void moreNum(){
        
       

        
        if ( PricePower<Points && StackPrice<=Stack){
            Points = Points - PricePower;
            funcionRun();
        }
        if ( StackPrice<Stack){
            for (int i = 0; StackPrice < Stack; i++)
            {
                funcionRun();
            }
            
            
        }
        else if(StackPrice-Stack == 1){
         Debug.Log("Mejorar espacio");
        }
        else{Debug.Log("No puedes ampliar el rango"); ejecutarAnimacion("Points", "Shake");}
        void funcionRun(){
        
        Min = Min + Buff;
        Max = Max + Buff;
        if(StackPrice==Stack){
        PricePower = PricePower * 10;
        }
        Buff =  Random.Range(Min,Max)* 2; 
        
        
        if(Max>1000){
            StackSpawn += 1;
            Min = 1;
            Max = 100;
            Buff =  Random.Range(Min,Max)* 2; 
        }
        }
        if(PricePower>1000){
            StackPrice +=1 ;
            while(PricePower>1000){

            
            
             
            PricePower /= 1000; 

            }
        }
        // Define los sufijos en un array
string[] suffixes = { "K", "M", "B", "T", "Q", "s", "S", "O", "N", "d" };

// Asigna el texto dependiendo del valor de StackPrice
if (StackPrice >= 1 && StackPrice <= suffixes.Length)
{
    pricePower.text = PricePower.ToString() + " " + suffixes[StackPrice - 1] + " ";
}
else
{
    pricePower.text = PricePower.ToString();
}

    }
    public void faster(){
        if( Points > priceFaster && priceFaster*2 < 1000 ){
            spawn.Call();
            Points -= priceFaster;
            priceFaster = priceFaster * 2;
            
            priceFasterText.text = priceFaster.ToString(); 
            
        }
        else{
            Debug.Log("No tienes suficientes puntos");
           
            ejecutarAnimacion("Points", "Shake");

        }
        if(priceFaster*2 > 1000 ){
            priceFasterText.text = "MAX";
        }
        
    }
    
     
    public void SpaceUpdate(){
        if( Points >  priceSpace){

            Space= Space*2f  ;
            Points -=  priceSpace;
            priceSpace =  priceSpace * 3 + 1;
            
            priceSpaceText.text =priceSpace.ToString(); 
            
        }
    
    }// CUANDO SE TE ACABE EL TIEMPO PIERDES(PUEDES COMPRAR MAS ) 
    public void InstanciarEscudoEnCamara()
    {
        if(Points> priceShield){
         // Obtener la posición de la cámara principal
        Vector3 posicionCamara = Camera.main.transform.position;
        // Añadir un desplazamiento en el eje Z para que el objeto aparezca frente a la cámara
        Vector3 posicionObjeto = posicionCamara + Camera.main.transform.forward * 2;

        // Instanciar el objeto en la posición calculada con la rotación predeterminada (sin rotación)
        Instantiate(Shield, posicionObjeto, Quaternion.identity);
        shieldEscena +=1;
            Points -=  priceShield;
            priceShield =   100 * shieldEscena;
            priceShieldText.text = priceShield.ToString();
        }
        
    }
    public void AlmacenamientoUpdate(){
        
        if(priceFaster*2 > 1000){
        if(newPoints>=priceAlmacenamientoK ){
            newPoints= newPoints- priceAlmacenamientoK; 
            Almacenamiento= Almacenamiento * 4;
            priceAlmacenamientoK = priceAlmacenamientoK * 3;
            
            
        }
        if(Almacenamiento>100000){//Aqui iria la logica cuando llegue el almacenamiento a 100K 
            Stack+=1;
            Almacenamiento /= 1000;
            newPoints/=1000;
            priceAlmacenamientoK = 5;
            Price = 1;
            Points = PricePower + 1 ; 
            moreNum();
           
        }
        
        if(Stack==0){//No hay aunmento de Espacio  K
            Num = newPoints.ToString()+ " K " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " K " ;
        }
        if(Stack==1){
            Num = newPoints.ToString()+ " M " ;
            almacenamientoDerecha.text = Num;
            AlmacenamientoText.text = Almacenamiento.ToString();
            priceAlmacenamientoKText.text = priceAlmacenamientoK.ToString()+ " M " ;
        }
         

        

        
        }
        else{
            Debug.Log("No puedes aumentar el esapcio");
            ejecutarAnimacion("Aumentar Velocidad", "Shake");
        }
       
        
         
    }
void ejecutarAnimacion(string Object , string Animacion){ // Para que funcione necesita tener el Script llamado AnimatorController El objeto que se quiere que haga la animacion
    GameObject pointsObject = GameObject.Find(Object);  // Busca el objeto "Object" en la escena y obtiene el script AnimatorController
            if (pointsObject != null)
            {
                AnimatorController animController = pointsObject.GetComponent<AnimatorController>();
                if (animController != null)
                {
                    animController.ReproducirAnimacion(Animacion);
                    
                }
                else{ 
                    Debug.Log("No se encontró el controlador de animación");
                }
            }
            else{
                Debug.Log("No se encontró el objeto: " +  Points);
            }
}
}
// hACER QUE SE PUEDA COMPRAR CON STACKS diferentes (Creo que ya), colocar los botones con stack , cuando lelgue al maximo la velocidad de spawn cambiar por otro buffo
/*  Colocar un boton para bufear todo (hacer el M), 1m = 1000k  
M – Millón (1,000,000) Hecho
B – Billón (1,000,000,000)
T – Trillón (1,000,000,000,000)
q – Cuatrillón (1,000,000,000,000,000)
Q – Quintillón (1,000,000,000,000,000,000)
s – Sextillón (1,000,000,000,000,000,000,000)
S – Septillón (1,000,000,000,000,000,000,000,000)
O – Octillón (1,000,000,000,000,000,000,000,000,000)
N – Nonillón (1,000,000,000,000,000,000,000,000,000,000)
d – Decillón (1,000,000,000,000,000,000,000,000,000,000,000)*/ 
/* Brebe explicacion de  como funciona el sitema de stacks: Cada stack significa que llego a un nuevo nuemro(lo que estan arriba) Hay7 dos tipos de Stacks 
1 : El stack de almacenamiento el cual afecta a el banco ( Numeros a la Derecha ) Y Puntos Usables ( los que estan a ala izquierda)
2 : El stack de Spawn el cual afecta a que tan grandes son los numeros que salen del spawn ese comienza a cntar desde 1 = K  , 2 = M........

Si no tiene el mismo Spawn no se pueden Operar 



*/
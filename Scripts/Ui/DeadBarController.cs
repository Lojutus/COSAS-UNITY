using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DeadBarController : MonoBehaviour
{
    public Slider deadBar; // Asigna aquí el Slider
    public float decreaseSpeed = 5f; // Velocidad de reducción
    public TMP_Text Target;
    private float currentValue; // Valor actual de la barra
    public float valueToUp; // Value para...
    public float stackValueToUp; // stack para que... 
    public GameObject deathUI;
    [SerializeField]  private int Contador, Top =13 ; //Cuenta cuantas veces se a rellenado la barrra  para asi subir el stack 

     private Ui ui;
    void Start()
    {
        currentValue = deadBar.maxValue; // Inicializa la barra llena
        deadBar.value = currentValue;
        GameObject UI = GameObject.Find("Canvas");
        ui = UI.GetComponent<Ui>();

    }

    void Update()
    {
        Uitarget();
        if (Contador >= Top){
            Contador = 0;
            stackValueToUp += 1;
            valueToUp = 1;
        }
        if(ui.Stack>stackValueToUp)
        {
            stackValueToUp = ui.Stack;
            valueToUp = 2;
            Contador = 0;

        }
        


        // Reducir la barra poco a poco
        if (currentValue > 0)
        {
            currentValue -= decreaseSpeed * Time.deltaTime;
            deadBar.value = currentValue;
        }
        else
        {
            // Ejecutar lógica de derrota
            Debug.Log("¡Has perdido!");
            deathUI.SetActive(true);
        }
    }
    void Uitarget(){
        switch (stackValueToUp) // COLOCAR EL VALOR DE SUBIR EL TAMAÑO DEL NUMERO( M, B ...) 
        {
            case 1:
            Target.text =valueToUp.ToString()+ "K";
             break;
            case 2: 
            Target.text =valueToUp.ToString()+ "M";
            break;
            case 3:
            Target.text =valueToUp.ToString()+ "B";
            break;
            case 4:
            Target.text =valueToUp.ToString()+ "T";
            break;
            case 5:
           Target.text =valueToUp.ToString()+ "Q";
            break;
            case 6:
            Target.text =valueToUp.ToString()+ "s";
            break;
            case 7:
            Target.text =valueToUp.ToString()+ "S";
            break;
            case 8:
            Target.text =valueToUp.ToString()+ "O";
            break;
            case 9:
            Target.text =valueToUp.ToString()+ "N";

        
            break;
            default:
           Target.text =valueToUp.ToString();
             break;
    }
    }

    // Llamar cuando el jugador gane puntos
    public void AddPoints(int points, int Stack)
    {
        if(points>= valueToUp&& Stack >= stackValueToUp ){
            if ( stackValueToUp == 0){
                currentValue = deadBar.maxValue;
                valueToUp *= 2;
                Contador +=1;
            }
            else{
                currentValue = deadBar.maxValue;
                valueToUp *= 2;
                Contador +=1;
            }
            

        }
        
        
    }
}

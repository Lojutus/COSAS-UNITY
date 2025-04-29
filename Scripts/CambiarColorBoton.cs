using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con UI en Unity

public class CambiarColorBoton : MonoBehaviour
{
    public Button boton; // Referencia al botón que quieres cambiar de color
    public int Nivel;    // Variable que controla el nivel
    public int Boton;    // Variable que controla el umbral del botón

    public string NameLevel;

    public SceneChanger sceneChanger; // Referencia pública a SceneChanger
    [SerializeField] private GameObject All, Button, Inicio,Jugar;

    void Start()
    {
        //Nivel = PlayerPrefs.GetInt("Nivel", 1);
        Nivel = 10;
        boton = GetComponent<Button>();
        // Asignar la función al botón cuando sea clicado
        CambiarColor();
         // Asignar la función al botón cuando sea clicado
        boton.onClick.AddListener(CambiarColor);
        
         

    }

    // Función para cambiar el color del botón
    
    void CambiarColor()
    {
        
        Color nuevoColor;

        if (Nivel >= Boton)
        {
             do
            {
                nuevoColor = new Color(Random.value, Random.value, Random.value);
            }
            while (EsRojo(nuevoColor)); // Verificar si el color es demasiado cercano al rojo
        }
        else
        {
            
            nuevoColor = new Color(1f, 0.4f, 0.4f); // Rojo claro
        }

        // Cambiar el color del botón
        ColorBlock colorBlock = boton.colors;
        colorBlock.normalColor = nuevoColor;
        boton.colors = colorBlock;
        bool EsRojo(Color color)
    {
        // Definir un umbral de cercanía al rojo (por ejemplo, si el valor de R es alto y G y B son bajos)
        return color.r > 0.7f && color.g < 0.3f && color.b < 0.3f;
    }
    }
    public void Use(){
        if (Nivel >= Boton)
        {
             // Cambiar a la escena deseada, por ejemplo "MainMenu"
             sceneChanger.ChangeScene(NameLevel);
             Debug.Log("exe");
        }
    }
    public void On(){
        
        All.SetActive(true);
        Button.SetActive(false);
       
    }
    public void InicioT(){
        All.SetActive(true);
        Button.SetActive(false);
        Jugar.SetActive(false);
        OpenURL();
    }
    void OpenURL()
    {
        // Reemplaza la URL con la que desees
        Application.OpenURL("https://docs.google.com/spreadsheets/d/1iYeGyefHJWQ8iVp60T0XWsE7iget-6_t__44mDZiPGU/edit?usp=drivesdk");
    }
    public void mostrar(){
        Inicio.SetActive(true);
        Jugar.SetActive(false);
    }
}

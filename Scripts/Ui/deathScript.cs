using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class deathScript : MonoBehaviour
{
    private Ui ui;
    private float AllTime;

    private float bestTimePlayed = 0;

    [SerializeField] private TMP_Text textBestScore, textoCronometro;
    public GameObject panelUI, areaGame, pointer;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject UI = GameObject.Find("Canvas");
        ui = UI.GetComponent<Ui>();
        bestTimePlayed = PlayerPrefs.GetFloat("Best Score", 0);
        deathScreenBehaviour();

    }
    void OnEnable()
    {
        deathScreenBehaviour();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void deathScreenBehaviour(){
        AllTime = ui.tiempoTranscurrido;
        if (bestTimePlayed < AllTime){ // actualizar el mejor puntaje si es necesario
            bestTimePlayed = AllTime;
            PlayerPrefs.SetFloat("Best Score", bestTimePlayed);
        }
        if (panelUI != null && areaGame != null)
        {
            panelUI.SetActive(false);
            areaGame.SetActive(false);
            pointer.SetActive(false);
        }
        ActualizarTextoCronometro(textBestScore , bestTimePlayed);
        ActualizarTextoCronometro(textoCronometro , AllTime);
    }
    private void ActualizarTextoCronometro(TMP_Text Text , float Timer)
    {
        int minutos = Mathf.FloorToInt( Timer / 60);
        int segundos = Mathf.FloorToInt( Timer % 60);
        Text.text = minutos.ToString("00") + ":" + segundos.ToString("00");
    }
    //Recuperar datos maximos, mostrar el maximo Y si el puntaje de esta partida supero al maximo
    //mostrar algo que muestre mejor puntaje 
}

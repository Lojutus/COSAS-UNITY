using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behaviors : MonoBehaviour
{
    [SerializeField] private GameObject Heart;
    [SerializeField] private GameObject Heart1;
    [SerializeField] private GameObject Heart2;
    [SerializeField] private int Healt;
    [SerializeField] private GameObject Respawn;
    
    [SerializeField] private GameObject Death;
     private bool isCoroutineRunning = false;

    public void Damage(){
       if (!isCoroutineRunning) 
       {
        StartCoroutine(Contador());
       }
    }
    void Update()
    {
        if (Healt == 1){
           Death.SetActive(true);
        }
        if (gameObject.transform.position.y< -80){
            Damage();
        }
        
    }
    IEnumerator Contador(){
        isCoroutineRunning = true;
        
        switch (Healt)
       {
        
        case 1:
        
        Death.SetActive(true);
        Debug.Log(Healt);
        break;
        case 2:
        Heart.SetActive(false);
        
        Debug.Log(Healt);
        break;
        case 3:
        Heart1.SetActive(false);
        
        break;
        case 4:
        Heart2.SetActive(false);
        
        
        Debug.Log(Healt);
        break;
        
       } 
       gameObject.transform.position = Respawn.transform.position;
       
       Healt--;
       yield return new WaitForSeconds(1);
       isCoroutineRunning = false;
       
    }
}

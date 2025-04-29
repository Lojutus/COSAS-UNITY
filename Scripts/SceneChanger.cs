using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour 
    

{
    // Start is called before the first frame update
    
    // Update is called once per frame
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }
}

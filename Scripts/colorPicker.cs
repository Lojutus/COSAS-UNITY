using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class colorPicker : MonoBehaviour, IPointerClickHandler
{
    public Color output;
    private bool active;
    void Start()
    {
        output= Color.blue;
    }
    public Color Obtener(){
        return output;
    }
    public void OnPointerClick (PointerEventData eventData)
    {

        output = Pick(Camera.main.WorldToScreenPoint(eventData.position), GetComponent<Image>());
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("makeUp");

        foreach (GameObject objeto in objetos)
        {
            Arrastrable arrastrable;
            arrastrable = objeto.GetComponent<Arrastrable>();
            arrastrable.color= output;
            Debug.Log(arrastrable.color); 
        }
    }

void Update()
{
    
}
    Color Pick (Vector2 screenPoint, Image imageToPick)
    {

        Vector2 point;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageToPick.rectTransform, screenPoint, Camera.main, out point);
        point += imageToPick.rectTransform.sizeDelta / 2;

        Texture2D t = GetComponent<Image>().sprite.texture;

        Vector2Int m_point =
            new Vector2Int((int)((t.width * point.x) / imageToPick.rectTransform.sizeDelta.x)
            , (int)((t.height * point.y) / imageToPick.rectTransform.sizeDelta.y));
        

        return t.GetPixel(m_point.x, m_point.y);


    }
    public void Active(){
        if (active)
        {
            gameObject.SetActive(false);
            active=false;
        }
        else{
            gameObject.SetActive(true);
            active=true;
        }
        
    }
}

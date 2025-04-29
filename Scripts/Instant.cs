using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject lips,brush,eyes,Point;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Brush(){
        EliminarObjetosConEtiqueta();
        Instantiate(brush, Point.transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }
    public void Lips(){
        EliminarObjetosConEtiqueta();
        Instantiate(lips, Point.transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }
    public void Eyes(){
        EliminarObjetosConEtiqueta();
        Instantiate(eyes, Point.transform.position, Quaternion.identity);
        GetComponent<AudioSource>().Play();
    }
    void EliminarObjetosConEtiqueta()
    {
        GameObject[] objetos = GameObject.FindGameObjectsWithTag("makeUp");

        foreach (GameObject objeto in objetos)
        {
            Destroy(objeto);
        }
    }

}

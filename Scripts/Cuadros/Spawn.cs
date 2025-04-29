using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Spawn:MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos;
    [SerializeField] private GameObject[] Cubos;

    [SerializeField] private GameObject mil, Mult, Particles;
      // Variable interna para el control del temporizador
    private float tiempoUltimaEjecucion = -Mathf.Infinity;
    public float wait;
    private bool All = true;
    // Referencia al sistema de partículas
    private ParticleSystem sistemaDeParticulas;
    public ObjectPool objectPool;

    // Start is called before the first frame update
    void Start()
    {
        //Establecemos puntos de aparicion y establecemos minimos y maximos 
        maxX = puntos.Max(puntos => puntos.position.x);
        minX = puntos.Min(puntos => puntos.position.x);
        maxY = puntos.Max(puntos => puntos.position.y);
        minY = puntos.Min(puntos => puntos.position.y);
        wait = 2f;
         // Obtener el sistema de partículas en el objeto
        sistemaDeParticulas = Particles.GetComponent<ParticleSystem>();
        
        StartCoroutine(EjecutarFuncionCadaCiertoTiempo());
     
        GameObject ObjectPool = GameObject.Find("ManagerPool");
        objectPool = ObjectPool.GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void spawn(){
        //Hace aparecer en una posicion aleatoria 
        GameObject obj = objectPool.GetObject();

        Vector2 Posicion_Aleatoria =  new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));

        obj.transform.position = Posicion_Aleatoria;
        
    }
    public void spawnMult(){
        Vector2 Posicion_Aleatoria =  new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));
         Instantiate (Mult, Posicion_Aleatoria , Quaternion.identity);
    }
    public void K(){
        /*Vector2 Posicion_Aleatoria =  new Vector2(Random.Range(minX, maxX),Random.Range(minY, maxY));
        Instantiate (mil, Posicion_Aleatoria , Quaternion.identity);*/
        if (sistemaDeParticulas != null)
        {
            // Emitir partículas
            sistemaDeParticulas.Stop(false, ParticleSystemStopBehavior.StopEmitting);

            sistemaDeParticulas.Play();
        }
        else{
            Debug.Log("No se ha encontrado el sistema de partículas");
        }
       

    }
    public  void spawnRetardo()
    {
        // Verificar si han pasado al menos 5 segundos desde la última ejecución
        if (Time.time >= tiempoUltimaEjecucion + wait)
        {
            // Actualizar el tiempo de la última ejecución
            tiempoUltimaEjecucion = Time.time;

            // Ejecutar la lógica de la función
            spawn();
        }
    }
    IEnumerator EjecutarFuncionCadaCiertoTiempo()
    {
        while (All)
        {
            // Ejecutar la función
            spawn();
            
            // Esperar "intervalo" segundos antes de repetir
            yield return new WaitForSeconds(wait);
        }
    }
    public void Call(){
        
        if(wait-0.1>0){
            wait-=0.1f;
            
        }

    }
    
}

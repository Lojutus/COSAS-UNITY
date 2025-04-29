using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    [SerializeField] private Vector2 Speed;
    private Vector2 offSet;
    private Material material;
    private Rigidbody2D jugadorRB;

   
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugadorRB = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    
    void Update()
    {
        offSet = (jugadorRB.velocity.x* 0.1f) *Speed * Time.deltaTime;
        material.mainTextureOffset += offSet;
    }
}

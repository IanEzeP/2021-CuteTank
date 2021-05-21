using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugador : MonoBehaviour
{
    public float distancia = 10.0f;
    public Transform objetivo;
    public float velocidad = 1.0f;
    
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var target = objetivo.position + objetivo.up * distancia;
        transform.position = Vector3.Lerp(transform.position, target, velocidad * Time.deltaTime);
    }
}

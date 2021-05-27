using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NamesHUD : MonoBehaviour
{
    public Transform objetivo;
    public float velocidad = 10.0f;
    public GameObject nameTag;

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        var target = objetivo.position;
        transform.position = Vector3.Lerp(transform.position, target, velocidad * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    public enum TipoBloque
    {
        Destruible,
        Indestructible,
        Atravesable,
    }
    public TipoBloque tipoBloque = TipoBloque.Destruible;

    public bool esAtravesable
    {
        get 
        {
            return tipoBloque == TipoBloque.Atravesable;
        }
    }

    public bool esDestruible
    {
        get
        {
            return tipoBloque == TipoBloque.Destruible;
        }
    }

    public bool esIndestructible
    {
        get
        {
            return tipoBloque == TipoBloque.Indestructible;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && esDestruible)
        {
            GameObject.Destroy(gameObject);
        }
    }


    void Start()
    {
        if (esAtravesable)
        {
            foreach (Collider c in transform.GetComponentsInChildren<Collider>())
            {
                c.enabled = false;
            }
        }
    }

    
    void Update()
    {
        
    }
}

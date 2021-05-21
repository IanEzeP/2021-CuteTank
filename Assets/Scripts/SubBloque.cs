using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBloque : MonoBehaviour
{
    private Bloques padre;

    public void OnDamage()
    {
        if (padre.esIndestructible)
            return;
        
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (padre.esDestruible && other.CompareTag("Bullet"))
        {
            OnDamage();
        }
    }

    void Start()
    {
        padre = transform.parent.GetComponent<Bloques>();
    }

    
    void Update()
    {
        
    }
}

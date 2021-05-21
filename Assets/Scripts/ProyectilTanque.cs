using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilTanque : MonoBehaviour
{
    public AudioClip sonidoExplosion;
    public ParticleSystem prefabExplosion;
    public float radioExplosion = 1.0f;
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            return;
        }

        var managerFx = GameObject.Find("ManagerAudio");
        var manager = managerFx.GetComponent<FxSonidoManager>();
        manager.PlaySonido(sonidoExplosion, transform.position);

        var explosion = GameObject.Instantiate(prefabExplosion, transform.position, Quaternion.identity);

        Collider[] cols = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (var c in cols)
        {
            if (c.gameObject == gameObject)
                continue;
            SubBloque sb = c.GetComponent<SubBloque>();
            if (sb != null)
            {
                sb.OnDamage();
            }
        }    
        GameObject.Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }

    void Update()
    {
        
    }

}

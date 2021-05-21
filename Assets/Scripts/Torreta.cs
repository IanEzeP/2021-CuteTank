using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{

    void CancelarCoolDown()
    {
        puedoDisparar = true;
    }

    public float velocidad = 1.0f;
    private bool f;
    public GameObject prefabProyectil;
    public Transform origenDisparo;
    public float potenciaDisparo = 1.0f;

    public float cooldownDisparo = 0.1f;
    private bool puedoDisparar = true;
    public Camera cam;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private Quaternion rotacionObjetivo;

    void Update()
    {
        Ray rayPicking = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        int mascara = (1 << LayerMask.NameToLayer("Floors"));
        bool colisiono = Physics.Raycast(rayPicking, out hit, 100.0f, mascara);
        if (colisiono)
        {
            Vector3 dir = (hit.point - transform.position);
            dir.y = 0.0f;
            dir.Normalize();
            rotacionObjetivo = Quaternion.LookRotation(dir, Vector3.up);
        }
        
        f = Input.GetButtonDown("Fire1");

        if (f && puedoDisparar)
        {
            Invoke("CancelarCoolDown", cooldownDisparo);
            puedoDisparar = false;
            Rigidbody rbTanque = GetComponentInParent<Rigidbody>();
            GameObject proyectil = GameObject.Instantiate(prefabProyectil, origenDisparo.position, origenDisparo.rotation);
            Rigidbody rb = proyectil.GetComponent<Rigidbody>();
            rb.velocity = origenDisparo.forward * potenciaDisparo + rbTanque.velocity;
        }
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidad * Time.deltaTime);
    }
}

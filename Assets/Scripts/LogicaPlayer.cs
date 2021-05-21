using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPlayer : MonoBehaviour
{
    public AudioClip sonidoEnMarcha;
    public AudioClip sonidoQuieto;
    private AudioSource audioSource;

    public float velocidadLineal = 1.5f;
    public float velocidadRotacion = 1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        velocidadMinMax = new Vector2(0.0f, velocidadLineal);
    }

    private Rigidbody rb;
    private float h;
    private float v;

    public Vector2 pitchMinMax = new Vector2(1.0f, 1.4f);
    private Vector2 velocidadMinMax;
    void Update()
    {
        h = Input.GetAxis("Horizontal1");
        v = Input.GetAxis("Vertical1");
        
        if (audioSource != null)
        {
            if (rb.velocity.sqrMagnitude > 0.1f)
            {
                if ((audioSource.clip != sonidoEnMarcha) || !audioSource.isPlaying)
                {
                    audioSource.clip = sonidoEnMarcha;
                    audioSource.Play();
                }
                float pitchCoef = Mathf.InverseLerp(velocidadMinMax.x, velocidadMinMax.y, rb.velocity.magnitude);
                audioSource.pitch = Mathf.Lerp(pitchMinMax.x, pitchMinMax.y, pitchCoef);
            }
            else
            {
                if ((audioSource.clip != sonidoQuieto) || !audioSource.isPlaying)
                {
                    audioSource.clip = sonidoQuieto;
                    audioSource.Play();
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.velocity = v * transform.forward * velocidadLineal + Vector3.up * rb.velocity.y;
        rb.angularVelocity = h * transform.up * velocidadRotacion;
    }
}

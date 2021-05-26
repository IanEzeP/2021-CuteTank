using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVidas : MonoBehaviour
{
    private Vidas vidasPlayer = null;
    private Slider slider = null;

    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            vidasPlayer = player.GetComponent<Vidas>();

        slider = GetComponent<Slider>();
        slider.maxValue = 100.0f;
        slider.minValue = 0.0f;
    }

    void Update()
    {
        if (vidasPlayer == null)
            return;

        slider.value = vidasPlayer.vidas;
    }
}

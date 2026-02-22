using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    [SerializeField] Light2D light;
    
    public float _intensity;
    public float intensity {get => _intensity; set => _intensity = value; }

    private void Update()
    {
        light.intensity = Mathf.Lerp(light.intensity, intensity, Time.deltaTime);
    }
}

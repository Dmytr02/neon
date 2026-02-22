using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HandCorall : MonoBehaviour
{
    [SerializeField] private float maxTimeToDestry = 15;
    private float timeToDestry = 15;
    [SerializeField] private Light2D light;
    [SerializeField] AnimationCurve lightIntensityCurve;

    private void Start()
    {
        timeToDestry = maxTimeToDestry;
    }

    private void Update()
    {
        timeToDestry -= Time.deltaTime;
        light.intensity = lightIntensityCurve.Evaluate(timeToDestry/maxTimeToDestry);
        
        if (timeToDestry <= 0)
        {
            DeathController.Instance.Death();
            Destroy(gameObject);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class TrigerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    private void OnTriggerEnter2D(Collider2D other)
    {
        onTriggerEnter?.Invoke();
    }
}

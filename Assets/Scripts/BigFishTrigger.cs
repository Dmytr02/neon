using System;
using UnityEngine;

public class BigFishTrigger : MonoBehaviour
{
    [SerializeField] GameObject fish1;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D other)
    {
        fish1.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}

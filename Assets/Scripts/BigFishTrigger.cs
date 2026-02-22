using System;
using UnityEngine;

public class BigFishTrigger : MonoBehaviour
{
    [SerializeField] Fish1 fish1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        fish1.gameObject.SetActive(true);
        Destroy(this.gameObject);
    }
}

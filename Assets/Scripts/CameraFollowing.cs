using System;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position = new Vector3(0,0,-10) + (Vector3)Vector2.Lerp(transform.position, target.position, Time.deltaTime * speed);
    }
}

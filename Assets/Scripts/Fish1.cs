using System.Linq;
using UnityEngine;

public class Fish1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody2D rb;

    
    void Update()
    {
        rb.linearVelocity += (Vector2)(PlayerMovment.Instance.transform.position - transform.position).normalized * (speed * Time.deltaTime);
        
    }

    public void TryKill()
    {
        Collider2D overlap = Physics2D.OverlapCircle(transform.position, 10, 1 << LayerMask.NameToLayer("Player"));
        if (overlap)
        {
            Debug.Log("Death");
        }
    }
}

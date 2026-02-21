using System.Linq;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private Vector2[] Points;
    [SerializeField] private float lookRadius;

    private int index = -1;
    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerMovment.Instance.transform.position - transform.position, lookRadius);
        if (hit.collider && hit.collider.gameObject.TryGetComponent<PlayerMovment>(out PlayerMovment player) && !player.GetComponentInChildren<HandAlgae>())
        {
            index = -1;
            rb.linearVelocity += (Vector2)(PlayerMovment.Instance.transform.position - transform.position).normalized * (speed * Time.deltaTime);
            Collider2D overlap = Physics2D.OverlapCircle(transform.position, 0.5f, 1 << LayerMask.NameToLayer("Player"));
            if (overlap)
            {
                Debug.Log("Death");
            }
        }
        else
        {
            if (index == -1) index = Points.Select(((v, i) => new {v, i})).OrderByDescending(n => (n.v - (Vector2)transform.position).magnitude).Last().i;
            
            Debug.Log(index);
            if ((Points[index] - (Vector2)transform.position).magnitude < 0.1f)
            {
                index = (index+1)%Points.Length;
            }
            rb.linearVelocity += (Points[index] - (Vector2)transform.position).normalized * (speed * Time.deltaTime);
            
        }
    }
}

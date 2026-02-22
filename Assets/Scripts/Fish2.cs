using System.Linq;
using UnityEngine;

public class Fish2 : MonoBehaviour
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
            if ((Points[index] - (Vector2)transform.position).magnitude < 1f)
            {
                index = Mathf.Min(index+1, Points.Length-1);
            }
            Debug.Log(Mathf.Clamp01(((Vector2)PlayerMovment.Instance.transform.position - (Vector2)transform.position).magnitude/lookRadius));
            rb.linearVelocity += Vector2.Lerp(((Vector2)transform.position - (Vector2)PlayerMovment.Instance.transform.position), (Points[index] - (Vector2)transform.position), Mathf.Clamp01(((Vector2)PlayerMovment.Instance.transform.position - (Vector2)transform.position).magnitude/lookRadius)).normalized * (speed * Time.deltaTime) ;
        }
        else
        {
            if (index == -1) index = Points.Select(((v, i) => new {v, i})).OrderByDescending(n => (n.v - (Vector2)transform.position).magnitude).Last().i;
            
            /*Debug.Log(index);
            if ((Points[Mathf.Max(index-1, 0)] - (Vector2)transform.position).magnitude < 0.1f)
            {
                index = Mathf.Max(index-1, 0);
            }*/
            
            rb.linearVelocity += (Points[Mathf.Max(index-1, 0)] - (Vector2)transform.position).normalized * (speed * Time.deltaTime);
        }
    }
}

using UnityEngine;

public class Fish : MonoBehaviour
{
    
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, PlayerMovment.Instance.transform.position - transform.position, 5);
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent<PlayerMovment>(out PlayerMovment player))
        {
            
        }
    }
}

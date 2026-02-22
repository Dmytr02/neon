using System.Linq;
using UnityEngine;

public class Fish1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Rigidbody2D rb;

    
    void Update()
    {
        rb.linearVelocity += (Vector2)(PlayerMovment.Instance.transform.position - transform.position).normalized * (speed * Time.deltaTime);
        float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
        // Вычитаем 90, если спрайт изначально смотрит вверх, а не вправо
        if (angle < 90 && angle > -90) transform.rotation = Quaternion.Euler(0, 180, 180 - angle);
        else transform.rotation = Quaternion.Euler(0, 0, angle);
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

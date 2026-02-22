using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] Rigidbody2D rb;
    
    public static PlayerMovment Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.W)) input += Vector2.up;
        if (Input.GetKey(KeyCode.A)) input += Vector2.left;
        if (Input.GetKey(KeyCode.S)) input += Vector2.down;
        if (Input.GetKey(KeyCode.D)) input += Vector2.right;

        rb.linearVelocity += input.normalized * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
        transform.up = rb.velocity.normalized;
        /*if (rb.linearVelocity != Vector2.zero)
        {
            transform.Rotate(90, 0, 0);
            transform.Rotate(0, 90, 0);
        }*/
    }
}

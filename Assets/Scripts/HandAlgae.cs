using UnityEngine;

public class HandAlgae : MonoBehaviour
{
    
    [SerializeField] private float maxTimeToDestry = 15;
    private float timeToDestry = 15;
    private void Start()
    {
        timeToDestry = maxTimeToDestry;
    }

    private void Update()
    {
        timeToDestry -= Time.deltaTime;
        
        if (timeToDestry <= 0)
        {
            Destroy(gameObject);
        }
    }
}

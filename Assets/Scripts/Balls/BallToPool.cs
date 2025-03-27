using UnityEngine;

public class BallToPool : MonoBehaviour
{
    Rigidbody rb;
    PoolBalls poolBalls;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        poolBalls = FindObjectOfType<PoolBalls>();    
    }

    private void Update()
    {
        if(transform.position.y <= 0)
        {
            rb.isKinematic = true;
            poolBalls.ReturnObject(gameObject);
        }
        else
            rb.isKinematic = false;
    }
}

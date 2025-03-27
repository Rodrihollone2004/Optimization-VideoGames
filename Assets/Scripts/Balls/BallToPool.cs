using UnityEngine;

public class BallToPool : MonoBehaviour
{
    PoolBalls poolBalls;

    private void Start()
    {
        poolBalls = FindObjectOfType<PoolBalls>();    
    }

    private void Update()
    {
        if(transform.position.y <= 0)
        {
            poolBalls.ReturnObject(gameObject);
        }
    }
}

using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y <= 0) Destroy(this.gameObject);
    }
}

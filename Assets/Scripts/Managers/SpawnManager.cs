using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    Vector3 posSpawn;
    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    private void Start()
    {
        posSpawn = transform.position;        
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        SpawnBalls();
    }

    public void SpawnBalls()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (currentTime >= delayTime)
            {
                posSpawn = new Vector3(Random.Range(posSpawn.x - 5f, posSpawn.x + 5f), posSpawn.y, posSpawn.z);
                int index = Random.Range(0, balls.Length);
                Instantiate(balls[index], posSpawn, Quaternion.identity);
                currentTime = 0;
            }
        }
    }
}

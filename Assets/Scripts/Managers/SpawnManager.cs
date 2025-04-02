using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] balls;

    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    [SerializeField] bool isActive;

    private void Update()
    {
        InputPuase();

        if (isActive)
        {
            currentTime += Time.deltaTime;
            SpawnBalls();
        }
    }

    public void SpawnBalls()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (currentTime >= delayTime)
            {
                int index = Random.Range(0, balls.Length);
                GameObject newBall = Instantiate(balls[index], transform.position, Quaternion.identity);
                newBall.transform.SetParent(this.transform);

                currentTime = 0;
            }
        }
    }

    public void InputPuase()
    {
        if (Input.GetKeyDown(KeyCode.N)) isActive = !isActive;
    }
}

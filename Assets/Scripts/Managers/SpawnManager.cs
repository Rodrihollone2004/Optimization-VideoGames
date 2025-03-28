using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    Vector3 posSpawn;

    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    [SerializeField] bool isActive;

    CheckManager checkerManager;

    private void Start()
    {
        posSpawn = transform.position;
        checkerManager = FindObjectOfType<CheckManager>();
    }

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
                Vector3 timePos = new Vector3(Random.Range(posSpawn.x - 5f, posSpawn.x + 2f), posSpawn.y, posSpawn.z);
                int index = Random.Range(0, balls.Length);
                GameObject newBall = Instantiate(balls[index], timePos, Quaternion.identity);
                char letter = newBall.GetComponent<Balls>().SetRandomChar();
                checkerManager.CheckX.Add(letter);
                currentTime = 0;
            }
        }
    }

    public void InputPuase()
    {
        if (Input.GetKeyDown(KeyCode.N)) isActive = !isActive;
    }
}

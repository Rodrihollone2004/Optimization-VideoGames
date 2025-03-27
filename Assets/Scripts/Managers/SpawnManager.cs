using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    Vector3 posSpawn;

    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    [SerializeField] bool isActive;

    TMP_Text textChar;
    Queue<char> chars = new Queue<char>();

    private void Awake()
    {
        textChar = GetComponent<TMP_Text>();
    }

    private void Start()
    {
        posSpawn = transform.position;        
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
                newBall.GetComponent<Balls>().SetRandomChar();
                currentTime = 0;
            }
        }
    }

    public void InputPuase()
    {
        if (Input.GetKeyDown(KeyCode.N)) isActive = !isActive;
    }
}

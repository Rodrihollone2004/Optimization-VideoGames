using System.Collections.Generic;
using UnityEngine;

public class PoolBalls : MonoBehaviour
{
    [SerializeField] GameObject[] balls;
    Vector3 posSpawn;
    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();

    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    [SerializeField] bool isActive;

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
            if (currentTime >= delayTime)
            {
                GetBall();
                currentTime = 0;
            }
        }
    }

    public GameObject GetBall()
    {
        GameObject obj = null;

        if (pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            Vector3 timePos = new Vector3(Random.Range(posSpawn.x - 5f, posSpawn.x + 3f), posSpawn.y, posSpawn.z);
            int index = Random.Range(0, balls.Length);
            obj = Instantiate(balls[index], timePos, Quaternion.identity);
            obj.GetComponent<Balls>().SetRandomChar();
        }


        obj.transform.position = transform.position;
        obj.transform.rotation = Quaternion.identity;
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public void InputPuase()
    {
        if (Input.GetKeyDown(KeyCode.M)) isActive = !isActive;
    }
}

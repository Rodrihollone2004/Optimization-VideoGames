using System.Collections.Generic;
using UnityEngine;

public class PoolBalls : MonoBehaviour
{
    [SerializeField] GameObject[] balls;

    private Queue<GameObject> pool = new Queue<GameObject>();

    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    [SerializeField] bool isActive;

    private void Update()
    {
        InputPause();

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
            int index = Random.Range(0, balls.Length);
            GameObject newBall = Instantiate(balls[index], transform.position, Quaternion.identity);
            newBall.transform.SetParent(this.transform);
        }

        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.M)) isActive = !isActive;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PoolBalls : MonoBehaviour
{
    //Por inspector le pasamos los diferentes tipos de bolas que hay a instanciar
    [SerializeField] GameObject[] balls;

    //Creamos una cola donde va a guardar las bolas que ya hayan caido 
    private Queue<GameObject> pool = new Queue<GameObject>();

    //tiempo del Timer entre spawn y spawn
    [SerializeField] float delayTime;
    [SerializeField] float currentTime;

    //bool para pausar cuando se toque una tecla
    [SerializeField] bool isActive;

    private void Update()
    {
        InputPause();

        //solo si esta true pasa
        if (isActive)
        {
            //crea un contador, el cual cuando llega al tiempo delimitado, se fija en la función GetBall para saber si tiene que sacar una bola de la cola o crear una nueva
            currentTime += Time.deltaTime;
            if (currentTime >= delayTime)
            {
                GetBall();
                currentTime = 0; //Después setea el tiempo en 0 para resetear el timer
            }
        }
    }

    public GameObject GetBall()
    {
        //crea un objeto nulo
        GameObject obj = null;

        if (pool.Count > 0)
        { 
            obj = pool.Dequeue(); //si ya hay una bola en la cola, entonces se iguala el objeto nulo a esta misma
        }
        else
        {
            //si no hay una bola en la cola, crea una nueva. Creando un indice random para elegir que bola lanzar
            int index = Random.Range(0, balls.Length);
            GameObject newBall = Instantiate(balls[index], transform.position, Quaternion.identity); //con el index, elije que bola tirar de manera random
            newBall.transform.SetParent(this.transform); //Por último, lo vuelve Parent de la cascada ya que es un objeto creada por la misma
        }

        //esto solo pasa si el obj es distinto a null, es decir, si se cumplio la primera condicion, ya que si se cumple la segunda, instancia una nueva
        //esto esta hecho para que, si la bola la saca de la pool, entonces iguala la posicion a la de la cascada, ya que sino apareceria abajo y entraria en un bucle constante
        if (obj != null)
        {
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true); //lo setea true para que se pueda ver
        }
        return obj;
    }

    //esta funcion hace que podamos llamarla desde la clase "BallToPool" para que el objeto se desactive y se meta en la cola si se cumple cierta condición hecha en el script
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    //esto solo pasa a la condición contraria en la que se encuentre el bool con una tecla para poder pausar el spawner
    public void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.M)) isActive = !isActive;
    }
}

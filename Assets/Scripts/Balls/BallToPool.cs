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
        //busca la cascada que tiene el siguiente script para poder acceder a la función "ReturnObject" de "PoolBall"
        poolBalls = FindObjectOfType<PoolBalls>();    
    }

    private void Update()
    {
        //si se cae más alla del 0 en y. Entonces, pausa la captación de gravedad por parte de la pelota y mete la pelota en la cola para poder ser usada
        if(transform.position.y <= 0)
        {
            rb.isKinematic = true;
            poolBalls.ReturnObject(gameObject);
        }
        else
            rb.isKinematic = false;
        //una vez que la bola empieza desde la pos de la cascada, entonces el rigidbody acepta físicas de nuevo
        //Esto lo cree, ya que al ser una pool, la bola seguía con inhercia, por lo cual cada vez iba más y más rápido. Pueden borrar lo de kinematic true para chequear jeje
    }
}

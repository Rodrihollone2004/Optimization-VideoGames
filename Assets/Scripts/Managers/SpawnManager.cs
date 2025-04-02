using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Por inspector le pasamos los diferentes tipos de bolas que hay a instanciar
    [SerializeField] GameObject[] balls;

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
            //le suma al current time el tiempo de play y llama a la función para spawnear bolas jeje
            currentTime += Time.deltaTime;
            SpawnBalls();
        }
    }

    public void SpawnBalls()
    {
        //esto va a crear 1000 bolas sin parar
        for (int i = 0; i < 1000; i++)
        {
            if (currentTime >= delayTime)
            {
                //con un índice random elije que bola tirar en base a las que pusimos por inspector.
                int index = Random.Range(0, balls.Length);
                GameObject newBall = Instantiate(balls[index], transform.position, Quaternion.identity); //Acá es cuando se elije que bola tirar, en el instantiate
                newBall.transform.SetParent(this.transform);
                //Por último, lo vuelve Parent de la cascada ya que es un objeto creada por la misma

                //se iguala el tiempo a 0 para resetear el timer, lo pueden ver por inspector si quieren
                currentTime = 0;
            }
        }
    }

    //esto solo pasa a la condición contraria en la que se encuentre el bool con una tecla para poder pausar el spawner
    public void InputPause()
    {
        if (Input.GetKeyDown(KeyCode.N)) isActive = !isActive;
    }
}

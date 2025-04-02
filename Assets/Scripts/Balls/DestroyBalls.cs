using UnityEngine;

public class DestroyBalls : MonoBehaviour
{
    private void Update()
    {
        //Esto es para que la bola cuando caiga más alla del 0 en y, se destruya. Ya que 1 cascada debe aceptar pool pero la otra solo instancia bolas que cuando caen, se destruyen
        if (transform.position.y <= 0) Destroy(this.gameObject);
    }
}

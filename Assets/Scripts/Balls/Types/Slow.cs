using UnityEngine;

public class Slow : Balls
{
     //Timer para decirle a la bola cuando detenerse en el aire
    [SerializeField] float currentTime;
    [SerializeField] float stopTime;

    //Esto geta y setea lo mismo que el Awake de la clase Balls ya que hereda de la misma
    protected override void Awake()
    {
        base.Awake();
    }

    //Esto iguala lo mismo que en el Start de la clase Balls ya que hereda de ella
    protected override void Start()
    {
        base.Start();
        SetColor(Color.blue); //Setea el color en azul
        SetRandomChar();
    }

    private void Update()
    {
        currentTime += Time.deltaTime; //crea un timer para hacer el stop cada cierto tiempo
        StopFalling();
    }

    //Funci�n para detener la pelota en el aire 1 momento y despu�s sigue cayendo
    private void StopFalling()
    {
        if(currentTime >= stopTime) //cuando el timer se cumple
        {
            rb.isKinematic = true; //pone el rb en kinematic para no actualizar f�sicas
            currentTime = 0; //Reseta el timer igualando a 0
        }
        else 
            rb.isKinematic = false; //Vuelve a aceptar f�sicas para poder seguir cayendo
    }

    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1); //Se pone +1 porque si pones Z, no la toma, sino que hay que a�adirle un n�m m�s para que tome el �ltimo tambi�n
        textChar.text = letter.ToString(); //lo convierte en texto para que lo pueda mostrar el textito de arriba de la bocha
        checkManager.Balls.Add(this); //a�ad� la bola a la lista del checkManager para despu�s chequear las letras que contiene cada bola
    }
}

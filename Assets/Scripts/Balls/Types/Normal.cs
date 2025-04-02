using System.Runtime.InteropServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class Normal : Balls
{
    //Se crean las variables para designar cuanto se va a tepear en X la bola
    [SerializeField] float currentTime;
    [SerializeField] float moveTime;
    [SerializeField] float offSet;

    //Esto geta y setea lo mismo que el Awake de la clase Balls ya que hereda de la misma
    protected override void Awake()
    {
        base.Awake();
    }

    //Esto iguala lo mismo que en el Start de la clase Balls ya que hereda de ella
    protected override void Start()
    {
        base.Start();
        SetColor(Color.red); //Setea el color en rojo
        SetRandomChar();
    }

    private void Update()
    {
        currentTime += Time.deltaTime; //crea un timer para hacer el tp cada cierto tiempo
        TeleportBall();
    }

    //Funci�n que tepea a la bola cuando termina el l�mite del timer (asignado por inspector) en X seg�n el offSet (asignado desde el inspector)
    private void TeleportBall()
    {
        if (currentTime >= moveTime)
        {
            transform.Translate(new Vector3(offSet ,0 ,0));
            currentTime = 0; //Setea el timer en 0 para reiniciarlo
        }
    }

    //Crea un c�racter random entre los puestos ah� (se puede poner hasta la Z, pero lo achique para que aprezca la X)
    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1); //Se pone +1 porque si pones Z, no la toma, sino que hay que a�adirle un n�m m�s para que tome el �ltimo tambi�n
        textChar.text = letter.ToString(); //lo convierte en texto para que lo pueda mostrar el textito de arriba de la bocha
        checkManager.Balls.Add(this); //a�ad� la bola a la lista del checkManager para despu�s chequear las letras que contiene cada bola
    }
}

using UnityEngine;

public class Fast : Balls
{
    //Variables para realizar la función SinuSoidal de la esfera
    [SerializeField] float scaleMultiplier; 
    [SerializeField] float speed = 2f; 
    private Vector3 initialScale; 

    //Esto geta y setea lo mismo que el Awake de la clase Balls ya que hereda de la misma
    protected override void Awake()
    {
        base.Awake();
    }

    //Esto iguala lo mismo que en el Start de la clase Balls ya que hereda de ella
    protected override void Start()
    {
        base.Start();
        SetColor(Color.black); //Setea su color en negro

        initialScale = transform.localScale; //iguala la escala inicial
        SetRandomChar(); 
    }

    private void Update()
    {
        SinusoidalFunction();
    }

    //Función la cual aumenta y disminuye la escala del objeto de forma SinuSoidal gracias al seno que cuando llega a 1 vuelve a 0 y viceversa
    private void SinusoidalFunction()
    {
        float scaleFactor = Mathf.Sin(Time.time * speed) * scaleMultiplier + 1;
        transform.localScale = initialScale * scaleFactor;
    }

    //Crea un cáracter random entre los puestos ahí (se puede poner hasta la Z, pero lo achique para que aprezca la X)
    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1); //Se pone +1 porque si pones Z, no la toma, sino que hay que añadirle un núm más para que tome el último también
        textChar.text = letter.ToString(); //lo convierte en texto para que lo pueda mostrar el textito de arriba de la bocha
        checkManager.Balls.Add(this); //añadé la bola a la lista del checkManager para después chequear las letras que contiene cada bola
    }
}
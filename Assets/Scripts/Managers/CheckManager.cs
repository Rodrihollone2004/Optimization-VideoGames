using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    //Crea una lista donde van a guardarse las bolas que se vayan instanciando, sean el tipo que sean
    [SerializeField] List<Balls> balls;

    //textos para ver en pantalla los contadores si presionamos las teclas
    [SerializeField] TMP_Text countLinqText;
    [SerializeField] TMP_Text countForEachText;
    [SerializeField] TMP_Text countForText;

    //esto es un get para poder acceder desde las distintas clases de bolas y meterlas en la lista
    public List<Balls> Balls => balls;

    private void Awake()
    {
        balls = new List<Balls>();
    }

    private void Update()
    {
        CounterX();
    }

    //Acá se crean 3 funciones que hacen exactamente lo mismo, pero es para la consigna
    private void CounterX()
    {
        int countLinkQ = 0;
        int countForEach = 0;
        int countFor = 0;

        if (Input.GetKeyDown(KeyCode.Keypad1)) //Pad númerico
        {
            //Esta es la forma de contar la cantidad de X que hay en la lista de bolas. LinkQ (yo tampoco se que es xd)
            countLinkQ = balls.Count(balls => balls.Letter == 'X');
            countLinqText.text = "Count LinkQ: " + countLinkQ.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)) //Pad númerico
        {
            //La forma de contar la cantidad de X pero esta vez con un For Each de cada bola dentro de la lista. Cuando llega a 5, break
            foreach (Balls ball in balls)
                if (ball.Letter == 'X')
                {
                    countForEach++;
                    countForEachText.text = "Count For Each: " + countForEach.ToString();
                    if (countForEach > 4)
                        break;
                }
            
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3)) //Pad númerico
        {
            //La forma de contar la cantidad de X pero esta vez con un For de cada bola dentro de la lista. Cuando llega a 5, break
            for (int i = 0; i < balls.Count; i++)
                if (balls[i].Letter == 'X')
                {
                    countFor++;
                    countForText.text = "Count For: " + countFor.ToString();
                    if(countFor > 4)
                        break;
                }
        }
    }
}

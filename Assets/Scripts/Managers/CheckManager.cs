using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CheckManager : MonoBehaviour
{
    [SerializeField] List<Balls> balls;

    [SerializeField] TMP_Text countLinqText;
    [SerializeField] TMP_Text countForEachText;
    [SerializeField] TMP_Text countForText;

    public List<Balls> Balls { get => balls; private set => balls = value; }

    private void Awake()
    {
        balls = new List<Balls>();
    }

    private void Update()
    {
        CounterX();
    }

    private void CounterX()
    {
        int countLinkQ = 0;
        int countForEach = 0;
        int countFor = 0;

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            countLinkQ = balls.Count(balls => balls.Letter == 'X');
            countLinqText.text = "Count LinkQ: " + countLinkQ.ToString();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            foreach (Balls ball in balls)
                if (ball.Letter == 'X')
                {
                    countForEach++;
                    countForEachText.text = "Count For Each: " + countForEach.ToString();
                    if (countForEach > 4)
                        break;
                }
            
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            for(int i = 0; i < balls.Count; i++)
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

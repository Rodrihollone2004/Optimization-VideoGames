using System.Runtime.InteropServices;
using TMPro.EditorUtilities;
using UnityEngine;

public class Normal : Balls
{
    [SerializeField] float currentTime;
    [SerializeField] float moveTime;
    [SerializeField] float offSet;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        SetColor(Color.red);
        SetRandomChar();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        TeleportBall();
    }

    private void TeleportBall()
    {
        if (currentTime >= moveTime)
        {
            transform.Translate(new Vector3(offSet ,0 ,0));
            currentTime = 0;
        }
    }

    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1);
        textChar.text = letter.ToString();
        checkManager.Balls.Add(this);
    }
}

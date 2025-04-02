using UnityEngine;

public class Slow : Balls
{
    [SerializeField] float currentTime;
    [SerializeField] float stopTime;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        SetColor(Color.blue);
        SetRandomChar();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        StopFalling();
    }

    private void StopFalling()
    {
        if(currentTime >= stopTime)
        {
            rb.isKinematic = true;
            currentTime = 0;
        }
        else 
            rb.isKinematic = false;
    }

    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1);
        textChar.text = letter.ToString();
        checkManager.Balls.Add(this);
    }
}

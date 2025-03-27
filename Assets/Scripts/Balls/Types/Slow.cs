using UnityEngine;

public class Slow : Balls
{
    [SerializeField] float currentTime;
    [SerializeField] float stopTime;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SetColor(Color.blue);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        StopFalling();
    }

    public void StopFalling()
    {
        if(currentTime >= stopTime)
        {
            rb.isKinematic = true;
            currentTime = 0;
        }
        else 
            rb.isKinematic = false;
    }
}

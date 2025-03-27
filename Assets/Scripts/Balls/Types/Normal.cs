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

    private void Start()
    {
        SetColor(Color.red);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        TeleportBall();
    }

    public void TeleportBall()
    {
        if (currentTime >= moveTime)
        {
            transform.Translate(new Vector3(offSet ,0 ,0));
            currentTime = 0;
        }
    }
}

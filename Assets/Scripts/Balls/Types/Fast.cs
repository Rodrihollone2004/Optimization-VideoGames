using UnityEngine;

public class Fast : Balls
{
    [SerializeField] float scaleMultiplier = 0.10f; 
    [SerializeField] float speed = 2f; 
    private Vector3 initialScale; 

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        SetColor(Color.black);

        initialScale = transform.localScale; 
        SetRandomChar();
    }

    private void Update()
    {
        SinusoidalFunction();
    }

    private void SinusoidalFunction()
    {
        float scaleFactor = Mathf.Sin(Time.time * speed) * scaleMultiplier + 1;
        transform.localScale = initialScale * scaleFactor;
    }

    private void SetRandomChar()
    {
        letter = (char)Random.Range('W', 'Y' + 1);
        textChar.text = letter.ToString();
        checkManager.Balls.Add(this);
    }
}
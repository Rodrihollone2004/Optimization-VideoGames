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

    private void Start()
    {
        SetColor(Color.black);

        initialScale = transform.localScale; 
    }

    private void Update()
    {
        SinusoidalFunction();
    }

    public void SinusoidalFunction()
    {
        float scaleFactor = Mathf.Sin(Time.time * speed) * scaleMultiplier + 1;
        transform.localScale = initialScale * scaleFactor;
    }
}
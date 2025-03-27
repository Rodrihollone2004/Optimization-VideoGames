using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balls : MonoBehaviour
{
    protected MaterialPropertyBlock materialPropertyBlock;
    protected MeshRenderer meshRenderer;
    protected Rigidbody rb;
    protected TMP_Text textChar;
    protected Queue<char> chars = new Queue<char>();

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
        rb = GetComponent<Rigidbody>();

        textChar = GetComponentInChildren<TMP_Text>();
    }

    protected void SetColor(Color color)
    {
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }

    public void SetRandomChar()
    {
        char letter = (char)Random.Range('A', 'Z' + 1);
        chars.Enqueue(letter);
        textChar.transform.position = transform.position;
        textChar.text = letter.ToString();
    }

    private void LateUpdate()
    {
        // Hacer que el texto siempre siga a la esfera
        if (textChar != null)
        {
            textChar.transform.position = transform.position + Vector3.up * 0.5f; // Ajuste para que el texto quede encima
            textChar.transform.rotation = Quaternion.identity; // Evita que rote con la esfera
        }
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balls : MonoBehaviour
{
    protected MaterialPropertyBlock materialPropertyBlock;
    protected MeshRenderer meshRenderer;
    protected Rigidbody rb;
    protected TMP_Text textChar;
    protected Queue<char> chars;
    
    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        materialPropertyBlock = new MaterialPropertyBlock();
        chars = new Queue<char>();

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
        char letter = (char)Random.Range('W', 'Y' + 1);
        chars.Enqueue(letter);
        textChar.text = letter.ToString();
    }

    private void LateUpdate()
    {
        if (textChar != null)
        {
            textChar.transform.position = transform.position + Vector3.up * 0.5f; 
            textChar.transform.rotation = Quaternion.identity; 
        }
    }
}

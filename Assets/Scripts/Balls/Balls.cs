using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balls : MonoBehaviour
{
    protected MaterialPropertyBlock materialPropertyBlock;
    protected MeshRenderer meshRenderer;
    protected Rigidbody rb;
    protected TMP_Text textChar;
    
    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        materialPropertyBlock = new MaterialPropertyBlock();

        textChar = GetComponentInChildren<TMP_Text>();
    }

    protected void SetColor(Color color)
    {
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }

    public char SetRandomChar()
    {
        char letter = (char)Random.Range('W', 'Y' + 1);
        textChar.text = letter.ToString();

        return letter;
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

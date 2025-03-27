using UnityEngine;

public class Balls : MonoBehaviour
{
    protected MaterialPropertyBlock materialPropertyBlock;
    protected MeshRenderer meshRenderer;
    protected Rigidbody rb;

    protected virtual void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
        rb = GetComponent<Rigidbody>();
    }

    protected void SetColor(Color color)
    {
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }
}

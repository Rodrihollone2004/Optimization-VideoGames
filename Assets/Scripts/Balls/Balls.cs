using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balls : MonoBehaviour
{
    //Esta es la clase padre de los tipos de pelotas que hay "Fast", "Slow", "Normal".
    protected MaterialPropertyBlock materialPropertyBlock; //materialPropertyBlock para cambiar el color de cada una sin instanciar un nuevo material
    protected MeshRenderer meshRenderer; //Esto también sirve para cambiar el color de la pelota
    protected Rigidbody rb; //cada pelota va a tener un rb para su caida
    protected char letter; //una letra que sirve para la consigna de después chequear cuantas X se instanciaron
    protected CheckManager checkManager; //para después utilizar las funciones que chequean cuantas X hay en la lista de pelotas
    protected TMP_Text textChar; //para mostrar un texto en pantalla con la letra de cada pelota (no funciona)
    
    //un get para poder usarla en la clase "CheckManager"
    public char Letter => letter;

    protected virtual void Awake()
    {
        //Getea y crea los componentes necesarios. Esto después ya lo va a hacer cada bola desde su instancia, ya que van a heredadar este método.
        meshRenderer = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        materialPropertyBlock = new MaterialPropertyBlock();

        textChar = GetComponentInChildren<TMP_Text>();
    }

    protected virtual void Start()
    {
        //Busca el script que va a estar en un objeto de la escena. Esto después ya lo va a hacer cada bola desde su instancia, ya que van a heredadar este método.
        checkManager = FindObjectOfType<CheckManager>();
    }

    protected void SetColor(Color color)
    {
        //Setea el color de la Mesh según el que le pasemos por parámetro. Todo con MaterialPropertyBlock
        meshRenderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", color);
        meshRenderer.SetPropertyBlock(materialPropertyBlock);
    }

    //en esta función setea la posición del texto de las pelotas un poquito más arriba de las mismas para que estén a la vista y se entienda
    private void LateUpdate()
    {
        if (textChar != null)
        {
            textChar.transform.position = transform.position + Vector3.up * 0.5f; 
            textChar.transform.rotation = Quaternion.identity; 
        }
    }
}

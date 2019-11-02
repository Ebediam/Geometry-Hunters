using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockSettings : MonoBehaviour
{
    public delegate void OnCollisionDelegate();
    public OnCollisionDelegate OnCollisionEvent;

    public TextBlockType blockType;
    public Material mat;
    public TextMeshPro text;
    public MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {

        
        Material material = new Material(mat);
        mesh.material = material;
        text.text = blockType.text;
        text.fontSize = blockType.textSize;


        text.color = blockType.textColor;


        material.SetColor("_boxColor", blockType.blockColor);

    }

    public void OnCollisionEnter(Collision collision)
    {
        OnCollisionEvent?.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Box", fileName = "NewTextBox")]
public class TextBlockType : ScriptableObject
{
    public string textBlockID;
    public string text;
    public Color blockColor;
    public Color textColor;
    public int textSize;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorText : MonoBehaviour
{
    public TextHit textHit;
    public Range rangeXDefault = new Range();
    public Range rangeYDefault = new Range();

    


    public void CreateTextHit(TextHit textHit, 
                              string content, 
                              Transform parent, 
                              float size, 
                              Color color, 
                              Range rangeGapX, 
                              Range rangeGapY,
                              float timeLife)
    {
        // Desface que debe tener el texto con el object padre
        Vector3 gap = new Vector2(Random.Range(rangeGapX.min, rangeGapX.max), 
                                  Random.Range(rangeGapY.min, rangeGapY.max));

        //Instanciar
        TextHit newTextHit  = Instantiate(textHit, parent.position + gap, Quaternion.identity,parent);

        //Asignar valores
        newTextHit.timeLife = timeLife;
        newTextHit.textMesh.color = color;
        newTextHit.textMesh.characterSize = size;
        newTextHit.textMesh.text = content;
    }


    //Funcion de validación, por si entra un float en el contenido
    public void CreateTextHit(TextHit textHit,
                              int content,
                              Transform parent,
                              float size,
                              Color color,
                              Range rangeGapX,
                              Range rangeGapY,
                              float timeLife)
    {
        //Convertir float a string
        string contentToString = content.ToString();

        //LLamar funcion normal ()
        CreateTextHit(textHit,
                      contentToString,
                      parent,
                      size,
                      color,
                      rangeGapX,
                      rangeGapY,
                      timeLife);
    
    }



    public void CreateTextHits(string content)
    {
        Debug.Log("solo Text");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjetosEscriptables/Atributos")]
public class Attributes : ScriptableObject
{
    [Tooltip("Velocidad de movimiento")]
    public int velocity;

    [Tooltip("Cantidad de daño que provoca")]
    public int attack; 
}

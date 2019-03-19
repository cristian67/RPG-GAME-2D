using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Atributte
{
    velocity,
    attack,
    salud
}

[CreateAssetMenu(menuName = "ObjetosEscriptables/Atributos")]
public class Attributes : ScriptableObject
{
    [SerializeField]
    private int velocityBase;
    [SerializeField]
    private int attackBase;


    private int ModificatorVelocity;
    private int ModificatorAttack;


    public int velocity { get { return velocityBase + ModificatorVelocity; } }
    public int attack   { get { return attackBase + ModificatorAttack; } }

    public void IncreaseBaseVelocity( int amount)
    {
        velocityBase += amount;
    }

    public void IncreaseBaseAttack(int amount)
    {
        attackBase += amount;
    }

    public void ModificateAttribute( Atributte atributte, int amount)
    {
        switch (atributte)
        {
            case Atributte.velocity:
                ModificatorVelocity += amount;
                Debug.Log("velo");
                break;
            case Atributte.attack:
                ModificatorAttack += amount;
                Debug.Log("att");
                break;
            case Atributte.salud:
                Debug.Log("sal");
                break;
            default:
                Debug.Log("nothing");
                break;
        }
    }


    public void ModificatorSalud(Salud salud, int amount)
    {
        salud.ModificatorSalud += amount;
    }
}

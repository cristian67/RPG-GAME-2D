using System;
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


    public void UpdateEquip(List<Kit> kits)
    {
        ResetModificator();
        foreach (Kit kit in kits)
        {
            ModificatorVelocity += kit.velocity;
            ModificatorAttack += kit.attack;

            GameManager.Instance.player.GetComponent<Salud>().ModificatorSalud += kit.salud;
        }

        PanelAttribute.Instance.UpdateTextAtributte(this, 
                                                    GameManager.Instance.player.GetComponent<Salud>(), 
                                                    GameManager.Instance.player.GetComponent<ExperienceLevel>());

        GameManager.Instance.player.GetComponent<Salud>().UpdateSaludBar(); 
    }

    private void ResetModificator()
    {
        ModificatorAttack   = 0;
        ModificatorVelocity = 0;
        GameManager.Instance.player.GetComponent<Salud>().ModificatorSalud = 0;

    }
}

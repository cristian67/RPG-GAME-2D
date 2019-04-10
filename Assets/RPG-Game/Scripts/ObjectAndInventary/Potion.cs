using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ObjetosEscriptables/item/pociones/Salud")]
public class Potion : Item
{
    public int healing;

    public override bool UsedItem()
    {
        Salud playerSalud = GameManager.Instance.player.GetComponent<Salud>();
        if (playerSalud.ActualSalud >= playerSalud.salud)
        {
            Debug.Log("Salud llena!");
            return false;
        }
        else
        {
            playerSalud.UpdateActualSalud(healing);
            return true;
        }
    }
}

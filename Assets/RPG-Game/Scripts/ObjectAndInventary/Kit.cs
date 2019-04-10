using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Equipment
{
    helmet,
    armor,
    weapon
}


[CreateAssetMenu(menuName = "ObjetosEscriptables/item/kit")]
public class Kit : Item
{
    public Equipment typeKit;
    public int salud;
    public int attack;
    public int velocity;

    public override bool UsedItem()
    {
        Kit equipActual = EquipamentPanel.Instance.EquipmentObject(this);
        if (equipActual)
        {
            EquipamentPanel.Instance.RemoveEquip(equipActual);
            Inventary.Instance.AddObject(equipActual, 1);
        }
        else {

            Debug.Log("no esta el equipo ql ");
        }

        return true;
    }
}
